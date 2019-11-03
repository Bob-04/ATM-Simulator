using System;
using KMA.MOOP.ATM.Client.AdminClient;
using KMA.MOOP.ATM.DBModels;

namespace TesterFromConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AdminClient admin = new AdminClient();

            Client client = new Client(1429,
                "Vova", "O", "+380667577145", "-1");

            Console.WriteLine(
                admin.RegisterClient(client)
            );


            Client cl = admin.GetClient(1429, "-1");

            Console.WriteLine(
                admin.AddAccount(cl, new Account("12345677", "2222", AccountType.BonusAccount))
            );

            Console.Read();
        }
    }
}
