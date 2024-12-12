using Geometrie.BLL.Depots;
using Geometrie.BLL;
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
            var depot = new Moq.Mock<Point_Depot>().Object;
            var service = new Point_Service(depot);

            // assertion
            Assert.NotNull(service);
        }

        [Fact]
        public void Point_Service_Add()
        {
            // Arrange
            var depot = new Mock<Point_Depot>();

            // la fausse méthode (via moq) imite la vrai méthode Add
            depot.Setup(d => d.Add(It.IsAny<Point>())).Returns(new Point(1, 2, 3));
            // On crée un service avec le depot mocké
            // On crée un point avec la couche BLL et on le passe au depot, et on retourne un point avec un Id
            // d => d.Add(It.IsAny<Point>() => On s'attend à ce que la méthode Add du depot soit appelée avec n'importe quel point 
            // Et qu'elle retourne un point

            var service = new Point_Service(depot.Object);

            var point = new Point(2, 3);
            Assert.NotNull(service);
        }
    }
}