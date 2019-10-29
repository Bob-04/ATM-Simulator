using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.Server.Implementation;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.Server.WcfServerIIS
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "WcfServerIIS" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы WcfServerIIS.svc или WcfServerIIS.svc.cs в обозревателе решений и начните отладку.
    public class WcfServerIIS : IATMSimulator, IBankAdministratorSimulator
    {
        private readonly ATMSimulatorImpl _atmService;
        private readonly BankAdministratorSimulatorImpl _administratorService;

        public WcfServerIIS()
        {
            _atmService = new ATMSimulatorImpl();
            _administratorService = new BankAdministratorSimulatorImpl();
        }

        public void LoginAccount(string num, string pas)
        {
            _atmService.LoginAccount(num, pas);
        }

        public void Transfer(Account from, Account to, uint amount)
        {
            _atmService.Transfer(from, to, amount);
        }

        public void AddMoney(Account acc, uint amount)
        {
            _atmService.AddMoney(acc, amount);
        }

        public void WithdrawMoney(Account acc, uint amount)
        {
            _atmService.WithdrawMoney(acc, amount);
        }

        public void RegisterClient(Client cl)
        {
            _administratorService.RegisterClient(cl);
        }

        public void AddAccount(Client cl, Account acc)
        {
            _administratorService.AddAccount(cl, acc);
        }

        public void EditClient(Client oldCl, Client newCl)
        {
            _administratorService.EditClient(oldCl, newCl);
        }
    }
}
