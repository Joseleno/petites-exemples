using System;
using Xunit;

namespace AppDeBase.Tests
{
    public class CalculatriceTests
    {
        [Fact]
        public void Additionner_RetournerValeurAddition()
        {
            //Arrange
            var calculatrice = new Calculatrice();

            //Act
            var result = calculatrice.Additionner(3, 5);

            //Assert
            Assert.Equal(8, result);
        }
    }
}