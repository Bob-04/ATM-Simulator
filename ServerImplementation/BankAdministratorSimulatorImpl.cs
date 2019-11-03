using System.Linq;
using KMA.MOOP.ATM.DBModels;
using KMA.MOOP.ATM.EntityFrameworkWrapper;
using KMA.MOOP.ATM.Server.Interface;

namespace KMA.MOOP.ATM.Server.Implementation
{
    public class BankAdministratorSimulatorImpl :IBankAdministratorSimulator
    {
        public string RegisterClient(Client cl)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Clients.Add(cl);

                try
                {
                    db.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    return "Client with the same Identification Code or Phone already contains";
                }

                return $"Client {cl} successfully registered";
            }
        }

        public Client GetClient(long identificationCode, string password)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Clients.FirstOrDefault(
                    cl => cl.IdentificationCode == identificationCode && cl.CheckPassword(password));
            }
        }

        public string AddAccount(Client cl, Account acc)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Client dbClient;
                if (cl == null || (dbClient = db.Clients.FirstOrDefault(
                        c => c.IdentificationCode == cl.IdentificationCode &&
                             c.CheckPassword(cl.Password))) == null)
                    return $"Client {cl} doesn't exist";

                dbClient.Accounts.Add(acc);

                try
                {
                    db.SaveChanges();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                {
                    return $"Card number {acc} already contains";
                }
            }
            return $"Account successfully added to client {cl}";
        }
    }
}
