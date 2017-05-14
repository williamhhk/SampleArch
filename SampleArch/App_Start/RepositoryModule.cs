using Autofac;
using System.Linq;
using System.Reflection;

namespace SampleArch.App_Start
{

    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var list = builder.RegisterAssemblyTypes(Assembly.Load("SampleArch.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"));

            builder.RegisterAssemblyTypes(Assembly.Load("SampleArch.Repository"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }
    }
}