using CoffeeMachineProject;
using CoffeeMachineProject.Report;
using System;
using Xunit;

namespace CoffeeMachineProjectTest.Report
{
    public class DrinkReportTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var drinkMaker = new DrinkMaker();
            var drinkReport = new DrinkReport(DateTime.MinValue, drinkMaker, 1);

            Assert.Equal(DateTime.MinValue, drinkReport.Date);
            Assert.Equal(drinkMaker, drinkReport.Drink);
            Assert.Equal(1.0, drinkReport.MoneyAcount);
        }

    }
}
