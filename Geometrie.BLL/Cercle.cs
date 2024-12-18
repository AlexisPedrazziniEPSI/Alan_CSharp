using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Cercle : IForme
    {
        public int? Id { get; set; }
        public double Rayon { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }

        public Cercle(double rayon)
        {
            Rayon = rayon;
        }

        public Cercle(int id, double rayon)
            : this(rayon)
        {
            Id = id;
        }

        internal DAL.Cercle_DAL ToDAL()
        {
            if (Id == null)
                return new DAL.Cercle_DAL(Rayon);
            else
                return new DAL.Cercle_DAL(Id.Value, Rayon);
        }

        public double CalculerPerimetre() => 2 * Math.PI * Rayon;

        public double CalculerAire() => Math.PI * Math.Pow(Rayon, 2);
        
        public static double CalculAirePlusieursCercles(params Cercle[] cercles)
        {
            double aire = 0;
            foreach (var cercle in cercles)
            {
                aire += cercle.CalculerAire();
            }
            return aire;
        }
    }
}
