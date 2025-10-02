/* The Chat-A-While phone company provides service to six area codes 
 * and charges the per-minute rates for phone calls shown in Figure 6-25. 
 * Write a program named ChatAWhile that stores the area codes and rates 
 * in parallel arrays and allows a user to enter an area code and the length 
 * of time for a call in minutes. Display the total cost of the call or an error 
 * message if the area code is not found. */

using static System.Console;

public class ChatAWhile
{
    // SRP: Arrays to store area codes and rates 
    static int[] areaCodes = { 262, 414, 608, 715, 815, 920 }; 
    static double[] rates = { 0.07, 0.10, 0.05, 0.16, 0.24, 0.14 }; 

    // SRP: Method to get the rate for a given area code
    public static double GetRate(int code)
    {
        for (int i = 0; i < areaCodes.Length; i++)
        {
            if (areaCodes[i] == code)
                return rates[i];
        }
        return -1; // Not found
    }

    // SRP: Method to calculate total cost
    public static double CalculateCost(double rate, int minutes)
    {
        return rate * minutes;
    }

    // Feature added: Apply discount for long calls
    public static double ApplyDiscount(double totalCost, int minutes)
    {
        if (minutes > 180)
        {
            WriteLine("You qualify for a 5% long call discount!");
            return totalCost * 0.95;  // 5% discount
        }
        return totalCost;
    }

    // Show all available codes and rates before input
    public static void DisplayAvailableCodes()
    {
        WriteLine("\nAvailable area codes and rates:");
        for (int i = 0; i < areaCodes.Length; i++)
        {
            WriteLine($"Area Code: {areaCodes[i]} - Rate: ${rates[i]:F2}/min");
        }
        WriteLine();
    }

    // Main Program
    static void Main()
    {
        WriteLine("-- CHATAWHILE COST CALCULATOR ---");

        // Display the available codes
        DisplayAvailableCodes();

        // Feature added: error handling for area code
        int code;
        Write("Enter the area code you want to call: ");
        while (!int.TryParse(ReadLine(), out code))
        {
            Write("Invalid input. Please enter a valid numeric area code: ");
        }

        // Feaute added: error handling for minutes
        int minutes;
        Write("Enter call duration in minutes: ");
        while (!int.TryParse(ReadLine(), out minutes) || minutes <= 0)
        {
            Write("Invalid input. Please enter a positive number of minutes: ");
        }

        // Get rate for area code
        double rate = GetRate(code);

        if (rate == -1)
        {
            WriteLine("Error: Area code not found.");
        }
        else
        {
            double totalCost = CalculateCost(rate, minutes);
            totalCost = ApplyDiscount(totalCost, minutes);  // Apply discount if eligible
            WriteLine($"\nTotal cost for calling {code} for {minutes} minute(s): ${totalCost:F2}");
        }
    }
}

/* SOLID principles used:
1. Single Responsibility: GetRate() --> only finds rate
CalculateCost() --> only calculates cost
DisplayAvailableCodes() --> only displays info
2. O (Open/Closed): I can add new area codes without modifying logic
3. L (Liskov Substitution): each method behaves predictably with valid inputs
4. I (Interface Segregation): no interfaces in this code, but methods are small and focused
5. D (Dependency Inversion): no hard-coupling between unrelated components
*/