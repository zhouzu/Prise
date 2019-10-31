using System;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prise.Infrastructure;
using SQLPlugin.Configuration;

namespace SQLPlugin
{
    [PluginBootstrapper(PluginType = typeof(SqlProductsRepository))]
    public class SqlPluginBootstrapper : IPluginBootstrapper
    {
        public IServiceCollection Bootstrap(IServiceCollection services)
        {
            var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var sqlConfig = new SQLPluginConfig();
            config.Bind("SQLPlugin", sqlConfig);
            Console.WriteLine($"CONNECTION STRING : {sqlConfig.ConnectionString}");
            
            services.AddScoped<DbConnection>((serviceProvider) =>
            {
                var dbConnection = new SqlConnection(sqlConfig.ConnectionString);
                dbConnection.Open();
                return dbConnection;
            });

            services.AddScoped<DbContextOptions>((serviceProvider) =>
            {
                var dbConnection = serviceProvider.GetService<DbConnection>();
                return new DbContextOptionsBuilder<ProductsDbContext>()
                    .UseSqlServer(dbConnection)
                    .Options;
            });

            services.AddScoped<ProductsDbContext>((serviceProvider) =>
            {
                var options = serviceProvider.GetService<DbContextOptions>();
                var context = new ProductsDbContext(options);
                return context;
            });

            return services;
        }
    }
}