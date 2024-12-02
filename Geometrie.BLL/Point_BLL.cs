using Geometrie.DAL;

namespace Geometrie.BLL
{
    /// <summary>
    /// Représente un point dans un espace à deux dimensions
    /// avec les coordonnées x et y
    /// </summary>
    public class Point_BLL
    {

        /// <summary>
        /// Stockage de l'id
        /// </summary>

        public int? Id { get; set; }

        private int x;
        private int y;

        /// <summary>
        /// Abscisse du point
        /// </summary>
        public int X
        {
            get { return x; }
            private set { x = value; }
        }

        /// <summary>
        /// Ordonnée du point
        /// </summary>
        public int Y
        {
            get { return y; }
            private set { y = value; }
        }

        public Point_BLL(int id, int x, int y): this(x, y)
        {
            Id = id;
        }

        /// <summary>
        /// Constructeur d'un point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point_BLL(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Calcul la distance entre deux points
        /// </summary>
        /// <param name="autre"></param>
        /// <returns>Retourne la distance entre deux points (double)</returns>
        public double CalculDistance(Point_BLL? autre)
        {
            if (autre == null)
            {
                throw new ArgumentNullException(nameof(autre));
            }

            return Math.Sqrt(CalculerDistanceCarre(autre));
        }

        public override string ToString() => $"({X}, {Y})";

        public static bool operator ==(Point_BLL? p1, Point_BLL? p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point_BLL? p1, Point_BLL? p2) => !(p1 == p2);

        public override bool Equals(object? obj)
        {
            if (obj is Point_BLL other)
            {
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }

        internal DAL.Point_DAL ToDAL()
        {
            if (Id == null)
                return new DAL.Point_DAL(X, Y);
            else
                return new DAL.Point_DAL(Id.Value, X, Y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public int CalculerDistanceCarre(Point_BLL autre)
        {
            if (autre == null)
            {
                throw new ArgumentNullException(nameof(autre));
            }

            return Convert.ToInt32(Math.Pow(X - autre.X, 2) + Math.Pow(Y - autre.Y, 2));
        }
    }

    public class SetHelloWorld
    {
        private string texte;

        public string Texte
        {
            get { return texte; }
            set { texte = value; }
        }

        public SetHelloWorld(string texte)
        {
            this.texte = texte ?? throw new ArgumentNullException(nameof(texte));
        }
    }
}