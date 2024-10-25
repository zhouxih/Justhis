using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justhis.InfrastructServiceCommom.DBHelper
{
    public static class DBContextInit
    {
        public static void RegisterDBContext(this IServiceCollection services,string connectionStr) 
        {
            services.AddAllDbContexts(ctx =>
            {
                //连接字符串如果放到appsettings.json中，会有泄密的风险
                //如果放到UserSecrets中，每个项目都要配置，很麻烦
                //因此这里推荐放到环境变量中。
                ctx.UseSqlServer(connectionStr);
            });
        }
    }
}
