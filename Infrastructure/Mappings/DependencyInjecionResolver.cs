using Autofac;
using ServiceConcrete;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class ServiceDIContainer : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<StoreServerService>().As<IStoreServerService>().InstancePerLifetimeScope();


            // base.Load(builder);
        }
    }
}
