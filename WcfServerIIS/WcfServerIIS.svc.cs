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

        public Account LoginAccount(string num, string pin)
        {
            return _atmService.LoginAccount(num, pin);
        }

        public string AddMoney(Account acc, uint amount)
        {
            return _atmService.AddMoney(acc, amount);
        }

        public string WithdrawMoney(Account acc, string pin, uint amount)
        {
            return _atmService.WithdrawMoney(acc, pin, amount);
        }

        public string CashSurplusProcessing(Account acc, string pin, uint maxBalance, string surplusesNumber)
        {
            return _atmService.CashSurplusProcessing(acc, pin, maxBalance, surplusesNumber);
        }

        public string LimitExceedingProtection(Account acc, string pin, uint minBalance, string securityNumber)
        {
            return _atmService.LimitExceedingProtection(acc, pin, minBalance, securityNumber);
        }

        public string AddTransaction(Account acc, string pin, string recipientNumber,
            uint amount, DateTime startTime, double? daysPeriod = null)
        {
            return _atmService.AddTransaction(acc, pin, recipientNumber, amount, startTime, daysPeriod);
        }

        public string BlockAccount(Account acc)
        {
            return _atmService.BlockAccount(acc);
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

        public string UnblockAccount(Client cl, string accNumber)
        {
            return _administratorService.UnblockAccount(cl, accNumber);
        }
    }
}
