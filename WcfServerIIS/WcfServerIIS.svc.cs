using System;
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

        public void AddMoney(Account acc, uint amount)
        {
            _atmService.AddMoney(acc, amount);
        }

        public void WithdrawMoney(Account acc, uint amount)
        {
            _atmService.WithdrawMoney(acc, amount);
        }

        public void CashSurplusProcessing(Account acc, uint maxBalance, string surplusesNumber)
        {
            _atmService.CashSurplusProcessing(acc, maxBalance, surplusesNumber);
        }

        public void LimitExceedingProtection(Account acc, uint minBalance, string securityNumber)
        {
            _atmService.LimitExceedingProtection(acc, minBalance, securityNumber);
        }

        public void AddTransaction(Account acc, string recipientNumber, uint amount, DateTime startTime, DateTime? period = null)
        {
            _atmService.AddTransaction(acc, recipientNumber, amount, startTime, period);
        }

        public string RegisterClient(Client cl)
        {
            return _administratorService.RegisterClient(cl);
        }

        public Client GetClient(long identificationCode, string password)
        {
            return _administratorService.GetClient(identificationCode, password);
        }

        public string AddAccount(Client cl, Account acc)
        {
            return _administratorService.AddAccount(cl, acc);
        }
    }
}
