using CoffeeMachineProject;
using CoffeeMachineProject.Report;
using Moq;
using System;
using System.IO;
using Xunit;

namespace CoffeeMachineProjectTest.Report
{
    public class ReportProviderTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var reportDrink = new ReportProvider();

            Assert.NotNull(reportDrink.DrinkReports);
        }

        [Fact]
        public void WriterTest()
        {
            var reportDrink = new ReportProvider();
            var fileName = Path.GetTempPath() + "reportProviderFileTest.txt";

            var beverageQuantity = new Mock<IBeverageQuantityChecker>(MockBehavior.Strict);

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.TeaExtraHot)).Returns(false);
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("Th:1:0", beverageQuantity.Object), 0.8));

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.ChocolateExtraHot)).Returns(false);
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("Hh:1:0", beverageQuantity.Object), 1));

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.CoffeeExtraHot)).Returns(false);
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("Ch:1:0", beverageQuantity.Object), 0.9));

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Tea)).Returns(false);
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("T:1:0", beverageQuantity.Object), 0.6));

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Coffee)).Returns(false);
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("C:1:0", beverageQuantity.Object), 0.6));

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Chocolate)).Returns(false);
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("H:1:0", beverageQuantity.Object), 0.7));

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.OrangeJuice)).Returns(false);
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("O:1:0", beverageQuantity.Object), 0.8));

            var result = reportDrink.WriteReport(fileName);

            Assert.True(result.Exists);
            Assert.Equal(7, reportDrink.DrinkReports.Count);
            Assert.NotNull(reportDrink.DrinkReports);
        }
    }
}
