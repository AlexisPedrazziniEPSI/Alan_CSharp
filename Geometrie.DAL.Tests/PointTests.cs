namespace Geometrie.DAL.Tests
{
    public class PointTests
    {
        [Fact]
        public void Geometrie_Point_Constructor()
        {
            // ont teste le premier constructeur de la classe Point
            // un test se fait en 3 points : arranger, action, assert

            // 1. Arranger : initialiser les variables
            // 2. Action : appeler la méthode à tester
            var point = new Point(1, 2, new DateTime(2021, 11, 12));

            // 3. Assert : vérifier que le résultat est correct
            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
            Assert.Equal(new DateTime(2021, 11, 12), point.DateCreation);
            
        }
        [Theory]
        [InlineData(1, 2, 3, "2021-11-12", "2021-11-13")]
        public void Geometrie_DAL_Constructor_With_ID(int id, int x, int y, DateTime dateDeCreation, DateTime dateDeModification)
        {
            // ont teste le deuxième constructeur de la classe Point
            // un test se fait en 3 points : arranger, action, assert

            // 1. Arranger : initialiser les variables
            // 2. Action : appeler la méthode à tester
            var polygone = new Polygone();
            var point = new Point(id, x, y, dateDeCreation, dateDeModification, polygone);

            // 3. Assert : vérifier que le résultat est correct
            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
            Assert.Equal(new DateTime(2021, 11, 12), point.DateCreation);
            Assert.Equal(new DateTime(2021, 11, 13), point.DateModification);
            Assert.Equal(polygone, point.Polygone);
        }
    }
}