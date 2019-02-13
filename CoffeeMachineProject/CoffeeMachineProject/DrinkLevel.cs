using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachineProject
{
    /// <summary>
    /// Represent the drink level of each drink
    /// </summary>
    public partial class DrinkLevel : IBeverageQuantityChecker
    {
        /// <summary>
        /// Number of doses available drink with water
        /// </summary>
        private int waterLevel;

        /// <summary>
        /// Numbers of doses available drink with milk
        /// </summary>
        private int milkLevel;

        /// <summary>
        /// Numbers of doses available for a drink juice
        /// </summary>
        private int orangeJuiceLevel;

        public DrinkLevel()
        {

        }

        /// <summary>
        /// Gets or sets the water level
        /// </summary>
        public int WaterLevel
        {
            get
            {
                return this.waterLevel;
            }
            set
            {
                this.waterLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the milk level
        /// </summary>
        public int MilkLevel
        {
            get
            {
                return this.milkLevel;
            }
            set
            {
                this.milkLevel = value;
            }
        }

        /// <summary>
        /// Gets or sets the orange juice level
        /// </summary>
        public int OrangeJuiceLevel
        {
            get
            {
                return this.orangeJuiceLevel;
            }
            set
            {
                this.orangeJuiceLevel = value;
            }
        }

        /// <summary>
        /// Check the level
        /// </summary>
        /// <param name="drink"></param>
        /// <returns></returns>
        public bool IsEmpty(string drink)
        {
            if(string.IsNullOrEmpty(drink))
            {
                return false;
            }
            else
            {
                if(drink == DrinkType.Coffee || drink ==DrinkType.CoffeeExtraHot)
                {
                    if(this.milkLevel == 0 || this.waterLevel == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (drink == DrinkType.Chocolate || drink == DrinkType.ChocolateExtraHot)
                {
                    if (this.milkLevel == 0 || this.waterLevel == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (drink == DrinkType.Tea || drink == DrinkType.TeaExtraHot)
                {
                    if (this.waterLevel == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (drink == DrinkType.OrangeJuice)
                {
                    if (this.orangeJuiceLevel == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
