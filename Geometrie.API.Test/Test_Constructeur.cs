
using Geometrie.BLL;
using Geometrie.DAL;
using Geometrie.DTO;
using Geometrie.Service;
using Geometrie.BLL.Depots;

namespace Geometrie.API.Test
{
    public class Test_Constructeur
    {
        [Fact]
        public void testPointCs()
        {
            // tester point.cs (tout ses trucs)
            var point = new Point(1, 2);
            Assert.Equal(1, point.X);

            Assert.Equal(2, point.Y);

            var calculdistcarre = point.CalculerDistanceCarre(new Point(3, 4));
            Assert.Equal(2.8284271247461903, calculdistcarre);

            var calculdist = point.CalculerDistance(new Point(3, 4));
            Assert.Equal(2.8284271247461903, calculdist);

            Console.WriteLine("Point.cs OK");
        }

        [Fact]
        public void testPointDepot()
        {
            // tester pointDepot.cs (tout ses trucs)
            var context = new GeometrieContext();
            var pointDepot = new Point_Depot(context);
            var point = new Point(1, 2);
            pointDepot.Add(point);
            var pointRecup = pointDepot.GetById(1);
            Assert.Equal(3, pointRecup.Id);
            Console.WriteLine(pointRecup.Id);
            Assert.Equal(1, pointRecup.X);
            Console.WriteLine(pointRecup.X);
            Assert.Equal(2, pointRecup.Y);
            Console.WriteLine(pointRecup.Y);
            Console.WriteLine("PointDepot OK");
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 6)]
        public void TheoryPointCs(int id, int x, int y)
        {
            Console.WriteLine("id: " + id + " x: " + x + " y: " + y);
            var point = new Point(id, x, y);
            Assert.Equal(id, point.Id);
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }
    }
}