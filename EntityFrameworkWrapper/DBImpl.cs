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
                Account dbAccount = db.Account.FirstOrDefault(
                    ac => ac.Number == num && ac.Pin == pin);
                if (dbAccount != null && !dbAccount.Active)
                    return new Account("", "", AccountType.BonusAccount);

                return dbAccount;
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

                if (!dbAccount.Active)
                    return "Account is blocked, please contact administrator";

                dbAccount.Balance += amount;

                if (dbAccount.SurplusesAccountGuid != Guid.Empty && dbAccount.Balance > dbAccount.MaxBalance)
                {
                    Account surplusesAccount =
                        db.Account.FirstOrDefault(ac => ac.Guid == dbAccount.SurplusesAccountGuid);
                    if (surplusesAccount == null)
                    {
                        dbAccount.MaxBalance = 0;
                        dbAccount.SurplusesAccountGuid = Guid.Empty;
                    }
                    else
                    {
                        AddMoney(surplusesAccount, dbAccount.Balance - dbAccount.MaxBalance);
                        dbAccount.Balance = dbAccount.MaxBalance;
                    }
                }

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

                if (!dbAccount.Active)
                    return "Account is blocked, please contact administrator";

                if (dbAccount.Balance < amount)
                {
                    if (dbAccount.SecurityAccountGuid == Guid.Empty)
                        return "Not enough money in the account";

                    Account securityAccount = db.Account.
                        FirstOrDefault(ac => ac.Guid == dbAccount.SecurityAccountGuid);
                    if (securityAccount == null)
                    {
                        dbAccount.MinBalance = 0;
                        dbAccount.SecurityAccountGuid = Guid.Empty;
                        return "Not enough money in the account";
                    }

                    if (WithdrawMoney(securityAccount, securityAccount.Pin,
                            amount - dbAccount.Balance) == "Not enough money in the account")
                        return "Not enough money in the account";

                    dbAccount.Balance = 0;
                }
                else
                {
                    dbAccount.Balance -= amount;
                }

                if (dbAccount.Balance < dbAccount.MinBalance)
                {
                    if (dbAccount.SecurityAccountGuid == Guid.Empty)
                        return "Not enough money in the account";

                    Account securityAccount = db.Account.FirstOrDefault(ac => ac.Guid == dbAccount.SecurityAccountGuid);
                    if (securityAccount == null)
                    {
                        dbAccount.MinBalance = 0;
                        dbAccount.SecurityAccountGuid = Guid.Empty;
                    }
                    else if (WithdrawMoney(securityAccount, securityAccount.Pin,
                                 dbAccount.MinBalance - dbAccount.Balance) == "Money successfully withdraw")
                        dbAccount.Balance = dbAccount.MinBalance;
                }

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

                if (!dbAccount.Active)
                    return "Account is blocked, please contact administrator";

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

                if (!dbAccount.Active)
                    return "Account is blocked, please contact administrator";

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
            string recipientNumber, uint amount, DateTime startTime, double? daysPeriod = null)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if (acc == null || (dbAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == acc.Number && ac.Pin == pin)) == null)
                    return "Failed to login account";

                if (!dbAccount.Active)
                    return "Account is blocked, please contact administrator";

                if (dbAccount.Number == recipientNumber)
                    return "Failed! Entered your account number as recipient";

                Account recipientAccount;
                if ((recipientAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == recipientNumber)) == null)
                    return "Failed! Entered recipient number doesn't exist";

                dbAccount.Transactions.Add(new Transaction(acc.Guid,
                    recipientAccount.Guid, amount, startTime, daysPeriod));

                db.SaveChanges();
                return "Operation completed successfully!";
            }
        }

        public string BlockAccount(Account acc)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if (acc == null || (dbAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == acc.Number)) == null)
                    return "Failed to login account";

                dbAccount.Active = false;

                db.SaveChanges();
                return "Account is blocked!";
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

        public string UnblockAccount(Client cl, string accNumber)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Account dbAccount;
                if ((dbAccount = db.Account.FirstOrDefault(
                        ac => ac.Number == accNumber)) == null)
                    return "Failed to login account";

                dbAccount.Active = true;

                db.SaveChanges();
                return "Account is unblocked!";
            }
        }

        public void ExecuteTransactions()
        {
            DateTime currentTime = DateTime.Now;

            using (DatabaseContext db = new DatabaseContext())
            {
                foreach (Transaction tr in db.Transaction.Where(t => t.TransactionTime <= currentTime))
                {
                    Account recipientAccount = db.Account.
                        FirstOrDefault(ac => ac.Guid == tr.RecipientAccountGuid);
                    if (recipientAccount == null)
                        db.Transaction.Remove(tr);

                    Account senderAccount = db.Account.
                        First(ac => ac.Guid == tr.AccountGuid);

                    if (WithdrawMoney(senderAccount, senderAccount.Pin, tr.Amount) ==
                        "Money successfully withdraw")
                        AddMoney(recipientAccount, tr.Amount);

                    if (tr.DaysPeriod != null)
                        tr.TransactionTime = tr.TransactionTime.AddDays((double) tr.DaysPeriod);
                    else
                        db.Transaction.Remove(tr);
                }
                db.SaveChanges();
            }
        }
    }
}
