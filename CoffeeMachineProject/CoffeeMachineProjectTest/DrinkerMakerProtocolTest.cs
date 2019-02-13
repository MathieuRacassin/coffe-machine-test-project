using CoffeeMachineProject;
using Moq;
using System;
using Xunit;

namespace CoffeMachineProjectTest
{
    public class DrinkerMakerProtocolTest
    {
        [Fact]
        public void ConstructorEmptyTest()
        {
            var drinkMaker = new DrinkMaker();

            Assert.Equal(string.Empty, drinkMaker.Drink);
            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(string.Empty, drinkMaker.Instruction);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);
        }

        [Fact]
        public void ConstructorTest()
        {
            var beverageQuantity = new Mock<IBeverageQuantityChecker>(MockBehavior.Strict);

            //Sugar/ No Stick case
            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Tea))
                    .Returns(false);
            var instruction = "T:1:";
            var drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.Tea, drinkMaker.Drink);
            Assert.True(drinkMaker.Stick);
            Assert.Equal(1, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            //No sugar / no stick case
            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Chocolate))
                    .Returns(false);
            instruction = "H::";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.Chocolate, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            // Sugar/stick case
            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Coffee))
                    .Returns(false);
            instruction = "C:2:1";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.Coffee, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(2, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            // No sugar/ stick case
            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Coffee))
                    .Returns(false);
            instruction = "C:0:0";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.Coffee, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            //Runnig out drink
            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Coffee))
                .Returns(true);
            instruction = "C:0:0";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(string.Empty, drinkMaker.Drink);
            Assert.Equal("Your coffee machine is running out of milk or water for " + DrinkType.Coffee, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);
        }

        [Fact]
        public void ExtaHotAndOrangeJuiceDrinkTest()
        {
            var beverageQuantity = new Mock<IBeverageQuantityChecker>(MockBehavior.Strict);

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.OrangeJuice))
                    .Returns(false);
            var instruction = "O::";
            var drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.OrangeJuice, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.CoffeeExtraHot))
                    .Returns(false);
            instruction = "Ch::";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.CoffeeExtraHot, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.ChocolateExtraHot))
                    .Returns(false);
            instruction = "Hh:1:0";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.ChocolateExtraHot, drinkMaker.Drink);
            Assert.True(drinkMaker.Stick);
            Assert.Equal(1, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.TeaExtraHot))
                    .Returns(false);
            instruction = "Th:2:0";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(DrinkType.TeaExtraHot, drinkMaker.Drink);
            Assert.True(drinkMaker.Stick);
            Assert.Equal(2, drinkMaker.SugarQuantity);

            Assert.Equal(string.Empty, drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);
        }

        [Fact]
        public void MessageTest()
        {
            var beverageQuantity = new Mock<IBeverageQuantityChecker>(MockBehavior.Strict);
            beverageQuantity.Setup(e => e.IsEmpty("M"))
                    .Returns(false);

            var instruction = "M:message-content";
            var drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal(string.Empty, drinkMaker.Drink);
            Assert.False(drinkMaker.Stick);
            Assert.Equal(0, drinkMaker.SugarQuantity);

            Assert.Equal("message-content", drinkMaker.Message);
            Assert.Equal(instruction, drinkMaker.Instruction);
        }

        [Fact]
        public void ToStringTest()
        {
            var beverageQuantity = new Mock<IBeverageQuantityChecker>(MockBehavior.Strict);
            beverageQuantity.Setup(e => e.IsEmpty("M"))
                    .Returns(false);

            var instruction = "M:message-content";
            var drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal("message-content", drinkMaker.ToString());

            beverageQuantity.Setup(e => e.IsEmpty(DrinkType.Coffee))
                    .Returns(false);
            instruction = "C:2:1";
            drinkMaker = new DrinkMaker(instruction, beverageQuantity.Object);

            Assert.Equal("C:2:False", drinkMaker.ToString());
        }
    }
}
