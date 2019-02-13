using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffeeMachineProject.Report
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private FileInfo fileInfo;

        /// <summary>
        /// 
        /// </summary>
        private List<DrinkReport> drinkReports;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="drinkReports"></param>
        public ReportProvider(string filePath)
        {
            this.fileInfo = new FileInfo(filePath);
            this.drinkReports = new List<DrinkReport>();
        }

        /// <summary>
        /// 
        /// </summary>
        public FileInfo FileInfo
        {
            get
            {
                return this.fileInfo;
            }
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportName"></param>
        public void WriteReport(string reportName)
        {
            using (Stream s = new FileStream(reportName+".txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(s, Encoding.UTF8))
                {
                    writer.Write("Report " + DateTime.Today.ToString());
                }
            }
        }
    }
}
