using static System.Console;

// This test evaluates whether the CalcPrice() method works correctly
// for a given number of nights and nightly rate

namespace TestResortPrices
{
    public class TestResortPrices
    {
        [Fact]
        public static void TestCalcPrice()
        {
            // Arrange (setup expected values)
            RePrice priceRange = new RePrice(3, 4, 180);
            int nights = 3;
            double expectedTotal = 540;  // 3 * 180

            // Calls the method being tested
            double actualTotal = priceRange.CalcPrice(nights);

            // Check if the result is correct
            if (actualTotal == expectedTotal)
                WriteLine("Test Passed: CalcPrice() works correctly for 3 nights.");
            else
                WriteLine($"Test Failed: Expected {expectedTotal}, but got {actualTotal}.");
        }
    }
}