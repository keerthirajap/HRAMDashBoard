using Autofac;
using ServiceConcrete;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjecionResolver
{
    public class ServiceDIContainer : Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<StoreServerService>().As<IStoreServerService>().InstancePerLifetimeScope();
            builder.RegisterType<DashBoardService>().As<IDashBoardService>().InstancePerLifetimeScope();

            // base.Load(builder);
        }
    }
}
