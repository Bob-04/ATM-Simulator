using System;
using System.ServiceModel;
using KMA.MOOP.ATM.DBModels;

namespace KMA.MOOP.ATM.Server.Interface
{
    [ServiceContract]
    public interface IATMSimulator
    {
        [OperationContract]
        Account LoginAccount(string num, string pin);

        [OperationContract]
        string AddMoney(Account acc, uint amount);

        [OperationContract]
        string WithdrawMoney(Account acc, string pin, uint amount);

        [OperationContract]
        string CashSurplusProcessing(Account acc, string pin, uint maxBalance, string surplusesNumber);

        [OperationContract]
        string LimitExceedingProtection(Account acc, string pin, uint minBalance, string securityNumber);

        [OperationContract]
        string AddTransaction(Account acc, string pin,
            string recipientNumber, uint amount, DateTime startTime, DateTime? period = null);
    }
}
