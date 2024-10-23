using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public abstract class Polygone : IEnumerable<Point>, IForme
    {
        private ArrayList lesPoints;

        //Indexeur
        public Point this[int index]
        {
            get
            {
                return (Point)lesPoints[index];
            }
        }

        //public int Count
        //{
        //    get
        //    {
        //        return lesPoints.Count;
        //    }
        //    set
        //    {
        //        lesPoints.Clear();
        //    }
        //}

        public int Count => lesPoints.Count;




        /// <summary>
        /// constructeur d'un polygone
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="autrePoints"></param>
        /// <exception cref="ArgumentNullException"> Si un des trois points est null on envoi une exception</exception>

        public Polygone(Point a, Point b, Point c, params Point[]? autrePoints)
        {
            if (a == null || b == null || c == null)
                throw new ArgumentNullException();

            lesPoints = new ArrayList();
            lesPoints.Add(a);
            lesPoints.Add(b);
            lesPoints.Add(c);
            if (autrePoints != null)
                lesPoints.AddRange(autrePoints);
        }

        public IEnumerator<Point> GetEnumerator()
        {
            foreach (Point p in lesPoints)
            {
                //yield permet de retourner un élément à la fois
                yield return p;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            foreach (Point p in lesPoints)
            {
                sb.Append(p.ToString());
                sb.Append(" ");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public double CalculerPerimetre()
        {
            double perimetre = 0;
            for (int i = 0; i < Count - 1; i++)
            {
                Point p1 = this[i];
                Point p2 = this[i + 1];
                perimetre += p1.CalculDistance(p2);
            }
            perimetre += this[Count - 1].CalculDistance(this[0]);
            return perimetre;
        }

        public abstract double CalculAire();
    }
}