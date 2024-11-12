using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL
{
    /// <summary>
    /// Classe d'accès aux données pour les formes géométriques
    /// en Entity Framework (code-first)
    /// </summary>
    public class GeometrieContext : DbContext
    {
        #region Configuration
        //on va récupérer la chaine de connexion dans le fichier de configuration
        private readonly IConfiguration configuration;

        public GeometrieContext()
            : base(new DbContextOptions<GeometrieContext>())
        {
            //on récupère un objet configuration
            //à parttir d'un fichier de configuration appsettings.json
            var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
            configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //on configure le provider et la chaine de connexion
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Geometrie"));
        }
        #endregion

        #region DbSet

        /// <summary>
        /// Je configure DbSet pour les Points
        /// c'est ça qui va me permettre de faire des requêtes
        /// et de créer la table Points
        /// </summary>

        public DbSet<Point> Points { get; set; }
        #endregion
    }
}