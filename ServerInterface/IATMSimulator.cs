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
        void WithdrawMoney(Account acc, uint amount);

        [OperationContract]
        void AddMoney(Account acc, uint amount);

        [OperationContract]
        void Transfer(Account from, Account to, uint amount);
    }
}
