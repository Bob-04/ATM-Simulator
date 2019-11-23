﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KMA.MOOP.ATM.Client.AdminClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IATMSimulator")]
    public interface IATMSimulator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/LoginAccount", ReplyAction="http://tempuri.org/IATMSimulator/LoginAccountResponse")]
        KMA.MOOP.ATM.DBModels.Account LoginAccount(string num, string pin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/LoginAccount", ReplyAction="http://tempuri.org/IATMSimulator/LoginAccountResponse")]
        System.Threading.Tasks.Task<KMA.MOOP.ATM.DBModels.Account> LoginAccountAsync(string num, string pin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/AddMoney", ReplyAction="http://tempuri.org/IATMSimulator/AddMoneyResponse")]
        string AddMoney(KMA.MOOP.ATM.DBModels.Account acc, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/AddMoney", ReplyAction="http://tempuri.org/IATMSimulator/AddMoneyResponse")]
        System.Threading.Tasks.Task<string> AddMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/WithdrawMoney", ReplyAction="http://tempuri.org/IATMSimulator/WithdrawMoneyResponse")]
        string WithdrawMoney(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/WithdrawMoney", ReplyAction="http://tempuri.org/IATMSimulator/WithdrawMoneyResponse")]
        System.Threading.Tasks.Task<string> WithdrawMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/CashSurplusProcessing", ReplyAction="http://tempuri.org/IATMSimulator/CashSurplusProcessingResponse")]
        string CashSurplusProcessing(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint maxBalance, string surplusesNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/CashSurplusProcessing", ReplyAction="http://tempuri.org/IATMSimulator/CashSurplusProcessingResponse")]
        System.Threading.Tasks.Task<string> CashSurplusProcessingAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint maxBalance, string surplusesNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/LimitExceedingProtection", ReplyAction="http://tempuri.org/IATMSimulator/LimitExceedingProtectionResponse")]
        string LimitExceedingProtection(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint minBalance, string securityNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/LimitExceedingProtection", ReplyAction="http://tempuri.org/IATMSimulator/LimitExceedingProtectionResponse")]
        System.Threading.Tasks.Task<string> LimitExceedingProtectionAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint minBalance, string securityNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/AddTransaction", ReplyAction="http://tempuri.org/IATMSimulator/AddTransactionResponse")]
        string AddTransaction(KMA.MOOP.ATM.DBModels.Account acc, string pin, string recipientNumber, uint amount, System.DateTime startTime, System.Nullable<double> daysPeriod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/AddTransaction", ReplyAction="http://tempuri.org/IATMSimulator/AddTransactionResponse")]
        System.Threading.Tasks.Task<string> AddTransactionAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, string recipientNumber, uint amount, System.DateTime startTime, System.Nullable<double> daysPeriod);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/BlockAccount", ReplyAction="http://tempuri.org/IATMSimulator/BlockAccountResponse")]
        string BlockAccount(KMA.MOOP.ATM.DBModels.Account acc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/BlockAccount", ReplyAction="http://tempuri.org/IATMSimulator/BlockAccountResponse")]
        System.Threading.Tasks.Task<string> BlockAccountAsync(KMA.MOOP.ATM.DBModels.Account acc);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IATMSimulatorChannel : KMA.MOOP.ATM.Client.AdminClient.ServiceReference1.IATMSimulator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ATMSimulatorClient : System.ServiceModel.ClientBase<KMA.MOOP.ATM.Client.AdminClient.ServiceReference1.IATMSimulator>, KMA.MOOP.ATM.Client.AdminClient.ServiceReference1.IATMSimulator {
        
        public ATMSimulatorClient() {
        }
        
        public ATMSimulatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ATMSimulatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ATMSimulatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ATMSimulatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public KMA.MOOP.ATM.DBModels.Account LoginAccount(string num, string pin) {
            return base.Channel.LoginAccount(num, pin);
        }
        
        public System.Threading.Tasks.Task<KMA.MOOP.ATM.DBModels.Account> LoginAccountAsync(string num, string pin) {
            return base.Channel.LoginAccountAsync(num, pin);
        }
        
        public string AddMoney(KMA.MOOP.ATM.DBModels.Account acc, uint amount) {
            return base.Channel.AddMoney(acc, amount);
        }
        
        public System.Threading.Tasks.Task<string> AddMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, uint amount) {
            return base.Channel.AddMoneyAsync(acc, amount);
        }
        
        public string WithdrawMoney(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint amount) {
            return base.Channel.WithdrawMoney(acc, pin, amount);
        }
        
        public System.Threading.Tasks.Task<string> WithdrawMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint amount) {
            return base.Channel.WithdrawMoneyAsync(acc, pin, amount);
        }
        
        public string CashSurplusProcessing(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint maxBalance, string surplusesNumber) {
            return base.Channel.CashSurplusProcessing(acc, pin, maxBalance, surplusesNumber);
        }
        
        public System.Threading.Tasks.Task<string> CashSurplusProcessingAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint maxBalance, string surplusesNumber) {
            return base.Channel.CashSurplusProcessingAsync(acc, pin, maxBalance, surplusesNumber);
        }
        
        public string LimitExceedingProtection(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint minBalance, string securityNumber) {
            return base.Channel.LimitExceedingProtection(acc, pin, minBalance, securityNumber);
        }
        
        public System.Threading.Tasks.Task<string> LimitExceedingProtectionAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, uint minBalance, string securityNumber) {
            return base.Channel.LimitExceedingProtectionAsync(acc, pin, minBalance, securityNumber);
        }
        
        public string AddTransaction(KMA.MOOP.ATM.DBModels.Account acc, string pin, string recipientNumber, uint amount, System.DateTime startTime, System.Nullable<double> daysPeriod) {
            return base.Channel.AddTransaction(acc, pin, recipientNumber, amount, startTime, daysPeriod);
        }
        
        public System.Threading.Tasks.Task<string> AddTransactionAsync(KMA.MOOP.ATM.DBModels.Account acc, string pin, string recipientNumber, uint amount, System.DateTime startTime, System.Nullable<double> daysPeriod) {
            return base.Channel.AddTransactionAsync(acc, pin, recipientNumber, amount, startTime, daysPeriod);
        }
        
        public string BlockAccount(KMA.MOOP.ATM.DBModels.Account acc) {
            return base.Channel.BlockAccount(acc);
        }
        
        public System.Threading.Tasks.Task<string> BlockAccountAsync(KMA.MOOP.ATM.DBModels.Account acc) {
            return base.Channel.BlockAccountAsync(acc);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IBankAdministratorSimulator")]
    public interface IBankAdministratorSimulator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/RegisterClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/RegisterClientResponse")]
        string RegisterClient(KMA.MOOP.ATM.DBModels.Client cl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/RegisterClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/RegisterClientResponse")]
        System.Threading.Tasks.Task<string> RegisterClientAsync(KMA.MOOP.ATM.DBModels.Client cl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/GetClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/GetClientResponse")]
        KMA.MOOP.ATM.DBModels.Client GetClient(long identificationCode, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/GetClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/GetClientResponse")]
        System.Threading.Tasks.Task<KMA.MOOP.ATM.DBModels.Client> GetClientAsync(long identificationCode, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/AddAccount", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/AddAccountResponse")]
        string AddAccount(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/AddAccount", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/AddAccountResponse")]
        System.Threading.Tasks.Task<string> AddAccountAsync(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/UnblockAccount", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/UnblockAccountResponse")]
        string UnblockAccount(KMA.MOOP.ATM.DBModels.Client cl, string accNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/UnblockAccount", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/UnblockAccountResponse")]
        System.Threading.Tasks.Task<string> UnblockAccountAsync(KMA.MOOP.ATM.DBModels.Client cl, string accNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankAdministratorSimulatorChannel : KMA.MOOP.ATM.Client.AdminClient.ServiceReference1.IBankAdministratorSimulator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankAdministratorSimulatorClient : System.ServiceModel.ClientBase<KMA.MOOP.ATM.Client.AdminClient.ServiceReference1.IBankAdministratorSimulator>, KMA.MOOP.ATM.Client.AdminClient.ServiceReference1.IBankAdministratorSimulator {
        
        public BankAdministratorSimulatorClient() {
        }
        
        public BankAdministratorSimulatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BankAdministratorSimulatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankAdministratorSimulatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BankAdministratorSimulatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string RegisterClient(KMA.MOOP.ATM.DBModels.Client cl) {
            return base.Channel.RegisterClient(cl);
        }
        
        public System.Threading.Tasks.Task<string> RegisterClientAsync(KMA.MOOP.ATM.DBModels.Client cl) {
            return base.Channel.RegisterClientAsync(cl);
        }
        
        public KMA.MOOP.ATM.DBModels.Client GetClient(long identificationCode, string password) {
            return base.Channel.GetClient(identificationCode, password);
        }
        
        public System.Threading.Tasks.Task<KMA.MOOP.ATM.DBModels.Client> GetClientAsync(long identificationCode, string password) {
            return base.Channel.GetClientAsync(identificationCode, password);
        }
        
        public string AddAccount(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc) {
            return base.Channel.AddAccount(cl, acc);
        }
        
        public System.Threading.Tasks.Task<string> AddAccountAsync(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc) {
            return base.Channel.AddAccountAsync(cl, acc);
        }
        
        public string UnblockAccount(KMA.MOOP.ATM.DBModels.Client cl, string accNumber) {
            return base.Channel.UnblockAccount(cl, accNumber);
        }
        
        public System.Threading.Tasks.Task<string> UnblockAccountAsync(KMA.MOOP.ATM.DBModels.Client cl, string accNumber) {
            return base.Channel.UnblockAccountAsync(cl, accNumber);
        }
    }
}
