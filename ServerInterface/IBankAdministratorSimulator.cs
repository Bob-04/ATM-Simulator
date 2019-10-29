using System.ServiceModel;
using KMA.MOOP.ATM.DBModels;

namespace KMA.MOOP.ATM.Server.Interface
{
    [ServiceContract]
    public interface IBankAdministratorSimulator
    {
        [OperationContract]
        void RegisterClient(Client cl);

        [OperationContract]
        void AddAccount(Client cl, Account acc);

        [OperationContract]
        void EditClient(Client oldCl, Client newCl);
    }
}
