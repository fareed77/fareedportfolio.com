using System;

namespace ConsoleAppAssignment
{
    // Define a class named MathOperations
    class MathOperations
    {
        // Create a void method that takes two integers as parameters
        public void PerformOperation(int num1, int num2)
        {
            // Perform a math operation on the first integer (e.g., multiply by 2)
            int result = num1 * 2;

            // Display the result of the math operation
            Console.WriteLine($"The result of multiplying the first number ({num1}) by 2 is: {result}");

            // Display the second integer to the screen
            Console.WriteLine($"The second number is: {num2}");
        }
    }

    // Main class where program execution begins
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the MathOperations class
            MathOperations mathOps = new MathOperations();

            // Call the method in the class, passing two numbers directly
            Console.WriteLine("Calling the method with positional parameters:");
            mathOps.PerformOperation(5, 10); // Pass two integers: 5 and 10

            // Call the method in the class, specifying the parameters by name
            Console.WriteLine("\nCalling the method with named parameters:");
            mathOps.PerformOperation(num1: 7, num2: 15); // Specify parameters explicitly by name

            // Keep the console window open until the user presses Enter
            Console.WriteLine("\nPress Enter to exit the program...");
            Console.ReadLine();
        }
    }
}
