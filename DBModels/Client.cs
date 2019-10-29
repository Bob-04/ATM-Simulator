using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KMA.MOOP.ATM.DBModels
{
    public class Client : IDBModel
    {
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _firstName;
        [DataMember]
        private string _lastName;
        [DataMember]
        private string _phone;
        [DataMember]
        private string _password;
        [DataMember]
        private List<Account> _accounts;

        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }
        public string FirstName
        {
            get => _firstName;
            private set => _firstName = value;
        }
        public string LastName
        {
            get => _lastName;
            private set => _lastName = value;
        }
        public string Phone
        {
            get => _phone;
            private set => _phone = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public virtual List<Account> Accounts
        {
            get => _accounts;
            set => _accounts = value;
        }

        public Client(string firstName, string lastName, string phone, string password) : this()
        {
            _guid = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
            SetPassword(password);
        }

        public Client()
        {
            _accounts = new List<Account>();
        }

        private void SetPassword(string password)
        {
            //TODO Add encription
            _password = password;
        }

        internal bool CheckPassword(string password)
        {
            //TODO Compare encrypted passwords
            return _password == password;
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
