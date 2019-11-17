using System;
using System.Threading.Tasks;
using KMA.MOOP.ATM.Client.ATMClient.ServiceReference1;
using KMA.MOOP.ATM.DBModels;
using IATMSimulator = KMA.MOOP.ATM.Server.Interface.IATMSimulator;

namespace KMA.MOOP.ATM.Client.ATMClient
{
    public class ATMClient : IATMSimulator
    {
        public Account LoginAccount(string num, string pin)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            Task<Account> task = client.LoginAccountAsync(num, pin);
            client.Close();
            return task.Result;
        }

        public string AddMoney(Account acc, uint amount)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            Task<string> task = client.AddMoneyAsync(acc, amount);
            client.Close();
            return task.Result;
        }

        public string WithdrawMoney(Account acc, string pin, uint amount)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            Task<string> task = client.WithdrawMoneyAsync(acc, pin, amount);
            client.Close();
            return task.Result;
        }

        public string CashSurplusProcessing(Account acc, string pin, uint maxBalance, string surplusesNumber)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            Task<string> task = client.CashSurplusProcessingAsync(acc, pin, maxBalance, surplusesNumber);
            client.Close();
            return task.Result;
        }

        public string LimitExceedingProtection(Account acc, string pin, uint minBalance, string securityNumber)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            Task<string> task = client.LimitExceedingProtectionAsync(acc, pin, minBalance, securityNumber);
            client.Close();
            return task.Result;
        }

        public string AddTransaction(Account acc, string pin,
            string recipientNumber, uint amount, DateTime startTime, double? daysPeriod = null)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            Task<string> task = client.AddTransactionAsync(acc, pin, 
                recipientNumber, amount, startTime, daysPeriod);
            client.Close();
            return task.Result;
        }
    }
}
