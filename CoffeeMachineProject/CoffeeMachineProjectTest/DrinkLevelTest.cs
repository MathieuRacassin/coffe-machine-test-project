using CoffeeMachineProject;
using System;
using Xunit;

namespace CoffeeMachineProjectTest
{
    public class DrinkLevelTest
    {
        [Fact]
        public void ConstructorTest()
        {
            var drinkLevel = new DrinkLevel()
            {
                MilkLevel = 4,
                WaterLevel = 4,
                OrangeJuiceLevel = 1
            };

            Assert.Equal(4, drinkLevel.MilkLevel);
            Assert.Equal(4, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);
        }

        [Fact]
        public void IsEmptyEmptyStringTest()
        {
            var drinkLevel = new DrinkLevel()
            {
                MilkLevel = 4,
                WaterLevel = 4,
                OrangeJuiceLevel = 1
            };

            var isEmpty = drinkLevel.IsEmpty(string.Empty);

            Assert.False(isEmpty);

            Assert.Equal(4, drinkLevel.MilkLevel);
            Assert.Equal(4, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);
        }

        [Fact]
        public void IsEmptyChocolateTest()
        {
            var drinkLevel = new DrinkLevel()
            {
                MilkLevel = 0,
                WaterLevel = 4,
                OrangeJuiceLevel = 1
            };

            var isEmpty = drinkLevel.IsEmpty(DrinkType.Chocolate);

            Assert.True(isEmpty);

            Assert.Equal(0, drinkLevel.MilkLevel);
            Assert.Equal(4, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);

            drinkLevel.WaterLevel = 0;

            isEmpty = drinkLevel.IsEmpty(DrinkType.ChocolateExtraHot);

            Assert.True(isEmpty);

            Assert.Equal(0, drinkLevel.MilkLevel);
            Assert.Equal(0, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);
        }

        [Fact]
        public void IsEmptyCoffeeTest()
        {
            var drinkLevel = new DrinkLevel()
            {
                MilkLevel = 0,
                WaterLevel = 4,
                OrangeJuiceLevel = 1
            };

            var isEmpty = drinkLevel.IsEmpty(DrinkType.Coffee);

            Assert.True(isEmpty);

            Assert.Equal(0, drinkLevel.MilkLevel);
            Assert.Equal(4, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);

            drinkLevel.WaterLevel = 0;

            isEmpty = drinkLevel.IsEmpty(DrinkType.CoffeeExtraHot);

            Assert.True(isEmpty);

            Assert.Equal(0, drinkLevel.MilkLevel);
            Assert.Equal(0, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);
        }

        [Fact]
        public void IsEmptyTeaTest()
        {
            var drinkLevel = new DrinkLevel()
            {
                MilkLevel = 1,
                WaterLevel = 0,
                OrangeJuiceLevel = 1
            };

            var isEmpty = drinkLevel.IsEmpty(DrinkType.Tea);

            Assert.True(isEmpty);

            Assert.Equal(1, drinkLevel.MilkLevel);
            Assert.Equal(0, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);

            isEmpty = drinkLevel.IsEmpty(DrinkType.TeaExtraHot);

            Assert.True(isEmpty);

            Assert.Equal(1, drinkLevel.MilkLevel);
            Assert.Equal(0, drinkLevel.WaterLevel);
            Assert.Equal(1, drinkLevel.OrangeJuiceLevel);
        }


        [Fact]
        public void IsEmptyOrangeJuiceTest()
        {
            var drinkLevel = new DrinkLevel()
            {
                MilkLevel = 0,
                WaterLevel = 4,
                OrangeJuiceLevel = 0
            };

            var isEmpty = drinkLevel.IsEmpty(DrinkType.OrangeJuice);

            Assert.True(isEmpty);

            Assert.Equal(0, drinkLevel.MilkLevel);
            Assert.Equal(4, drinkLevel.WaterLevel);
            Assert.Equal(0, drinkLevel.OrangeJuiceLevel);
        }

    }
}
