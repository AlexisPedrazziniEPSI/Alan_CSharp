
using Geometrie.BLL;
using Geometrie.DAL;
using Geometrie.DTO;
using Geometrie.BLL.Depots;
using Geometrie.API;
using Moq;
using Geometrie.API.Controllers;

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

            var calculDistanceCarre = point.CalculerDistanceCarre(new Point(5, 7));
            Assert.Equal(41, calculDistanceCarre);

            var calculdist = point.CalculerDistance(new Point(3, 4));
            Assert.Equal(2.8284271247461903, calculdist);

            Console.WriteLine("Point.cs OK");
        }

        //[Theory]
        //[InlineData(1, 1, 2)]
        //[InlineData(2, 3, 4)]
        [Fact]
        public void TestPointDepot() // int Id, int X, int Y
        {
            // tester pointDepot.cs (tout ses trucs)
            var context = new GeometrieContext();
            var pointDepot = new Point_Depot(context);
            var point = new Point(1, 2);
            pointDepot.Add(point);
            var pointRecup = pointDepot.GetById(1);
            //Assert.NotNull(pointRecup); // si null, erreur
            Assert.Equal(1, pointRecup.Id);
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

        [Fact]
        public void FactController()
        {
            // tester controller.cs
            // utilisation de moq pour simuler un service
            var service = new Moq.Mock<IService<Point_DTO>>();

            var controller = new Point_Controller(service.Object);

            //var point = new Point_DTO(1, 2, 3);
        }
    }
}