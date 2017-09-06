﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace MyCTS.Services.PrintVoucher {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="VoucherSoap", Namespace="http://tempuri.org/")]
    public partial class Voucher : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback EnviaVoucherOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendVoucherBancoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Voucher() {
            this.Url = global::MyCTS.Services.Properties.Settings.Default.MyCTS_Services_PrintVoucher_Voucher;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event EnviaVoucherCompletedEventHandler EnviaVoucherCompleted;
        
        /// <remarks/>
        public event SendVoucherBancoCompletedEventHandler SendVoucherBancoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EnviaVoucher", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void EnviaVoucher(string sReservacion, string sDestinatarios, int orgId) {
            this.Invoke("EnviaVoucher", new object[] {
                        sReservacion,
                        sDestinatarios,
                        orgId});
        }
        
        /// <remarks/>
        public void EnviaVoucherAsync(string sReservacion, string sDestinatarios, int orgId) {
            this.EnviaVoucherAsync(sReservacion, sDestinatarios, orgId, null);
        }
        
        /// <remarks/>
        public void EnviaVoucherAsync(string sReservacion, string sDestinatarios, int orgId, object userState) {
            if ((this.EnviaVoucherOperationCompleted == null)) {
                this.EnviaVoucherOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEnviaVoucherOperationCompleted);
            }
            this.InvokeAsync("EnviaVoucher", new object[] {
                        sReservacion,
                        sDestinatarios,
                        orgId}, this.EnviaVoucherOperationCompleted, userState);
        }
        
        private void OnEnviaVoucherOperationCompleted(object arg) {
            if ((this.EnviaVoucherCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EnviaVoucherCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendVoucherBanco", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SendVoucherBanco(string transaccion, int organizacionId, string from, string to, string asunto) {
            this.Invoke("SendVoucherBanco", new object[] {
                        transaccion,
                        organizacionId,
                        from,
                        to,
                        asunto});
        }
        
        /// <remarks/>
        public void SendVoucherBancoAsync(string transaccion, int organizacionId, string from, string to, string asunto) {
            this.SendVoucherBancoAsync(transaccion, organizacionId, from, to, asunto, null);
        }
        
        /// <remarks/>
        public void SendVoucherBancoAsync(string transaccion, int organizacionId, string from, string to, string asunto, object userState) {
            if ((this.SendVoucherBancoOperationCompleted == null)) {
                this.SendVoucherBancoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendVoucherBancoOperationCompleted);
            }
            this.InvokeAsync("SendVoucherBanco", new object[] {
                        transaccion,
                        organizacionId,
                        from,
                        to,
                        asunto}, this.SendVoucherBancoOperationCompleted, userState);
        }
        
        private void OnSendVoucherBancoOperationCompleted(object arg) {
            if ((this.SendVoucherBancoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendVoucherBancoCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void EnviaVoucherCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void SendVoucherBancoCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591