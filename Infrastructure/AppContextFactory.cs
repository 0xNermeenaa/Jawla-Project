using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infrastructure
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppContext>
    {
        public AppContext CreateDbContext(string[] args)
        {
            // Use the current directory if appsettings.json is in the folder where the command is run
            //var basePath = Directory.GetCurrentDirectory();

            // Alternatively, if you need to go to the API folder, use:
             var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "API");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("DefaultConnection connection string is missing in appsettings.json");
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new AppContext(optionsBuilder.Options);
        }
    }
}
