using Autofac;
using SampleArch.Helpers.Domain;
using System.Linq;
using System.Reflection;

namespace SampleArch.App_Start
{
    public class EventHandlerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var list = builder.RegisterAssemblyTypes(Assembly.Load("SampleArch"))
                   .Where(t => t.Name.EndsWith("Handler"));

            builder.RegisterAssemblyTypes(Assembly.Load("SampleArch"))
                    .Where(t => !t.IsAbstract && t.GetInterfaces().Any(i=> i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IDomainHandler<>))))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }

}