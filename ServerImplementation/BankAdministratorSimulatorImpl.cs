using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.EntityFrameworkWrapper;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.Server.Implementation
{
    public class BankAdministratorSimulatorImpl :IBankAdministratorSimulator
    {
        private readonly DBImpl _db;

        public BankAdministratorSimulatorImpl()
        {
            _db = new DBImpl();
        }
        

        public string RegisterClient(Client cl)
        {
            return _db.RegisterClient(cl);
        }

        public Client GetClient(long identificationCode, string password)
        {
            return _db.GetClient(identificationCode, password);
        }

        public string AddAccount(Client cl, Account acc)
        {
            return _db.AddAccount(cl, acc);
        }
    }
}
