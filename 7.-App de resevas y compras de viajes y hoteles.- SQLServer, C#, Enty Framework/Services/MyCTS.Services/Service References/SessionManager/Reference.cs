﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCTS.Services.SessionManager {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LogonRequestData", Namespace="http://schemas.navitaire.com/WebServices/DataContracts/Session")]
    [System.SerializableAttribute()]
    public partial class LogonRequestData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DomainCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AgentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TerminalInfoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DomainCode {
            get {
                return this.DomainCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.DomainCodeField, value) != true)) {
                    this.DomainCodeField = value;
                    this.RaisePropertyChanged("DomainCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string AgentName {
            get {
                return this.AgentNameField;
            }
            set {
                if ((object.ReferenceEquals(this.AgentNameField, value) != true)) {
                    this.AgentNameField = value;
                    this.RaisePropertyChanged("AgentName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string LocationCode {
            get {
                return this.LocationCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationCodeField, value) != true)) {
                    this.LocationCodeField = value;
                    this.RaisePropertyChanged("LocationCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string RoleCode {
            get {
                return this.RoleCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleCodeField, value) != true)) {
                    this.RoleCodeField = value;
                    this.RaisePropertyChanged("RoleCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string TerminalInfo {
            get {
                return this.TerminalInfoField;
            }
            set {
                if ((object.ReferenceEquals(this.TerminalInfoField, value) != true)) {
                    this.TerminalInfoField = value;
                    this.RaisePropertyChanged("TerminalInfo");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SessionManager.IIJSessionManager")]
    public interface IIJSessionManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIJSessionManager/CloseSession", ReplyAction="http://tempuri.org/IIJSessionManager/CloseSessionResponse")]
        string CloseSession(string signature);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIJSessionManager/GetSessionID", ReplyAction="http://tempuri.org/IIJSessionManager/GetSessionIDResponse")]
        string GetSessionID();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIJSessionManager/Test", ReplyAction="http://tempuri.org/IIJSessionManager/TestResponse")]
        string Test();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIJSessionManager/Logon", ReplyAction="http://tempuri.org/IIJSessionManager/LogonResponse")]
        string Logon(int contract, MyCTS.Services.SessionManager.LogonRequestData request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IIJSessionManager/Logout", ReplyAction="http://tempuri.org/IIJSessionManager/LogoutResponse")]
        void Logout(int contract, string signature);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IIJSessionManagerChannel : MyCTS.Services.SessionManager.IIJSessionManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IJSessionManagerClient : System.ServiceModel.ClientBase<MyCTS.Services.SessionManager.IIJSessionManager>, MyCTS.Services.SessionManager.IIJSessionManager {
        
        public IJSessionManagerClient() {
        }
        
        public IJSessionManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IJSessionManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IJSessionManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IJSessionManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string CloseSession(string signature) {
            return base.Channel.CloseSession(signature);
        }
        
        public string GetSessionID() {
            return base.Channel.GetSessionID();
        }
        
        public string Test() {
            return base.Channel.Test();
        }
        
        public string Logon(int contract, MyCTS.Services.SessionManager.LogonRequestData request) {
            return base.Channel.Logon(contract, request);
        }
        
        public void Logout(int contract, string signature) {
            base.Channel.Logout(contract, signature);
        }
    }
}
