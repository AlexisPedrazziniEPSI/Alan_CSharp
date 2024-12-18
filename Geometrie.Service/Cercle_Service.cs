using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DAL;
using Geometrie.DTO;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Geometrie.Service
{
    public class Cercle_Service : ICercle_Service
    {
        private GeometrieContext? context;
        private IDepot<Cercle> cercle_depot;
        private IDepot<Log> log_depot;

        public Cercle_Service(IDepot<Cercle> unDepotDeCercle, IDepot<Log> unDepotDeLog)
        {
            ArgumentNullException.ThrowIfNull(unDepotDeLog);
            ArgumentNullException.ThrowIfNull(unDepotDeCercle);

            cercle_depot = unDepotDeCercle;
            log_depot = unDepotDeLog;
        }

        public Cercle_Service(GeometrieContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            this.context = context;
            cercle_depot = new Cercle_Depot(context);
            log_depot = new Log_Depot(context);
        }

        public Cercle_DTO Add(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_BLL = new Cercle(element.Rayon);
            cercle_BLL = cercle_depot.Add(cercle_BLL);
            element.Id = cercle_BLL.Id;

            return element;
        }

        public Cercle_DTO GetById(int id)
        {
            var cercle = cercle_depot.GetById(id);
            return new Cercle_DTO { Id = cercle.Id, Rayon = cercle.Rayon };
        }

        public IEnumerable<Cercle_DTO> GetAll()
        {
            return cercle_depot.GetAll().Select(cercle => new Cercle_DTO { Id = cercle.Id, Rayon = cercle.Rayon }).ToList();
        }

        public IService<Cercle_DTO> Delete(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_BLL = new Cercle(element.Rayon) { Id = element.Id };
            cercle_depot.Delete(cercle_BLL);

            return this;
        }

        public IService<Cercle_DTO> Delete(int Id)
        {
            cercle_depot.Delete(Id);
            return this;
        }

        public Cercle_DTO Update(Cercle_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_BLL = new Cercle(element.Rayon) { Id = element.Id };
            cercle_BLL = cercle_depot.Update(cercle_BLL);

            return new Cercle_DTO { Id = cercle_BLL.Id, Rayon = cercle_BLL.Rayon };
        }

        /// <summary>
        /// Calcule l'aire de plusieurs cercles et enregistre l'appel dans les logs.
        /// </summary>
        /// <param name="IP">L'adresse IP de l'appelant.</param>
        /// <param name="cercles">Les cercles dont l'aire doit être calculée.</param>
        /// <returns>La somme des aires des cercles.</returns>
        /// <exception cref="ArgumentNullException">Si le paramètre cercles est null.</exception>
        public double CalculAirePlusieursCercles(string IP, params Cercle_DTO[] cercles)
        {
            ArgumentNullException.ThrowIfNull(cercles, nameof(cercles));

            if (cercles.Length == 0)
            {
                throw new ArgumentException("Vous n'avez pas fournis de cercle. Donnez en au minimum 2");
            }

            if (cercles.Length == 1)
            {
                throw new ArgumentException("Il faut au moins deux cercles pour calculer une aire.");
            }

            var cercles_BLL = new Cercle[cercles.Length];
            for (int i = 0; i < cercles.Length; i++)
            {
                cercles_BLL[i] = new Cercle(cercles[i].Rayon);
            }
            log_depot.Add(new Log(IP));

            return Cercle.CalculAirePlusieursCercles(cercles_BLL);
        }
    }
}
