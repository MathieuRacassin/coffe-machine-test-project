using CoffeeMachineProject;
using System;
using Xunit;


namespace CoffeMachineProjectTest
{
    public class DrinkMakerAuthorizationTest
    { 
        [Fact]
        public void ConstructorTest()
        {
            var authorization = new DrinkMakerAuthorization(0.0);

            Assert.Equal(0.0, authorization.Acount);
            Assert.False(authorization.IsAuthorized);
        }

        [Fact]
        public void DrinkProviderTest()
        {
            var authorization = new DrinkMakerAuthorization(0.7);

            var drink = authorization.ProvideDrink("T:1:0");

            Assert.Equal(DrinkType.Tea, drink.Drink);
            Assert.Equal(1, drink.SugarQuantity);
            Assert.True(drink.Stick);

            authorization = new DrinkMakerAuthorization(0.7);

            drink = authorization.ProvideDrink("C:1:0");

            Assert.Equal(DrinkType.Coffee, drink.Drink);
            Assert.Equal(1, drink.SugarQuantity);
            Assert.True(drink.Stick);

            authorization = new DrinkMakerAuthorization(0.7);

            drink = authorization.ProvideDrink("H:1:0");

            Assert.Equal(DrinkType.Chocolate, drink.Drink);
            Assert.Equal(1, drink.SugarQuantity);
            Assert.True(drink.Stick);
        }

        [Fact]
        public void DrinkExtraHotandOrangeJuiceProviderTest()
        {
            var authorization = new DrinkMakerAuthorization(0.7);

            var drink = authorization.ProvideDrink("Th:1:0");

            Assert.Equal(DrinkType.TeaExtraHot, drink.Drink);
            Assert.Equal(1, drink.SugarQuantity);
            Assert.True(drink.Stick);

            authorization = new DrinkMakerAuthorization(0.7);

            drink = authorization.ProvideDrink("Ch:1:0");

            Assert.Equal(DrinkType.CoffeeExtraHot, drink.Drink);
            Assert.Equal(1, drink.SugarQuantity);
            Assert.True(drink.Stick);

            authorization = new DrinkMakerAuthorization(0.7);

            drink = authorization.ProvideDrink("Hh:1:0");

            Assert.Equal(DrinkType.ChocolateExtraHot, drink.Drink);
            Assert.Equal(1, drink.SugarQuantity);
            Assert.True(drink.Stick);

            drink = authorization.ProvideDrink("O::");

            Assert.Equal(DrinkType.OrangeJuice, drink.Drink);
            Assert.Equal(0, drink.SugarQuantity);
            Assert.False(drink.Stick);
        }

        [Fact]
        public void DrinkProviderNoEnoughMoneyTest()
        {
            var authorization = new DrinkMakerAuthorization(0.2);

            var drink = authorization.ProvideDrink("T:1:0");

            Assert.Equal(string.Empty, drink.Drink);
            Assert.False(drink.Stick);
            Assert.Equal(0, drink.SugarQuantity);

            Assert.Equal("It's missing 0,2 € for your tea", drink.Message);
            Assert.Equal("M:It's missing 0,2 € for your tea", drink.Instruction);

            authorization = new DrinkMakerAuthorization(0.2);

            drink = authorization.ProvideDrink("H:1:0");

            Assert.Equal(string.Empty, drink.Drink);
            Assert.False(drink.Stick);
            Assert.Equal(0, drink.SugarQuantity);

            Assert.Equal("It's missing 0,3 € for your chocolate", drink.Message);
            Assert.Equal("M:It's missing 0,3 € for your chocolate", drink.Instruction);

            authorization = new DrinkMakerAuthorization(0.2);

            drink = authorization.ProvideDrink("C:1:0");

            Assert.Equal(string.Empty, drink.Drink);
            Assert.False(drink.Stick);
            Assert.Equal(0, drink.SugarQuantity);

            Assert.Equal("It's missing 0,4 € for your coffee", drink.Message);
            Assert.Equal("M:It's missing 0,4 € for your coffee", drink.Instruction);

            drink = authorization.ProvideDrink("O::");

            Assert.Equal(string.Empty, drink.Drink);
            Assert.False(drink.Stick);
            Assert.Equal(0, drink.SugarQuantity);

            Assert.Equal("It's missing 0,4 € for your orange juice", drink.Message);
            Assert.Equal("M:It's missing 0,4 € for your orange juice", drink.Instruction);
        }
    }
}

