using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Geometrie.BLL
{
    public class Triangle : Polygone
    {
        public Triangle(Point a, Point b, Point c) : base(a, b, c)
        {
            if (a == b || a == c || b == c)
                throw new ArgumentException("Deux points sont identiques");

            var cotes = new List<Double>()
            {
                a.CalculDistance(b), b.CalculDistance(c), c.CalculDistance(a)
            };

            cotes.Sort();

            if (cotes[2] <= cotes[0] + cotes[1])
                throw new ArgumentException("Les trois points ne forment pas un triangle");
        }

        public override double CalculAire()
        {
            double p = CalculerPerimetre() / 2;
            double a = this[0].CalculDistance(this[1]);
            double b = this[1].CalculDistance(this[2]);
            double c = this[2].CalculDistance(this[0]);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
