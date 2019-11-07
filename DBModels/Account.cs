using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KMA.MOOP.ATM.DBModels
{
    public enum AccountType
    {
        CalculatedAccount = 0,
        CreditAccount,
        BonusAccount
    }

    [Table("Accounts")]
    public class Account : IDBModel
    {
        private Guid _guid;
        private string _number;
        private string _pin;
        private uint _balance;
        private AccountType _accountType;
        // Cash Surplus Processing
        private uint _maxBalance;
        private Guid _surplusesAccountGuid;
        // Limit Exceeding Protection
        private uint _minBalance;
        private Guid _securityAccountGuid;
        // Transactions
        private List<Transaction> _transactions;

        #region Properties

        [Key, Column("Id")]
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }

        public string Number
        {
            get => _number;
            set => _number = value;
        }

        public string Pin
        {
            get => _pin;
            set => _pin = value;
        }

        public uint Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public AccountType AccountType
        {
            get => _accountType;
            set => _accountType = value;
        }

        public uint MaxBalance
        {
            get => _maxBalance;
            set => _maxBalance = value;
        }

        public Guid SurplusesAccountGuid
        {
            get => _surplusesAccountGuid;
            set => _surplusesAccountGuid = value;
        }

        public uint MinBalance
        {
            get => _minBalance;
            set => _minBalance = value;
        }

        public Guid SecurityAccountGuid
        {
            get => _securityAccountGuid;
            set => _securityAccountGuid = value;
        }

        public virtual List<Transaction> Transactions
        {
            get => _transactions;
            private set => _transactions = value;
        }

        #endregion

        public Account(string number, string pin, AccountType type) : this()
        {
            _number = number;
            _pin = pin;
            _accountType = type;
        }

        private Account()
        {
            _guid = Guid.NewGuid();
            _balance = 0;

            _maxBalance = 0;
            _surplusesAccountGuid = Guid.Empty;
            _minBalance = 0;
            _securityAccountGuid = Guid.Empty;

            _transactions = new List<Transaction>();
        }

        public override string ToString()
        {
            return $"{Number}";
        }
    }
}
