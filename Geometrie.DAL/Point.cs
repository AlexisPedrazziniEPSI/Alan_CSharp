namespace Geometrie.DAL
{
    public class Point
    {
        public int? Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public virtual Polygone? Polygone { get; set; }
        public Point(int x, int y, DateTime dateDeCreation)
        {
            X = x;
            Y = y;
            DateCreation = dateDeCreation;
        }
        public Point(int id, int x, int y, DateTime dateDeCreation, DateTime dateDeModification, Polygone polygone):this(x,y, dateDeCreation)
        {
            Id = id;
            DateModification = dateDeModification;
            Polygone = polygone;
        }
    }
}
