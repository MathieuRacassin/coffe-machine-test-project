using CoffeeMachineProject;
using CoffeeMachineProject.Report;
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

            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("Th:1:0"), 0.8));
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("Hh:1:0"), 1));
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("Ch:1:0"), 0.9));
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("T:1:0"), 0.6));
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("C:1:0"), 0.6));
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("H:1:0"), 0.7));
            reportDrink.DrinkReports.Add(new DrinkReport(new DrinkMaker("O:1:0"), 0.8));

            var result = reportDrink.WriteReport(fileName);

            Assert.True(result.Exists);
            Assert.Equal(7, reportDrink.DrinkReports.Count);
            Assert.NotNull(reportDrink.DrinkReports);
        }
    }
}
