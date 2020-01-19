using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PizzaBox.Domain
{
    public class DatabaseSystemBuilder
    {
        private static readonly DatabaseSystemBuilder instance = new DatabaseSystemBuilder();
        private static DbContextOptions<PizzaBoxDbContext> options;

        static DatabaseSystemBuilder() { }
        private DatabaseSystemBuilder()
        {
            var configBuilder = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PizzaBoxDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaBoxConnection"));

            options = optionsBuilder.Options;
        }

        public static DatabaseSystemBuilder Instance
        {
            get { return instance; }
        }

        public PizzaBoxDbContext GetDatabase()
        {
            return new PizzaBoxDbContext(options);
        }
    }
}
