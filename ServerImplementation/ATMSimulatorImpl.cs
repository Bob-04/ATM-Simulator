using System;
using System.Linq;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.EntityFrameworkWrapper;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.Server.Implementation
{
    public class ATMSimulatorImpl : IATMSimulator
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
                if(acc == null || (dbAccount = db.Account.FirstOrDefault(
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

                if(dbAccount.Balance < amount)
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

                if(dbAccount.Number == surplusesNumber)
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

                dbAccount.Transactions.Add(new Transaction(recipientAccount.Guid, amount, startTime, period));

                db.SaveChanges();
                return "Operation completed successfully!";
            }
        }
    }
}
