using System;
using System.Runtime.Serialization;

namespace KMA.MOOP.ATM.DBModels
{
    public enum AccountType
    {
        CalculatedAccount = 0,
        CreditAccount,
        BonusAccount
    }

    [DataContract(IsReference = true)]
    public class Account
    {
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _number;
        [DataMember]
        private string _pin;
        [DataMember]
        private uint _amountMoney;
        [DataMember]
        private AccountType _accountType;
        [DataMember]
        private Guid _ownerGuid;
        [DataMember]
        private Client _owner;

        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
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

        public AccountType AccountType
        {
            get => _accountType;
            set => _accountType = value;
        }

        public int AccountTypeId
        {
            get => (int)_accountType;
            set => _accountType = (AccountType)value;
        }

        public virtual Client Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public Guid OwnerGuid
        {
            get => _ownerGuid;
            set => _ownerGuid = value;
        }

        public Account(string smth) : this()
        {
            _guid = Guid.NewGuid();
            _number = "0000 1242 1231 4324";
            _pin = "1234";
            _amountMoney = 0;
            _accountType = AccountType.CalculatedAccount;
        }

        public Account()
        {
        }
    }
}
