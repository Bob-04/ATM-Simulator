using KMA.MOOP.ATM.Client.ATMClient.ServiceReference1;
using KMA.MOOP.ATM.DBModels;
using IATMSimulator = KMA.MOOP.ATM.Server.Interface.IATMSimulator;

namespace KMA.MOOP.ATM.Client.ATMClient
{
    class ATMClient : IATMSimulator
    {
        public void LoginAccount(string num, string pas)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.LoginAccount(num, pas);
            client.Close();
        }

        public void WithdrawMoney(Account acc, uint amount)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.WithdrawMoney(acc, amount);
            client.Close();
        }

        public void AddMoney(Account acc, uint amount)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.AddMoney(acc, amount);
            client.Close();
        }

        public void Transfer(Account @from, Account to, uint amount)
        {
            ATMSimulatorClient client = new ATMSimulatorClient();
            client.Transfer(from, to, amount);
            client.Close();
        }
    }
}
