using Autofac.Core;
using Autofac;
using System.Reflection;

namespace Justhis.Utils
{
    public class ServicesInitModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册领域服务和仓储服务
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
            .Where(t => t.Name.EndsWith("Repository") || t.Name.EndsWith("AppService"))
            .AsImplementedInterfaces();
        }
    }
}
