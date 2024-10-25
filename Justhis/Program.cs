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
            //ע��DBContext

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
            //ע�����

            //ע��EFCoreContext

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty; // ���� Swagger UI ��Ӧ�ø�·��
            });
            app.MapControllers();

            app.Run();
        }
    }
}
