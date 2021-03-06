﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DesktopClient.BedroomService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BedroomService.IBedroomService")]
    public interface IBedroomService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/GetAll", ReplyAction="http://tempuri.org/IBedroomService/GetAllResponse")]
        DomainModel.DataContracts.BedroomDto[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/GetAll", ReplyAction="http://tempuri.org/IBedroomService/GetAllResponse")]
        System.Threading.Tasks.Task<DomainModel.DataContracts.BedroomDto[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/GetAvailable", ReplyAction="http://tempuri.org/IBedroomService/GetAvailableResponse")]
        DomainModel.DataContracts.BedroomDto[] GetAvailable();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/GetAvailable", ReplyAction="http://tempuri.org/IBedroomService/GetAvailableResponse")]
        System.Threading.Tasks.Task<DomainModel.DataContracts.BedroomDto[]> GetAvailableAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/CreateOrUpdate", ReplyAction="http://tempuri.org/IBedroomService/CreateOrUpdateResponse")]
        bool CreateOrUpdate(DomainModel.DataContracts.BedroomDto bedroomDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/CreateOrUpdate", ReplyAction="http://tempuri.org/IBedroomService/CreateOrUpdateResponse")]
        System.Threading.Tasks.Task<bool> CreateOrUpdateAsync(DomainModel.DataContracts.BedroomDto bedroomDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/Remove", ReplyAction="http://tempuri.org/IBedroomService/RemoveResponse")]
        bool Remove(DomainModel.DataContracts.BedroomDto bedroomDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBedroomService/Remove", ReplyAction="http://tempuri.org/IBedroomService/RemoveResponse")]
        System.Threading.Tasks.Task<bool> RemoveAsync(DomainModel.DataContracts.BedroomDto bedroomDto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBedroomServiceChannel : DesktopClient.BedroomService.IBedroomService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BedroomServiceClient : System.ServiceModel.ClientBase<DesktopClient.BedroomService.IBedroomService>, DesktopClient.BedroomService.IBedroomService {
        
        public BedroomServiceClient() {
        }
        
        public BedroomServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BedroomServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BedroomServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BedroomServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DomainModel.DataContracts.BedroomDto[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<DomainModel.DataContracts.BedroomDto[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public DomainModel.DataContracts.BedroomDto[] GetAvailable() {
            return base.Channel.GetAvailable();
        }
        
        public System.Threading.Tasks.Task<DomainModel.DataContracts.BedroomDto[]> GetAvailableAsync() {
            return base.Channel.GetAvailableAsync();
        }
        
        public bool CreateOrUpdate(DomainModel.DataContracts.BedroomDto bedroomDto) {
            return base.Channel.CreateOrUpdate(bedroomDto);
        }
        
        public System.Threading.Tasks.Task<bool> CreateOrUpdateAsync(DomainModel.DataContracts.BedroomDto bedroomDto) {
            return base.Channel.CreateOrUpdateAsync(bedroomDto);
        }
        
        public bool Remove(DomainModel.DataContracts.BedroomDto bedroomDto) {
            return base.Channel.Remove(bedroomDto);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveAsync(DomainModel.DataContracts.BedroomDto bedroomDto) {
            return base.Channel.RemoveAsync(bedroomDto);
        }
    }
}
