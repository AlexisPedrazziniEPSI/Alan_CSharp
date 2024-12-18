using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL.Depots
{
    public class Cercle_Depot : IDepot<Cercle>
    {
        private GeometrieContext context;

        public Cercle_Depot(GeometrieContext context)
        {
            this.context = context;
        }

        public Cercle Add(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var cercle_DAL = element.ToDAL();
            cercle_DAL.DateDeCreation = DateTime.Now;
            context.Cercles.Add(cercle_DAL);
            context.SaveChanges();
            element.Id = cercle_DAL.Id;

            return element;
        }

        public IDepot<Cercle> Delete(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IDepot<Cercle> Delete(int Id)
        {
            var cercle_DAL = context.Cercles.Find(Id);
            if (cercle_DAL == null)
                throw new ArgumentException("Le cercle n'existe pas en base de données", nameof(Id));

            context.Cercles.Remove(cercle_DAL);
            context.SaveChanges();
            return this;
        }

        public IEnumerable<Cercle> GetAll()
        {
            return context.Cercles.Select(c => new Cercle(c.Id.Value, c.Rayon));
        }

        public Cercle? GetById(int id)
        {
            var cercle_DAL = context.Cercles.Find(id);
            if (cercle_DAL == null)
                return null;

            return new Cercle(cercle_DAL.Id.Value, cercle_DAL.Rayon);
        }

        public Cercle Update(Cercle element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var cercle_DAL = context.Cercles.Find(element.Id);
            if (cercle_DAL == null)
                throw new ArgumentException("Le cercle n'existe pas en base de données", nameof(element.Id));

            cercle_DAL.Rayon = element.Rayon;
            cercle_DAL.DateDeModification = DateTime.Now;
            context.SaveChanges();

            return element;
        }
    }
}
