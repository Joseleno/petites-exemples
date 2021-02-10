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
            var resultat = calculatrice.Additionner(3, 5);

            //Assert
            Assert.Equal(8, resultat);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 2, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(2, 2, 4)]
        [InlineData(5, 4, 9)]
        [InlineData(1111, 1111, 2222)]
        [InlineData(3, 2, 5)]
        [InlineData(2, 4, 6)]
        public void Additionner_RetournerValeursAddition(int a, int b, int addition)
        {
            //Arrange
            var calculatrice = new Calculatrice();

            //Act
            var resultat = calculatrice.Additionner(a, b);

            //Assert
            Assert.Equal(addition, resultat);
        }
    }
}