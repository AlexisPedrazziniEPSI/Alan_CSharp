using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Geometrie.BLL
{
    public class Triangle : Polygone
    {
        public Triangle(Point a, Point b, Point c) : base(a, b, c)
        {
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
