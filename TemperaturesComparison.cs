using static System.Console;

public class TemperaturesComparison
{
    // SRP: Method only responsible for validating and collecting temperatures
    public static double[] GetTemperatures(int size)
    {
        double[] temps = new double[size];

        for (int i = 0; i < size; i++)
        {
            double temp;
            bool valid;
            do
            {
                Write($"Enter temperature #{i + 1} (between -30 and 130 °F): ");
                valid = double.TryParse(ReadLine(), out temp) && temp >= -30 && temp <= 130;
                if (!valid)
                {
                    WriteLine("Invalid temperature. Try again.");
                }
            } while (!valid);

            temps[i] = temp;
        }

        return temps;
    }

    // SRP: Method that only analyzes the temperature pattern
    public static string AnalyzeTrend(double[] temps)
    {
        bool increasing = true;
        bool decreasing = true;

        for (int i = 1; i < temps.Length; i++)
        {
            if (temps[i] < temps[i - 1]) increasing = false;
            if (temps[i] > temps[i - 1]) decreasing = false;
        }

        if (increasing) return "Getting warmer";
        if (decreasing) return "Getting cooler";
        return "It’s a mixed bag";
    }

    // SRP: Method that calculates the average temperature
    public static double CalculateAverage(double[] temps)
    {
        double sum = 0;
        foreach (var t in temps)
            sum += t;
        return sum / temps.Length;
    }

    // Feature Added: Display highest and lowest temperature entered
    public static void DisplayMinMax(double[] temps)
    {
        double min = temps[0];
        double max = temps[0];
        foreach (double t in temps)
        {
            if (t < min) min = t;
            if (t > max) max = t;
        }

        WriteLine($"\nLowest temperature: {min} °F");
        WriteLine($"Highest temperature: {max} °F");
    }

    // Entry point
    static void Main()
    {
        WriteLine("--- TEMPERATURES COMPARISON PROGRAM ---\n");

        // Get 5 temperatures
        double[] temps = GetTemperatures(5);

        // Analyze the trend or pattern
        string result = AnalyzeTrend(temps);
        WriteLine($"\nTrend result: {result}");

        // Show temperatures entered
        WriteLine("\nTemperatures entered:");
        foreach (var t in temps)
            Write(t + " ");
        WriteLine();

        // Display average
        double average = CalculateAverage(temps);
        WriteLine($"\nAverage temperature: {average:F2} °F");

        // Feature added: Show min & max temperatures
        DisplayMinMax(temps);
    }
}
