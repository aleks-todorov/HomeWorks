﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.6407
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="ICounter")]
public interface ICounter
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICounter/GetData", ReplyAction="http://tempuri.org/ICounter/GetDataResponse")]
    int GetData(string substring, string word);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface ICounterChannel : ICounter, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class CounterClient : System.ServiceModel.ClientBase<ICounter>, ICounter
{
    
    public CounterClient()
    {
    }
    
    public CounterClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public CounterClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CounterClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public CounterClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int GetData(string substring, string word)
    {
        return base.Channel.GetData(substring, word);
    }
}
