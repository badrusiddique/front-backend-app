using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Data;

namespace Sample.Api.Installers
{
    public class DatabaseInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var sqlConnection = new SqliteConnection(configuration.GetConnectionString("sqlConnection"));

            services
                .AddEntityFrameworkSqlite()
                .AddDbContext<DatabaseContext>(
                opts => opts.UseSqlite(sqlConnection)
            );
        }
    }
}