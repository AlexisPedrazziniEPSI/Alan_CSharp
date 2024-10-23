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

        public double CalculDistance(Point other)
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        public override string ToString() => $"({X}, {Y})";
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
            Texte = texte;
        }
    }
}
