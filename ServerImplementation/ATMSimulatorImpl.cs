using System;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.Server.Implementation
{
    public class ATMSimulatorImpl : IATMSimulator
    {
        public void LoginAccount(string num, string pas)
        {
            throw new NotImplementedException();
        }

        public void AddMoney(Account acc, uint amount)
        {
            throw new NotImplementedException();
        }

        public void WithdrawMoney(Account acc, uint amount)
        {
            throw new NotImplementedException();
        }

        public void CashSurplusProcessing(Account acc, uint maxBalance, string surplusesNumber)
        {
            throw new NotImplementedException();
        }

        public void LimitExceedingProtection(Account acc, uint minBalance, string securityNumber)
        {
            throw new NotImplementedException();
        }

        public void AddTransaction(Account acc, string recipientNumber, uint amount, DateTime startTime, DateTime? period = null)
        {
            throw new NotImplementedException();
        }
    }
}
