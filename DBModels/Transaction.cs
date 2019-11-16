using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KMA.MOOP.ATM.DBModels
{
    [Table("Transactions")]
    public class Transaction : IDBModel
    {
        private Guid _guid;
        private Guid _accountGuid;
        private Guid _recipientAccountGuid;
        private uint _amount;
        private DateTime _transactionTime;
        private DateTime? _period;

        [Key, Column("Id")]
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }

        public Guid AccountGuid
        {
            get => _accountGuid;
            private set => _accountGuid = value;
        }

        public Guid RecipientAccountGuid
        {
            get => _recipientAccountGuid;
            set => _recipientAccountGuid = value;
        }

        public uint Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public DateTime TransactionTime
        {
            get => _transactionTime;
            set => _transactionTime = value;
        }

        public DateTime? Period
        {
            get => _period;
            set => _period = value;
        }


        public Transaction(Guid accountGuid, Guid recipientAccountGuid, uint amount,
            DateTime startTime, DateTime? period) : this()
        {
            _accountGuid = accountGuid;
            _recipientAccountGuid = recipientAccountGuid;
            _amount = amount;
            _transactionTime = startTime;
            _period = period;
        }

        private Transaction()
        {
            _guid = Guid.NewGuid();
        }
    }
}
