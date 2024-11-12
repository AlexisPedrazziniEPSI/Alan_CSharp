using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL
{
    public class Polygone
    {
        public int? Id { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public ICollection<Point> Points { get; set; }

        public Polygone() 
        {
            Points = new HashSet<Point>();
        }
    }
}
