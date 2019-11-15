using System;
using System.Linq;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.EntityFrameworkWrapper
{
    public class DBImpl : IATMSimulator, IBankAdministratorSimulator, IProcessing
    {
        public Account LoginAccount(string num, string pin)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Account.FirstOrDefault(
                    ac => ac.Number == num && ac.Pin == pin);
            }
        }

        public string AddMoney(Account acc, uint amount)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if (acc == null || (dbAccount = db.Account.FirstOrDefault(
                       ac => ac.Number == acc.Number)) == null)
                    return "Failed to login account";

                dbAccount.Balance += amount;
                db.SaveChanges();
                return "Money successfully credited";
            }
        }

        public string WithdrawMoney(Account acc, string pin, uint amount)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if (acc == null || (dbAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == acc.Number && ac.Pin == pin)) == null)
                    return "Failed to login account";

                if (dbAccount.Balance < amount)
                    return "Not enough money in the account";

                dbAccount.Balance -= amount;
                db.SaveChanges();
                return "Money successfully withdraw";
            }
        }

        public string CashSurplusProcessing(Account acc, string pin, uint maxBalance, string surplusesNumber)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if (acc == null || (dbAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == acc.Number && ac.Pin == pin)) == null)
                    return "Failed to login account";

                if (dbAccount.MinBalance > maxBalance)
                    return $"Failed! Your min balance more then {maxBalance}";

                if (dbAccount.Number == surplusesNumber)
                    return "Failed! Entered your account number as surpluses";

                Account surplusesAccount;
                if ((surplusesAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == surplusesNumber)) == null)
                    return "Failed! Entered surpluses number doesn't exist";

                dbAccount.MaxBalance = maxBalance;
                dbAccount.SurplusesAccountGuid = surplusesAccount.Guid;

                db.SaveChanges();
                return "Operation completed successfully!";
            }
        }

        public string LimitExceedingProtection(Account acc, string pin, uint minBalance, string securityNumber)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if (acc == null || (dbAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == acc.Number && ac.Pin == pin)) == null)
                    return "Failed to login account";

                if (dbAccount.MaxBalance != 0 && dbAccount.MaxBalance < minBalance)
                    return $"Failed! Your max balance less then {minBalance}";

                if (dbAccount.Number == securityNumber)
                    return "Failed! Entered your account number as security";

                Account securityAccount;
                if ((securityAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == securityNumber)) == null)
                    return "Failed! Entered security number doesn't exist";

                dbAccount.MinBalance = minBalance;
                dbAccount.SecurityAccountGuid = securityAccount.Guid;

                db.SaveChanges();
                return "Operation completed successfully!";
            }
        }

        public string AddTransaction(Account acc, string pin,
            string recipientNumber, uint amount, DateTime startTime, DateTime? period = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if (acc == null || (dbAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == acc.Number && ac.Pin == pin)) == null)
                    return "Failed to login account";

                if (dbAccount.Number == recipientNumber)
                    return "Failed! Entered your account number as recipient";

                Account recipientAccount;
                if ((recipientAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == recipientNumber)) == null)
                    return "Failed! Entered recipient number doesn't exist";

                dbAccount.Transactions.Add(new Transaction(acc.Guid,
                    recipientAccount.Guid, amount, startTime, period));

                db.SaveChanges();
                return "Operation completed successfully!";
            }
        }

        public string RegisterClient(Client cl)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Clients.Add(cl);

                try
                {
                    db.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    return "Client with the same Identification Code or Phone already contains";
                }

                return $"Client {cl} successfully registered";
            }
        }

        public Client GetClient(long identificationCode, string password)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Clients.FirstOrDefault(
                    cl => cl.IdentificationCode == identificationCode && cl.CheckPassword(password));
            }
        }

        public string AddAccount(Client cl, Account acc)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Client dbClient;
                if (cl == null || (dbClient = db.Clients.FirstOrDefault(
                        c => c.IdentificationCode == cl.IdentificationCode &&
                             c.CheckPassword(cl.Password))) == null)
                    return "This client doesn't exist";

                dbClient.Accounts.Add(acc);

                try
                {
                    db.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    return $"Card number {acc} already contains";
                }
            }
            return $"Account successfully added to client {cl}";
        }

        public void ExecuteTransactions()
        {
            DateTime currentTime = DateTime.Now;

            using (DatabaseContext db = new DatabaseContext())
            {
                foreach (Transaction tr in db.Transaction.Where(t => !t.Execute))
                {
                    if (tr.StartTime <= currentTime)
                    {
                        Account recipientAccount = db.Account.
                            FirstOrDefault(ac => ac.Guid == tr.RecipientAccountGuid);
                        if (recipientAccount == null)
                        {
                            tr.Execute = true;
                            continue;
                        }

                        Account senderAccount = db.Account.
                            First(ac => ac.Guid == tr.AccountGuid);

                        WithdrawMoney(senderAccount, senderAccount.Pin, tr.Amount);
                        AddMoney(recipientAccount, tr.Amount);

                        if (tr.Period != null)
                            tr.StartTime = tr.StartTime.AddDays(tr.Period.GetValueOrDefault().Day)
                                .AddMonths(tr.Period.GetValueOrDefault().Month);
                        else
                            tr.Execute = true;
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}
