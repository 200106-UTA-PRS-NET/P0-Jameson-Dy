using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Domain
{
    public class ConfigBuilderSystem
    {
        private static readonly ConfigBuilderSystem instance = new ConfigBuilderSystem();
        private static DbContextOptions<PizzaBoxDbContext> options;

        static ConfigBuilderSystem() { }
        private ConfigBuilderSystem()
        {
            var configBuilder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                      IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxDb"));

            options = optionsBuilder.Options;
        }

        public static ConfigBuilderSystem Instance
        {
            get { return instance; }
        }

        public DbContextOptions<PizzaBoxDbContext> GetOptions()
        {
            return options;
        }

    }
}
