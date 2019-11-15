using System;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.EntityFrameworkWrapper;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.Server.Implementation
{
    public class ATMSimulatorImpl : IATMSimulator
    {
        private readonly DBImpl _db;

        public ATMSimulatorImpl()
        {
            _db = new DBImpl();
        }


        public Account LoginAccount(string num, string pin)
        {
            return _db.LoginAccount(num, pin);
        }

        public string AddMoney(Account acc, uint amount)
        {
            return _db.AddMoney(acc, amount);
        }

        public string WithdrawMoney(Account acc, string pin, uint amount)
        {
            return _db.WithdrawMoney(acc, pin, amount);
        }

        public string CashSurplusProcessing(Account acc, string pin, uint maxBalance, string surplusesNumber)
        {
            return _db.CashSurplusProcessing(acc, pin, maxBalance, surplusesNumber);
        }

        public string LimitExceedingProtection(Account acc, string pin, uint minBalance, string securityNumber)
        {
            return _db.LimitExceedingProtection(acc, pin, minBalance, securityNumber);
        }

        public string AddTransaction(Account acc, string pin, 
            string recipientNumber, uint amount, DateTime startTime, DateTime? period = null)
        {
            return _db.AddTransaction(acc, pin, recipientNumber, amount, startTime, period);
        }
    }
}
