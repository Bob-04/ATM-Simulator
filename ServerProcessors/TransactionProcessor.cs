using System.Threading;
using KMA.MOOP.ATM.EntityFrameworkWrapper;

namespace KMA.MOOP.ATM.Server.Processors
{
    internal class TransactionProcessor
    {
        private readonly DBImpl _db;
        private TransactionProcessor()
        {
            _db = new DBImpl();

            StartProcess();
        }

        private void StartProcess()
        {
            while (true)
            {
                _db.ExecuteTransactions();
                Thread.Sleep(3000);
            }
        }

        public static void Main(string[] args)
        {
            new TransactionProcessor();
        }
    }
}
