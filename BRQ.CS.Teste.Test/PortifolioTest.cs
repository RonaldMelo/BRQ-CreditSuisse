using BQR.CS.Teste.Domain;
using BRQ.CS.Teste.Service;
using BRQ.CS.Teste.Service.Interface;
using System.Globalization;

namespace BRQ.CS.Teste.Test
{
    public class PortifolioTest
    {
        private const string stringFormat = "MM/dd/yyyy";
        private readonly IPortifolioService _portifolioService;


        public PortifolioTest()
        {
            _portifolioService = new PortifolioService();
        }


        [Test]
        public void CategoryShouldReturnHigRisk()
        {
            //Arrange
            IEnumerable<Trade> trade = new Trade[] { new Trade(2000000, "Private", DateTime.ParseExact("12/29/2020", stringFormat, CultureInfo.InvariantCulture)) };

            //Act
            var portifolio = new Portifolio(DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), 1, trade);
            var categories = _portifolioService.ClassifyTradesProtifolio(portifolio);


            //Assert
            Assert.IsTrue(categories[0] == "HIGHRISK");
        }

        [Test]
        public void CategoryShouldReturnExpired()
        {
            //Arrange
            IEnumerable<Trade> trade = new Trade[] { new Trade(400000, "Public", DateTime.ParseExact("07/01/2020", stringFormat, CultureInfo.InvariantCulture)) };

            //Act
            var portifolio = new Portifolio(DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture), 1, trade);
            var categories = _portifolioService.ClassifyTradesProtifolio(portifolio);


            //Assert
            Assert.IsTrue(categories[0] == "EXPIRED");
        }

        [Test]
        public void CategoryShouldReturnMediumRisk()
        {
            //Arrange
            IEnumerable<Trade> trade = new Trade[] { new Trade(5000000, "Public", DateTime.ParseExact("01/02/2020", stringFormat, CultureInfo.InvariantCulture)) };

            //Act
            var portifolio = new Portifolio(DateTime.ParseExact("12/11/2020", "mm/dd/yyyy", CultureInfo.InvariantCulture), 1, trade);
            var categories = _portifolioService.ClassifyTradesProtifolio(portifolio);


            //Assert
            Assert.IsTrue(categories[0] == "MEDIUMRISK");
        }
    }
}