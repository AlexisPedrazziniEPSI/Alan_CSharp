using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Quadrilatère : Polygone
    {
        public Quadrilatère(Point a, Point b, Point c, Point d) : base(a, b, c, d)
        {

        }

        public override double CalculAire()
        {
            double p = CalculerPerimetre() / 2;
            double a = this[0].CalculDistance(this[1]);
            double b = this[1].CalculDistance(this[2]);
            double c = this[2].CalculDistance(this[3]);
            double d = this[3].CalculDistance(this[0]);
            return Math.Sqrt((p - a) * (p - b) * (p - c) * (p - d));
        }
    }
}
