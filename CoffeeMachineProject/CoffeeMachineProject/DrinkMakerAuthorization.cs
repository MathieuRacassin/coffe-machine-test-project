using CoffeeMachineProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachineProject
{
    /// <summary>
    /// Represents the money acount to provide the drink
    /// </summary>
    public class DrinkMakerAuthorization
    {

        /// <summary>
        /// The money acount
        /// </summary>
        private double acount;

        /// <summary>
        /// The boolean which authorize to provide the drink
        /// </summary>
        private bool isAuthorized;

        public DrinkMakerAuthorization(double money)
        {
            this.acount = money;
            this.isAuthorized = false;
        }

        /// <summary>
        /// Gets the money acount
        /// </summary>
        public double Acount
        {
            get
            {
                return this.acount;
            }
        }

        /// <summary>
        /// Gets the boolean which authorized to provide the drink
        /// </summary>
        public bool IsAuthorized
        {
            get
            {
                return this.isAuthorized;
            }
        }

        /// <summary>
        /// Provide a drink if the money acount good enough
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public DrinkMaker ProvideDrink(string instruction)
        {
            var drink = new DrinkMaker(instruction);
            var acountDifference = 0.0;

            if(drink.Drink == DrinkType.Coffee || drink.Drink == DrinkType.CoffeeExtraHot)
            {
                if(this.acount >= DrinkPrice.CoffeePrice)
                {
                    this.isAuthorized = true;
                    return drink;
                }
                else
                {
                    acountDifference = DrinkPrice.CoffeePrice - this.acount;
                    var message = "M:It's missing " + acountDifference.ToString() + " € for your coffee";
                    drink = new DrinkMaker(message);
                }
            }
            if (drink.Drink == DrinkType.Chocolate || drink.Drink == DrinkType.ChocolateExtraHot)
            {
                if(this.acount >= DrinkPrice.ChocolatePrice)
                {
                    this.isAuthorized = true;
                    return drink;
                }
                else
                {
                    acountDifference = DrinkPrice.ChocolatePrice - this.acount;
                    var message = "M:It's missing " + acountDifference.ToString() + " € for your chocolate";
                    drink = new DrinkMaker(message);
                }
            }
            if (drink.Drink == DrinkType.Tea)
            {
                if(this.acount >= DrinkPrice.TeaPrice || drink.Drink == DrinkType.TeaExtraHot)
                {
                    this.isAuthorized = true;
                    return drink;
                }
                else
                {
                    acountDifference = DrinkPrice.TeaPrice - this.acount;
                    var message = "M:It's missing " + acountDifference.ToString() + " € for your tea";
                    drink = new DrinkMaker(message);
                }
            }
            if (drink.Drink == DrinkType.OrangeJuice)
            {
                if (this.acount >= DrinkPrice.OrangeJuicePrice)
                {
                    this.isAuthorized = true;
                    return drink;
                }
                else
                {
                    acountDifference = DrinkPrice.OrangeJuicePrice - this.acount;
                    var message = "M:It's missing " + acountDifference.ToString() + " € for your orange juice";
                    drink = new DrinkMaker(message);
                }
            }
            return drink;
        }
    }
}
