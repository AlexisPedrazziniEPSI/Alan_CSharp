using Geometrie.BLL.Depots;
using Geometrie.BLL;
using Geometrie.DTO;
using Moq;

namespace Geometrie.Service.Test
{
    public class Point_Service_Test
    {
        /// <summary>
        /// Dans le cas ou ont doit tester quelque chose qui va crée des entré dans la BDD
        /// Il faut crée un "Moq" (installavie via packet NuGet) afin de simuler la méthode créant le lien a la BDD
        /// </summary>
        [Fact]
        public void Point_Service_Constructeur()
        {
            var depot = new Moq.Mock<IDepot<Point>>().Object;
            var service = new Point_Service(depot);

            // assertion
            Assert.NotNull(service);
        }

        [Fact]
        public void Point_Service_Add()
        {
            // Arrange
            var depot = new Mock<IDepot<Point>>();

            // la fausse méthode (via moq) imite la vrai méthode Add
            depot.Setup(d => d.Add(It.IsAny<Point>())).Returns(new Point(1, 2, 3));
            // On crée un service avec le depot mocké
            // On crée un point avec la couche BLL et on le passe au depot, et on retourne un point avec un Id
            // d => d.Add(It.IsAny<Point>() => On s'attend à ce que la méthode Add du depot soit appelée avec n'importe quel point 
            // Et qu'elle retourne un point

            var service = new Point_Service(depot.Object);

            var point = new Point_DTO() { Id = 0, X = 2, Y = 3 };

            // Act
            var result = service.Add(point);

            //assertion
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal(2, result.X);
            Assert.Equal(3, result.Y);
            depot.Verify(d => d.Add(It.IsAny<Point>()), Times.Once);
        }

        [Fact]
        public void Point_Service_Calcul_Dist()
        {
            int id1 = 2;
            int id2 = 3;

            var depot = new Mock<IDepot<Point>>();
            var service = new Point_Service(depot.Object);

            var result = service.CalcDist(id1, id2);
        }
    }
}