using Labb_3___XUnit_och_Acceptanstestning;
using System;
using Xunit;

namespace TestTheCalculatorAppXUnit
{
    public class TestTheCalculator
    {
        [Theory]
        [InlineData(47, 119, 166)]
        [InlineData(936, -274, 662)]
        [InlineData(-98, 65, -33)]
        [InlineData(39.25, 34.20, 73.45)]
        [InlineData(23, -17, 6)]
        public void Test_Addition_Method_Return_Correct_Sum(double num1, double num2, double expectedResult)
        {
            // Arrange
            var calc = new Calculator(num1, num2);

            // Act
            var actualResult = calc.Addition();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(345, 45, 300)]
        [InlineData(30, -20, 50)]
        [InlineData(-300, 3, -303)]
        [InlineData(5.5, -20.7, 26.2)]
        [InlineData(17, -17, 34)]
        public void Test_Subtraction_Method_Return_Correct_Sum(double num1, double num2, double expectedResult)
        {
            // Arrange
            var calc = new Calculator(num1, num2);

            // Act
            var actualResult = calc.Subtraction();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(100, 2, 50)]
        [InlineData(50, 2, 25)]
        [InlineData(-300, 3, -100)]
        [InlineData(10.5, 2, 5.25)]
        [InlineData(8.24, 2, 4.12)]
        public void Test_Division_Method_Return_Correct_Sum(double num1, double num2, double expectedResult)
        {
            // Arrange
            var calc = new Calculator(num1, num2);

            // Act
            var actualResult = calc.Division();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(10, 2, 20)]
        [InlineData(100, 10, 1000)]
        [InlineData(5, 2, 10)]
        [InlineData(9, -3, -27)]
        [InlineData(-78, 6, -468)]
        public void Test_Multiplication_Method_Return_Correct_Sum(double num1, double num2, double expectedResult)
        {
            // Arrange
            var calc = new Calculator(num1, num2);

            // Act
            var actualResult = calc.Multiplication();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(3, 3, 27)]
        [InlineData(4, 8, 65536)]
        [InlineData(9, 2, 81)]
        [InlineData(4, -3, 0.015625)]
        [InlineData(10, -3, 0.001)]
        public void Test_Power_Method_Return_Correct_Sum(double num1, double num2, double expectedResult)
        {
            // Arrange
            var calc = new Calculator(num1, num2);

            // Act
            var actualResult = calc.Power();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, -1)]
        public void Test_UserInPut_Method_Return_Correct_Double_Value(double num, double expectedResult)
        {
            // Arrange
            var calc = new Calculator
            {
                UserInPutProp = num
            };

            // Act
            var actualResult = calc.UserInPutMethod();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Test_DisplayResult_Method_Return_Existing_Object_And_Correct_Double_Value()
        {
            // Arrange
            var calc = new Calculator(3, 7);

            // Act
            calc.Addition();
            calc.DisplayResult("+");
            var expectedResult = 10;
            var actualResult = calc.ListOfCalculatorHistory[0].CHSum;

            // Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.True(calc.ListOfCalculatorHistory.Exists(c => c.CHNum1 == 3 && calc.ListOfCalculatorHistory.Exists(c => c.CHNum2 == 7 && calc.ListOfCalculatorHistory.Exists(c => c.CHSum == 10 && calc.ListOfCalculatorHistory.Exists(c => c.CHSymbol == "+")))));
        }

        [Theory]
        [InlineData(10.5, 10.25, 1, 1)]
        [InlineData(25, 25, 2, 50)]
        [InlineData(15, -10, 1, 1)]
        [InlineData(-25, 20, 2, -5)]
        [InlineData(87, -29, 2, 58)]
        public void Test_UseOldResultOrInputNewNumber_Method_Return_Correct_Expected_Result(double num1, double num2, double userInPutValue, double expectedResult)
        {
            // Arrange
            var calc = new Calculator(num1, num2)
            {
                UserInPutProp = userInPutValue
            };

            // Act
            calc.Addition();
            calc.DisplayResult("+");
            var actualResult = calc.UseOldResultOrInputNewNumber();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
