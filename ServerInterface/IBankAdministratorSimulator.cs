using System.ServiceModel;
using KMA.MOOP.ATM.DBModels;

namespace KMA.MOOP.ATM.Server.Interface
{
    [ServiceContract]
    public interface IBankAdministratorSimulator
    {
        [OperationContract]
        string RegisterClient(Client cl);

        [OperationContract]
        Client GetClient(long identificationCode, string password);

        [OperationContract]
        string AddAccount(Client cl, Account acc);

        [OperationContract]
        string UnblockAccount(Client cl, string accNumber);
    }
}
