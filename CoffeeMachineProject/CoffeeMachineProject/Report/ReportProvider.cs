using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CoffeeMachineProject.Report
{
    /// <summary>
    /// Tools class to write a report in txt format
    /// </summary>
    public class ReportProvider
    {
        /// <summary>
        /// The value of the report
        /// </summary>
        private List<DrinkReport> drinkReports;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="drinkReports"></param>
        public ReportProvider()
        {
            this.drinkReports = new List<DrinkReport>();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<DrinkReport> DrinkReports
        {
            get
            {
                return this.drinkReports;
            }
            set
            {
                this.drinkReports = value;
            }
        }

        /// <summary>
        /// Write the report in 
        /// </summary>
        /// <param name="reportPath">The report path (the specified field must be a txt file</param>
        public FileInfo WriteReport(string reportPath)
        {
            using (Stream s = new FileStream(reportPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(s, Encoding.UTF8))
                {
                    writer.Write("Report ");
                    writer.WriteLine();
                    writer.WriteLine(this.DrinkSoldCount(DrinkType.Coffee).ToString() +" coffees were sold");
                    writer.WriteLine(this.DrinkSoldCount(DrinkType.CoffeeExtraHot).ToString() + " coffees extra hot were sold");
                    writer.WriteLine(this.DrinkSoldCount(DrinkType.Chocolate).ToString() + " chocolates were sold");
                    writer.WriteLine(this.DrinkSoldCount(DrinkType.ChocolateExtraHot).ToString() + " chocolates extra hot were sold");
                    writer.WriteLine(this.DrinkSoldCount(DrinkType.Tea).ToString() + " teas were sold");
                    writer.WriteLine(this.DrinkSoldCount(DrinkType.TeaExtraHot).ToString() + " teas extra hot were sold");
                    writer.WriteLine(this.DrinkSoldCount(DrinkType.OrangeJuice).ToString() + " orange juice were sold");

                    writer.WriteLine(this.drinkReports.Sum(drinkReport => drinkReport.MoneyAcount).ToString()+" € amount of money earned");
                }
            }

            return new FileInfo(reportPath);
        }

        /// <summary>
        /// Realize the count of the sold drink
        /// </summary>
        /// <param name="drinkType"></param>
        /// <returns></returns>
        private int DrinkSoldCount(string drinkType)
        {
            return this.drinkReports.Where(drinkReport => drinkReport.Drink.Drink == drinkType)
                                    .Count();
        }
    }
}
