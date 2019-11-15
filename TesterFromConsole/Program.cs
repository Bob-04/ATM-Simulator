using System;
using KMA.MOOP.ATM.Client.AdminClient;
using KMA.MOOP.ATM.Client.ATMClient;
using KMA.MOOP.ATM.DBModels;

namespace TesterFromConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminClient admin = new AdminClient();

            Client client = new Client(14297,
                "Bob", "O", "+380667577146", "22");

            Console.WriteLine(
                admin.RegisterClient(client)
            );

            Console.WriteLine(
                admin.AddAccount(client, new Account("12345677", "2222", AccountType.CreditAccount))
            );


            //Client cl = admin.GetClient(1429, "-1");

            //Console.WriteLine(
            //    admin.AddAccount(cl, new Account("12345677", "2222", AccountType.BonusAccount))
            //);

            ATMClient atm = new ATMClient();

            Account ac = atm.LoginAccount("12345678", "2228");

            Console.WriteLine(
                atm.AddTransaction(ac, "2228", "12345677", 200, DateTime.Now)
            //atm.WithdrawMoney(ac, "2222", 100)
            );

            Console.Read();
        }
    }
}
