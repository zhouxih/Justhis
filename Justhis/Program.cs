using Autofac.Extensions.DependencyInjection;
using Autofac;
using Justhis.Utils;
using Justhis.InfrastructServiceCommom.DBHelper;
using Autofac.Core;
using Microsoft.OpenApi.Models;

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
            //注册DBContext

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "ASP.NET Core 8.0 Web API"
                });
            });
            //注册服务

            //注册EFCoreContext

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty; // 设置 Swagger UI 在应用根路径
            });
            app.MapControllers();

            app.Run();
        }
    }
}
