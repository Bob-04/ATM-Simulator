﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KMA.MOOP.ATM.Client.ATMClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IATMSimulator")]
    public interface IATMSimulator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/LoginAccount", ReplyAction="http://tempuri.org/IATMSimulator/LoginAccountResponse")]
        void LoginAccount(string num, string pas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/LoginAccount", ReplyAction="http://tempuri.org/IATMSimulator/LoginAccountResponse")]
        System.Threading.Tasks.Task LoginAccountAsync(string num, string pas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/WithdrawMoney", ReplyAction="http://tempuri.org/IATMSimulator/WithdrawMoneyResponse")]
        void WithdrawMoney(KMA.MOOP.ATM.DBModels.Account acc, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/WithdrawMoney", ReplyAction="http://tempuri.org/IATMSimulator/WithdrawMoneyResponse")]
        System.Threading.Tasks.Task WithdrawMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/AddMoney", ReplyAction="http://tempuri.org/IATMSimulator/AddMoneyResponse")]
        void AddMoney(KMA.MOOP.ATM.DBModels.Account acc, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/AddMoney", ReplyAction="http://tempuri.org/IATMSimulator/AddMoneyResponse")]
        System.Threading.Tasks.Task AddMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/Transfer", ReplyAction="http://tempuri.org/IATMSimulator/TransferResponse")]
        void Transfer(KMA.MOOP.ATM.DBModels.Account from, KMA.MOOP.ATM.DBModels.Account to, uint amount);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IATMSimulator/Transfer", ReplyAction="http://tempuri.org/IATMSimulator/TransferResponse")]
        System.Threading.Tasks.Task TransferAsync(KMA.MOOP.ATM.DBModels.Account from, KMA.MOOP.ATM.DBModels.Account to, uint amount);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IATMSimulatorChannel : KMA.MOOP.ATM.Client.ATMClient.ServiceReference1.IATMSimulator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ATMSimulatorClient : System.ServiceModel.ClientBase<KMA.MOOP.ATM.Client.ATMClient.ServiceReference1.IATMSimulator>, KMA.MOOP.ATM.Client.ATMClient.ServiceReference1.IATMSimulator {
        
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
        
        public void LoginAccount(string num, string pas) {
            base.Channel.LoginAccount(num, pas);
        }
        
        public System.Threading.Tasks.Task LoginAccountAsync(string num, string pas) {
            return base.Channel.LoginAccountAsync(num, pas);
        }
        
        public void WithdrawMoney(KMA.MOOP.ATM.DBModels.Account acc, uint amount) {
            base.Channel.WithdrawMoney(acc, amount);
        }
        
        public System.Threading.Tasks.Task WithdrawMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, uint amount) {
            return base.Channel.WithdrawMoneyAsync(acc, amount);
        }
        
        public void AddMoney(KMA.MOOP.ATM.DBModels.Account acc, uint amount) {
            base.Channel.AddMoney(acc, amount);
        }
        
        public System.Threading.Tasks.Task AddMoneyAsync(KMA.MOOP.ATM.DBModels.Account acc, uint amount) {
            return base.Channel.AddMoneyAsync(acc, amount);
        }
        
        public void Transfer(KMA.MOOP.ATM.DBModels.Account from, KMA.MOOP.ATM.DBModels.Account to, uint amount) {
            base.Channel.Transfer(from, to, amount);
        }
        
        public System.Threading.Tasks.Task TransferAsync(KMA.MOOP.ATM.DBModels.Account from, KMA.MOOP.ATM.DBModels.Account to, uint amount) {
            return base.Channel.TransferAsync(from, to, amount);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IBankAdministratorSimulator")]
    public interface IBankAdministratorSimulator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/RegisterClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/RegisterClientResponse")]
        void RegisterClient(KMA.MOOP.ATM.DBModels.Client cl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/RegisterClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/RegisterClientResponse")]
        System.Threading.Tasks.Task RegisterClientAsync(KMA.MOOP.ATM.DBModels.Client cl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/AddAccount", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/AddAccountResponse")]
        void AddAccount(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/AddAccount", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/AddAccountResponse")]
        System.Threading.Tasks.Task AddAccountAsync(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/EditClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/EditClientResponse")]
        void EditClient(KMA.MOOP.ATM.DBModels.Client oldCl, KMA.MOOP.ATM.DBModels.Client newCl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBankAdministratorSimulator/EditClient", ReplyAction="http://tempuri.org/IBankAdministratorSimulator/EditClientResponse")]
        System.Threading.Tasks.Task EditClientAsync(KMA.MOOP.ATM.DBModels.Client oldCl, KMA.MOOP.ATM.DBModels.Client newCl);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBankAdministratorSimulatorChannel : KMA.MOOP.ATM.Client.ATMClient.ServiceReference1.IBankAdministratorSimulator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BankAdministratorSimulatorClient : System.ServiceModel.ClientBase<KMA.MOOP.ATM.Client.ATMClient.ServiceReference1.IBankAdministratorSimulator>, KMA.MOOP.ATM.Client.ATMClient.ServiceReference1.IBankAdministratorSimulator {
        
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
        
        public void RegisterClient(KMA.MOOP.ATM.DBModels.Client cl) {
            base.Channel.RegisterClient(cl);
        }
        
        public System.Threading.Tasks.Task RegisterClientAsync(KMA.MOOP.ATM.DBModels.Client cl) {
            return base.Channel.RegisterClientAsync(cl);
        }
        
        public void AddAccount(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc) {
            base.Channel.AddAccount(cl, acc);
        }
        
        public System.Threading.Tasks.Task AddAccountAsync(KMA.MOOP.ATM.DBModels.Client cl, KMA.MOOP.ATM.DBModels.Account acc) {
            return base.Channel.AddAccountAsync(cl, acc);
        }
        
        public void EditClient(KMA.MOOP.ATM.DBModels.Client oldCl, KMA.MOOP.ATM.DBModels.Client newCl) {
            base.Channel.EditClient(oldCl, newCl);
        }
        
        public System.Threading.Tasks.Task EditClientAsync(KMA.MOOP.ATM.DBModels.Client oldCl, KMA.MOOP.ATM.DBModels.Client newCl) {
            return base.Channel.EditClientAsync(oldCl, newCl);
        }
    }
}