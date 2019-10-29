using KMA.MOOP.ATM.Client.AdminClient.ServiceReference1;
using KMA.MOOP.ATM.DBModels;
using IBankAdministratorSimulator = KMA.MOOP.ATM.Server.Interface.IBankAdministratorSimulator;

namespace KMA.MOOP.ATM.Client.AdminClient
{
    class AdminClient :IBankAdministratorSimulator
    {
        public void RegisterClient(DBModels.Client cl)
        {
            BankAdministratorSimulatorClient client = new BankAdministratorSimulatorClient();
            client.RegisterClient(cl);
            client.Close();
        }

        public void AddAccount(DBModels.Client cl, Account acc)
        {
            BankAdministratorSimulatorClient client = new BankAdministratorSimulatorClient();
            client.AddAccount(cl, acc);
            client.Close();
        }

        public void EditClient(DBModels.Client oldCl, DBModels.Client newCl)
        {
            BankAdministratorSimulatorClient client = new BankAdministratorSimulatorClient();
            client.EditClient(oldCl, newCl);
            client.Close();
        }
    }
}
