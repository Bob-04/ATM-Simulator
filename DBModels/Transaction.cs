using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KMA.MOOP.ATM.DBModels
{
    [Table("Transactions")]
    public class Transaction : IDBModel
    {
        private Guid _guid;
        private Guid _recipientAccountGuid;
        private uint _amount;
        private DateTime _startTime;
        private DateTime? _period;

        [Key, Column("Id")]
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
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

        public DateTime StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        public DateTime? Period
        {
            get => _period;
            set => _period = value;
        }


        public Transaction(Guid recipientAccountGuid, uint amount, DateTime startTime, DateTime? period) : this()
        {
            _recipientAccountGuid = recipientAccountGuid;
            _amount = amount;
            _startTime = startTime;
            _period = period;
        }

        private Transaction()
        {
            _guid = Guid.NewGuid();
        }
    }
}
