using ArithmeticExecuteServices.Services.Implementations;

namespace ArithmeticExecute.Tests.UnitTests
{
    public class Tests
    {
        [Test]
        public void TestAdd()
        {
            var arithmeticExecuteService = new ArithmeticExecuteService();

            // Arrange
            int num1 = 5;
            int num2 = 3;

            // Act
            int result = arithmeticExecuteService.Add(num1, num2);

            // Assert
            if (result == 8)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void TestSubtract()
        {
            var arithmeticExecuteService = new ArithmeticExecuteService();

            // Arrange
            int num1 = 10;
            int num2 = 4;

            // Act
            int result = arithmeticExecuteService.Subtract(num1, num2);

            // Assert
            if (result == 6)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void TestMultiply()
        {
            var arithmeticExecuteService = new ArithmeticExecuteService();

            // Arrange
            int num1 = 7;
            int num2 = 2;

            // Act
            int result = arithmeticExecuteService.Multiply(num1, num2);

            // Assert
            if (result == 14)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void TestDivide()
        {
            var arithmeticExecuteService = new ArithmeticExecuteService();

            // Arrange
            int num1 = 20;
            int num2 = 5;

            // Act
            int result = arithmeticExecuteService.Divide(num1, num2);

            // Assert
            if (result == 4)
            {
                Assert.Pass();
            }
            Assert.Fail();
        }
    }
}