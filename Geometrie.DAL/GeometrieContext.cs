using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL
{
    internal class GeometrieContext : DbContext
    {
        #region Configuration
        private readonly IConfiguration configuration;

        public GeometrieContext() : base(new DbContextOptions<GeometrieContext>())
        {
            var buider = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional:false, reloadOnChange:false);
            configuration = buider.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Geometrie"));
            }
        }
        #endregion

        #region DbSets
        public DbSet<Point> Points { get; set; }
        #endregion
    }
}
