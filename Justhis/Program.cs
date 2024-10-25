using Autofac.Extensions.DependencyInjection;
using Autofac;
using Justhis.Utils;
using Justhis.InfrastructServiceCommom.DBHelper;
using Autofac.Core;

namespace Justhis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterModule<ServicesInitModule>();
            });

            var connectStr = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.RegisterDBContext(connectStr);
            //×¢²áDBContext

            builder.Services.AddControllers();

            //×¢²á·þÎñ

            //×¢²áEFCoreContext

            var app = builder.Build();

            

            app.MapControllers();

            app.Run();
        }
    }
}
