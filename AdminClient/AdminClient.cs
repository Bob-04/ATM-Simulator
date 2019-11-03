using System.Threading.Tasks;
using KMA.MOOP.ATM.Client.AdminClient.ServiceReference1;
using KMA.MOOP.ATM.DBModels;
using IBankAdministratorSimulator = KMA.MOOP.ATM.Server.Interface.IBankAdministratorSimulator;

namespace KMA.MOOP.ATM.Client.AdminClient
{
    public class AdminClient :IBankAdministratorSimulator
    {
        public string RegisterClient(DBModels.Client cl)
        {
            BankAdministratorSimulatorClient client = new BankAdministratorSimulatorClient();
            Task<string> task = client.RegisterClientAsync(cl);
            client.Close();
            return task.Result;
        }

        public DBModels.Client GetClient(long identificationCode, string password)
        {
            BankAdministratorSimulatorClient client = new BankAdministratorSimulatorClient();
            Task<DBModels.Client> task = client.GetClientAsync(identificationCode, password);
            client.Close();
            return task.Result;
        }

        public string AddAccount(DBModels.Client cl, Account acc)
        {
            BankAdministratorSimulatorClient client = new BankAdministratorSimulatorClient();
            Task<string> task = client.AddAccountAsync(cl, acc);
            client.Close();
            return task.Result;
        }
    }
}
