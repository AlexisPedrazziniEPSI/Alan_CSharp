using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DTO;
using Moq;

namespace Geometrie.Service.Tests
{
    public class Cercle_Service_Tests
    {
        [Fact]
        public void Cercle_service_constructeur()
        {
            // Arrange
            var depot = new Moq.Mock<IDepot<Cercle>>().Object;
            var log_depot = new Mock<IDepot<Log>>().Object;
            var cercle_service = new Cercle_Service(depot, log_depot);

            Assert.NotNull(cercle_service);
        }

        [Fact]
        public void Cercle_service_add()
        {
            var depot = new Mock<IDepot<Cercle>>();
            var log_depot = new Mock<IDepot<Log>>();
            depot.Setup(d => d.Add(It.IsAny<Cercle>())).Returns(new Cercle(1));
            var service = new Cercle_Service(depot.Object, log_depot.Object);
            var cercle = new Cercle_DTO() { Id = 0 ,Rayon = 1 };
            var result = service.Add(cercle);
            Assert.NotNull(result);
            Assert.Equal(0, result.Id);
            Assert.Equal(1, result.Rayon);
        }
    }
}
