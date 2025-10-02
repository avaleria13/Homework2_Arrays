using static System.Console;

namespace TestChatAWhile
{
    public class TestChatAWhile
    {
        [Fact]
        public static void TestCalculateCost()
        {
            // Arrange
            int areaCode = 414;
            int minutes = 10;
            double expected = 1.00;  // 0.10 * 10

            // Act
            double rate = ChatAWhile.GetRate(areaCode);
            double actual = ChatAWhile.CalculateCost(rate, minutes);

            // Assert
            if (Math.Abs(actual - expected) < 0.0001)
                WriteLine("Test Passed: CalculateCost works correctly.");
            else
                WriteLine($"Test Failed: Expected {expected}, but got {actual}.");
        }
    }
}