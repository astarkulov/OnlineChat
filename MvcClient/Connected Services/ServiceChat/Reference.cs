﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcClient.ServiceChat {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/OnlineChat.DomainModel.Common")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ColorOfNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string ColorOfName {
            get {
                return this.ColorOfNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ColorOfNameField, value) != true)) {
                    this.ColorOfNameField = value;
                    this.RaisePropertyChanged("ColorOfName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Chat", Namespace="http://schemas.datacontract.org/2004/07/OnlineChat.DomainModel.Common")]
    [System.SerializableAttribute()]
    public partial class Chat : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime SendTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SenderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private MvcClient.ServiceChat.User UserField;
        
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
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SendTime {
            get {
                return this.SendTimeField;
            }
            set {
                if ((this.SendTimeField.Equals(value) != true)) {
                    this.SendTimeField = value;
                    this.RaisePropertyChanged("SendTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SenderId {
            get {
                return this.SenderIdField;
            }
            set {
                if ((this.SenderIdField.Equals(value) != true)) {
                    this.SenderIdField = value;
                    this.RaisePropertyChanged("SenderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public MvcClient.ServiceChat.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceChat.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUsers", ReplyAction="http://tempuri.org/IService1/GetUsersResponse")]
        MvcClient.ServiceChat.User[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUsers", ReplyAction="http://tempuri.org/IService1/GetUsersResponse")]
        System.Threading.Tasks.Task<MvcClient.ServiceChat.User[]> GetUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetChats", ReplyAction="http://tempuri.org/IService1/GetChatsResponse")]
        MvcClient.ServiceChat.Chat[] GetChats();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetChats", ReplyAction="http://tempuri.org/IService1/GetChatsResponse")]
        System.Threading.Tasks.Task<MvcClient.ServiceChat.Chat[]> GetChatsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Connect", ReplyAction="http://tempuri.org/IService1/ConnectResponse")]
        bool Connect(string Name, string color);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Connect", ReplyAction="http://tempuri.org/IService1/ConnectResponse")]
        System.Threading.Tasks.Task<bool> ConnectAsync(string Name, string color);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendMsg", ReplyAction="http://tempuri.org/IService1/SendMsgResponse")]
        void SendMsg(string SenderName, string Content, System.DateTime SendTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendMsg", ReplyAction="http://tempuri.org/IService1/SendMsgResponse")]
        System.Threading.Tasks.Task SendMsgAsync(string SenderName, string Content, System.DateTime SendTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : MvcClient.ServiceChat.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<MvcClient.ServiceChat.IService1>, MvcClient.ServiceChat.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MvcClient.ServiceChat.User[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        public System.Threading.Tasks.Task<MvcClient.ServiceChat.User[]> GetUsersAsync() {
            return base.Channel.GetUsersAsync();
        }
        
        public MvcClient.ServiceChat.Chat[] GetChats() {
            return base.Channel.GetChats();
        }
        
        public System.Threading.Tasks.Task<MvcClient.ServiceChat.Chat[]> GetChatsAsync() {
            return base.Channel.GetChatsAsync();
        }
        
        public bool Connect(string Name, string color) {
            return base.Channel.Connect(Name, color);
        }
        
        public System.Threading.Tasks.Task<bool> ConnectAsync(string Name, string color) {
            return base.Channel.ConnectAsync(Name, color);
        }
        
        public void SendMsg(string SenderName, string Content, System.DateTime SendTime) {
            base.Channel.SendMsg(SenderName, Content, SendTime);
        }
        
        public System.Threading.Tasks.Task SendMsgAsync(string SenderName, string Content, System.DateTime SendTime) {
            return base.Channel.SendMsgAsync(SenderName, Content, SendTime);
        }
    }
}
