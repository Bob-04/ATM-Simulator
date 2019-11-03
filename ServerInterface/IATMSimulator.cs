using System;
using System.ServiceModel;
using KMA.MOOP.ATM.DBModels;

namespace KMA.MOOP.ATM.Server.Interface
{
    [ServiceContract]
    public interface IATMSimulator
    {
        [OperationContract]
        void LoginAccount(string num, string pas);

        [OperationContract]
        void AddMoney(Account acc, uint amount);

        [OperationContract]
        void WithdrawMoney(Account acc, uint amount);

        [OperationContract]
        void CashSurplusProcessing(Account acc, uint maxBalance, string surplusesNumber);

        [OperationContract]
        void LimitExceedingProtection(Account acc, uint minBalance, string securityNumber);

        [OperationContract]
        void AddTransaction(Account acc, string recipientNumber, uint amount,
            DateTime startTime, DateTime? period = null);
    }
}
