using System;
using KMA.MOOP.ATM.Client.ATMClient.ServiceReference1;
using KMA.MOOP.ATM.DBModels;
using IATMSimulator = KMA.MOOP.ATM.Server.Interface.IATMSimulator;

namespace KMA.MOOP.ATM.Client.ATMClient
{
    public class ATMClient : IATMSimulator
    {
        public void LoginAccount(string num, string pas)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.LoginAccountAsync(num, pas);
            client.Close();
        }

        public void AddMoney(Account acc, uint amount)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.AddMoneyAsync(acc, amount);
            client.Close();
        }

        public void WithdrawMoney(Account acc, uint amount)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.WithdrawMoneyAsync(acc, amount);
            client.Close();
        }

        public void CashSurplusProcessing(Account acc, uint maxBalance, string surplusesNumber)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.CashSurplusProcessingAsync(acc, maxBalance, surplusesNumber);
            client.Close();
        }

        public void LimitExceedingProtection(Account acc, uint minBalance, string securityNumber)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.LimitExceedingProtectionAsync(acc, minBalance, securityNumber);
            client.Close();
        }

        public void AddTransaction(Account acc, string recipientNumber, uint amount, 
            DateTime startTime, DateTime? period = null)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.AddTransactionAsync(acc, recipientNumber, amount, startTime, period);
            client.Close();
        }
    }
}
