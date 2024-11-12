namespace Geometrie.BLL
{
    /// <summary>
    /// Représente un point ddans un espace a deux dimensions
    /// avec les coordonées x et y
    /// </summary>
    public class Point
    {
        private int x;
        private int y;

        /// <summary>
        /// Abscisse du point
        /// </summary>
        public int X // sekuritiy ( en vrai c'est pour complexifier le code et sécuriser la valeur )
        { 
            get { return x; }
            private set { x = value; } // on ne peux pas modifier la valeur de x en dehors de la classe
        }

        /// <summary>
        /// Ordonnée du point
        /// </summary>
        public int Y { get; private set; } // version réduit du code au dessus et automatiquement privé

        /// <summary>
        /// constructeur d'un point
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y)
        {
            X = x; //
            Y = y;
        }
        /// <summary>
        /// Calcul la distance entre deux points
        /// </summary>
        /// <param name="other"></param>
        /// <returns>Return the distance between two point (float)</returns>
        public double CalculDistance(Point? autre)
        {
            if (autre == null)
            {
                throw new ArgumentNullException(nameof(autre));
            }

            return Math.Sqrt(CalculerDistanceCarre(autre));
        }

        public override string ToString() => $"({X}, {Y})";

        public static bool operator ==(Point? p1, Point? p2)
        {
            if (ReferenceEquals(p1, p2))
                return true;
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator !=(Point? p1, Point? p2) => !(p1 == p2);

        public override bool Equals(object? obj)
        {
            if (obj is Point other)
            {
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public int CalculerDistanceCarre(Point autre)
        {
            if (autre == null)
            {
                throw new ArgumentNullException(nameof(autre));
            }

            return Convert.ToInt32(Math.Pow(X - autre.X, 2) + Math.Pow(Y - autre.Y, 2));
        }
    }

    public class SetHelloWorld // fait hors cours pour tester
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
