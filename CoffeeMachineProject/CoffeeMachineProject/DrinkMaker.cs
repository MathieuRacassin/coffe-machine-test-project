using CoffeeMachineProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMachineProject
{
    /// <summary>
    /// Represents a coffe maker
    /// </summary>
    public class DrinkMaker
    {
        /// <summary>
        /// The user instruction
        /// </summary>
        private string instruction;

        /// <summary>
        /// The type of the drink.
        /// Must be a coffe(C), a chocolate(H) or a tea(T)
        /// </summary>
        private string drink;

        /// <summary>
        /// The sugar quantity ( 0, 1, or 2)
        /// </summary>
        private int sugarQuantity;

        /// <summary>
        /// The stick 
        /// </summary>
        private bool stick;

        /// <summary>
        /// The message
        /// </summary>
        private string message;

        /// <summary>
        /// Instanciate the drink maker
        /// </summary>
        /// <param name="instruction">The receive instruction</param>
        public DrinkMaker(string instruction)
        {
            var receiveInstruction = this.InstructionReader(instruction);
            this.instruction = instruction;

            try
            {
                // Message case
                if(receiveInstruction[0] == "M")
                {
                    this.message = receiveInstruction[1];
                    this.sugarQuantity = 0;
                    this.stick = false;
                    this.drink = string.Empty;
                }
                // Drink case
                else
                {
                    this.drink = receiveInstruction[0];

                    if (receiveInstruction[1] == "0")
                    {
                        this.sugarQuantity = 0;
                    }
                    else
                    {
                        this.sugarQuantity = Convert.ToInt32(receiveInstruction[1]);
                    }

                    if (this.HasStick(receiveInstruction[2]) && this.sugarQuantity > 0)
                    {
                        this.stick = true;
                    }
                    if (this.HasStick(receiveInstruction[2]) && this.sugarQuantity == 0)
                    {
                        this.stick = false;
                    }
                    else
                    {
                        this.stick = this.HasStick(receiveInstruction[2]);
                    }


                    this.message = string.Empty;
                }
            }
            catch(Exception e)
            {
                throw new Exception("Something is wrong with your instruction : " + e.ToString());
            } 
        }

        /// <summary>
        /// Instanciate the drink maker
        /// </summary>
        public DrinkMaker()
        {
            this.instruction = string.Empty;
            this.message = string.Empty;
            this.sugarQuantity = 0;
            this.stick = false;
            this.drink = string.Empty;
        }

        /// <summary>
        /// Gets the instruction
        /// </summary>
        public string Instruction
        {
            get
            {
                return this.instruction;
            }
        }

        /// <summary>
        /// Gets the drink
        /// </summary>
        public string Drink
        {
            get
            {
                return this.drink;
            }
        }

        /// <summary>
        /// Gets the sugar quantity
        /// </summary>
        public int SugarQuantity
        {
            get
            {
                return this.sugarQuantity;
            }
        }

        /// <summary>
        /// Gets the message
        /// </summary>
        public string Message
        {
            get
            {
                return this.message;
            }
        }

        /// <summary>
        /// Gets the boolean stick
        /// </summary>
        public bool Stick
        {
            get
            {
                return this.stick;
            }
        }

        /// </override>
        public override string ToString()
        {
            if(this.message != string.Empty)
            {
                return this.message;
            }
            else
            {
                return this.drink + ":" + this.sugarQuantity.ToString() + ":" + this.stick.ToString();
            }
        }

        /// <summary>
        /// Read the instruction
        /// </summary>
        /// <param name="instruction">The instruction </param>
        /// <returns>A list which contains the information of the sorted instruction</returns>
        private List<string> InstructionReader(string instruction)
        {
            List<string> reader = new List<string>();
            if(instruction.Contains(DrinkType.Chocolate) || instruction.Contains(DrinkType.Coffee) || instruction.Contains(DrinkType.Tea) || instruction.Contains(DrinkType.OrangeJuice))
            {
                var drink = instruction.Substring(0, 1);
                var sugar = instruction.Substring(2, 1);
                var stick = instruction.Substring(instruction.Length - 1);

                reader = this.ParametersTools(drink, sugar, stick);
            }

            if (instruction.Contains(DrinkType.ChocolateExtraHot) || instruction.Contains(DrinkType.CoffeeExtraHot) || instruction.Contains(DrinkType.TeaExtraHot))
            {
                var drink = instruction.Substring(0, 2);
                var sugar = instruction.Substring(3, 1);
                var stick = instruction.Substring(instruction.Length - 1);

                reader = this.ParametersTools(drink, sugar, stick);
            }

            if (instruction.Contains("M"))
            {
                var message = instruction.Substring(0, 1);
                var messageContent = instruction.Substring(2);
                reader = new List<string>() { message, messageContent };
            }
            return reader;
        }

        /// <summary>
        /// Tools to add parameters
        /// </summary>
        /// <param name="drink">The drink value</param>
        /// <param name="sugar">The sugar value</param>
        /// <param name="stick">The stick value</param>
        /// <returns>A collection of string</returns>
        private List<string> ParametersTools(string drink, string sugar, string stick)
        {
            var result = new List<string>() { drink, sugar, stick };

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Contains(":"))
                {
                    result[i] = "0";
                }
            }

            return result;
        }

        /// <summary>
        /// Give the stick in function of the instruction value
        /// </summary>
        /// <param name="instructionStickValue"></param>
        /// <returns></returns>
        private bool HasStick(string instructionStickValue)
        {
            if (instructionStickValue == "1")
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
