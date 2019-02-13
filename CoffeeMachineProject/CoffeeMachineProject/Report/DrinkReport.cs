using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachineProject.Report
{
    /// <summary>
    /// Represents a drink report value
    /// </summary>
    public class DrinkReport
    {
        /// <summary>
        /// The providing date of the drink
        /// </summary>
        private DateTime date;

        /// <summary>
        /// The drink which was provide
        /// </summary>
        private DrinkMaker drink;

        /// <summary>
        /// The money acount which was provide for the drink
        /// </summary>
        private double moneyAcount;

        /// <summary>
        /// Instantiate the <see cref="DrinkReport"/>
        /// </summary>
        /// <param name="drink"></param>
        /// <param name="moneyAcount"></param>
        public DrinkReport(DrinkMaker drink, double moneyAcount)
            : this(DateTime.Now, drink, moneyAcount)
        {
        }

        public DrinkReport(DateTime date, DrinkMaker drink, double moneyAcount)
        {
            this.date = date;
            this.drink = drink;
            this.moneyAcount = moneyAcount;

        }

        /// <summary>
        /// Gets providing date of the drink
        /// </summary>
        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        /// <summary>
        /// Gets the drink which was provide
        /// </summary>
        public DrinkMaker Drink
        {
            get
            {
                return this.drink;
            }
        }

        /// <summary>
        /// Gets the money acount for the drink
        /// </summary>
        public double MoneyAcount
        {
            get
            {
                return this.moneyAcount;
            }
        }
    }
}
