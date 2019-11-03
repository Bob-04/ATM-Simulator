using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KMA.MOOP.ATM.DBModels
{
    [Table("Clients")]
    public class Client : IDBModel
    {
        private Guid _guid;
        private long _identificationCode;
        private string _password;
        private string _phone;
        private string _firstName;
        private string _lastName;
        private List<Account> _accounts;

        #region Properties

        [Key, Column("Id")]
        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }

        public long IdentificationCode
        {
            get => _identificationCode;
            set => _identificationCode = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public virtual List<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        #endregion

        public Client(long identificationCode, string firstName, string lastName, 
            string phone, string password) : this()
        {
            _identificationCode = identificationCode;
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;

            SetPassword(password);
        }

        private Client()
        {
            _guid = Guid.NewGuid();
            _accounts = new List<Account>();
        }

        private void SetPassword(string password)
        {
            //TODO Add encription
            _password = password;
        }

        public bool CheckPassword(string password)
        {
            //TODO Compare encrypted passwords
            return _password == password;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
