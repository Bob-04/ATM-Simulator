using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.Server.Implementation
{
    public class ATMSimulatorImpl : IATMSimulator
    {
        public void LoginAccount(string num, string pas)
        {
            throw new System.NotImplementedException();
        }

        public void Transfer(Account @from, Account to, uint amount)
        {
            throw new System.NotImplementedException();
        }

        public void AddMoney(Account acc, uint amount)
        {
            throw new System.NotImplementedException();
        }

        public void WithdrawMoney(Account acc, uint amount)
        {
            throw new System.NotImplementedException();
        }
    }
}
