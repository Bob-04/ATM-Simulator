using KMA.MOOP.ATM.EntityFrameworkWrapper;

namespace KMA.MOOP.ATM.Server.Processors
{
    internal class TransactionProcessor
    {
        private TransactionProcessor()
        {
            var db = new DBImpl();

            db.ExecuteTransactions();
        }

        public static void Main(string[] args)
        {
            new TransactionProcessor();
        }
    }
}
