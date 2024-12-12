using Geometrie.BLL.Depots;
using Geometrie.BLL;
using Moq;

namespace Geometrie.Service.Test
{
    public class Point_Service_Test
    {
        /// <summary>
        /// Dans le cas ou ont doit tester quelque chose qui va cr�e des entr� dans la BDD
        /// Il faut cr�e un "Moq" (installavie via packet NuGet) afin de simuler la m�thode cr�ant le lien a la BDD
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

            // la fausse m�thode (via moq) imite la vrai m�thode Add
            depot.Setup(d => d.Add(It.IsAny<Point>())).Returns(new Point(1, 2, 3));
            // On cr�e un service avec le depot mock�
            // On cr�e un point avec la couche BLL et on le passe au depot, et on retourne un point avec un Id
            // d => d.Add(It.IsAny<Point>() => On s'attend � ce que la m�thode Add du depot soit appel�e avec n'importe quel point 
            // Et qu'elle retourne un point

            var service = new Point_Service(depot.Object);

            var point = new Point(2, 3);
            Assert.NotNull(service);
        }
    }
}