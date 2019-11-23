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

            Console.WriteLine(
                admin.AddAccount(client, new Account("12345678", "2228", AccountType.BonusAccount))
            );

            ATMClient atmClient = new ATMClient();
            Account ac = atmClient.LoginAccount("12345678", "2228");
            atmClient.BlockAccount(ac);

            Console.Read();
        }
    }
}
