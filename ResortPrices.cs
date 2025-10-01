/* 7. Write a program for The Carefree Resort named ResortPrices 
 * that prompts the user to enter the number of days for a resort 
 * stay. Then display the price per night and the total price. 
 * Nightly rates are $200 for one or two nights; $180 for three 
 * or four nights; $160 for five, six, or seven nights; and $145 
 * for eight nights or more. (6.1–6.3) 
 */

using static System.Console;

public class RePrice
{
    public int Night {  get; }
    public int MaxNight {  get; }
    public double Rate { get; }

    // SRP (Single Responsibility Principle)
    // Class responsible for storing price info and calculating costs
    public RePrice(int night, int max, int rate)
    {
        Night = night;
        MaxNight = max;
        Rate = rate;
    }
        
    public bool AppliesTo(int nights)
    {
        return nights >= Night && nights <= MaxNight;
    }

    public double CalcPrice(int nights)
    {
        return Rate * nights;
    }
};


public class ResortPricesApp
{
    int choice;
    public static void Main()
    {
        // OCP (Open/Closed Principle)
        RePrice[] reprice = new RePrice[]
        {
            new RePrice(1, 2, 200),
            new RePrice(3, 4, 180),
            new RePrice(5, 7, 160),
            new RePrice(8, int.MaxValue, 145)
        };

        WriteLine("Welcome to The Carefree Resort Program");
        WriteLine();
        WriteLine("--- THE CAREFREE PRICES ---");
        PrintPrices(reprice);

        // Feature added: error handling 
        int choice;
        while (true)
        {
            Write("How many nights will you be staying?: ");
            if (int.TryParse(ReadLine(), out choice) && choice > 0)
                break;
            WriteLine("Invalid input. Please enter a positive number.");
        }

        RePrice selected = FindRate(reprice, choice);

        WriteLine($"\nPrice per night: ${selected.Rate}");
        WriteLine($"Total charge for {choice} nights: ${selected.CalcPrice(choice)}");

        // Feature added: apply discount for long or expensive stays
        double total = selected.CalcPrice(choice);
        if (total > 1000)
        {
            double discount = total * 0.10;
            double discountedTotal = total - discount;
            WriteLine($"You qualify for a 10% discount. You are saving ${discount:F2}!");
            WriteLine($"Discounted total price: ${discountedTotal:F2}");
        }

    }

    // SRP
    // Method that only prints the table of prices
    public static void PrintPrices(RePrice[] reprice)
    {
        foreach (RePrice reprices in reprice)
        {
            string maxNightDisplay = reprices.MaxNight == int.MaxValue ? "or more" : reprices.MaxNight.ToString();
            WriteLine($"- Nights: {reprices.Night} to {maxNightDisplay} - Price per night: ${reprices.Rate}");
        }
    }

    // SRP 
    // Method that only finds the correct price bracket
    public static RePrice FindRate(RePrice[] prices, int nights)
    {
        foreach (var p in prices)
        {
            if (p.AppliesTo(nights))
            {
                return p;
            }
        }
        throw new Exception("INVALID -- no matching range");
    }
}