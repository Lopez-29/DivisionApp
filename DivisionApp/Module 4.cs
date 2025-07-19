using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Division Program with Exception Handling ===");

        Console.Write("Enter the first number: ");
        string input1 = Console.ReadLine();

        Console.Write("Enter the second number: ");
        string input2 = Console.ReadLine();

        DivideStrings(input1, input2);

        Console.WriteLine("Program finished.");
    }

    static void DivideStrings(string strNum1, string strNum2)
    {
        try
        {
            // Attempt to convert both strings to integers
            int num1 = Convert.ToInt32(strNum1);
            int num2 = Convert.ToInt32(strNum2);

            // Perform division
            int result = Divide(num1, num2);
            Console.WriteLine($"Result: {num1} / {num2} = {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid whole numbers.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: One of the numbers is too large or too small.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error occurred: {ex.Message}");

        }
    }

    static int Divide(int dividend, int divisor)
    {
        return dividend / divisor;
    }
}
