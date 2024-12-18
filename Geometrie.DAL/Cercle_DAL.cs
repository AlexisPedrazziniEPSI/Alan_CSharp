namespace Geometrie.DAL
{
    public class Cercle_DAL
    {
        public int? Id { get; set; }
        public double Rayon { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }

        public Cercle_DAL() { }

        public Cercle_DAL(double rayon)
        {
            Rayon = rayon;
        }

        public Cercle_DAL(int id, double rayon)
            : this(rayon)
        {
            Id = id;
        }
    }
}