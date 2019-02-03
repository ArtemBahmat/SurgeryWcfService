using BLL.Services;
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using BLL.Interfaces;
using TestLibrary.Services;
using Unity;

namespace WcfService
{
    public abstract class UnityServiceHostFactory : ServiceHostFactory
    {
        protected abstract void ConfigureContainer(IUnityContainer container);

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var container = new UnityContainer();

            ConfigureContainer(container);

            container.RegisterType<IRequisitionService, RequisitionService>();
            container.RegisterType<ISurgeryWcfService, SurgeryWcfService>();
            container.RegisterType<ISurgeryService, SurgeryService>();
            container.RegisterType<IClientService, ClientService>();
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<ISysStateService, SysStateService>();

            return new UnityServiceHost(container, serviceType, baseAddresses);
        }
    }
}