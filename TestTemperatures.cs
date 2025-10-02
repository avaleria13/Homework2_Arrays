using static System.Console;

namespace TestTemperatures
{
    public class TemperatureTests
    {
        [Fact]
        public void TestAnalyzeTrend_ReturnsGettingWarmer()
        {
            // Test data and expected result
            double[] temps = { 60, 65, 70, 75, 80 }; // increasing temperatures
            string expected = "Getting warmer";

            // Act: Call the method being tested
            string actual = TemperaturesComparison.AnalyzeTrend(temps);

            // Assert: Verify the result
            if (actual == expected)
                WriteLine("Test Passed: AnalyzeTrend correctly identifies warming trend.");
            else
                WriteLine($"Test Failed: Expected '{expected}' but got '{actual}'.");
        }
    }
}
