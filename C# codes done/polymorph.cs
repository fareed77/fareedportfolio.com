// Namespace declaration
using System;

namespace ConsoleApp
{
    // Define an interface named IQuittable
    interface IQuittable
    {
        // Define a void method Quit() in the interface
        void Quit();
    }

    // Define the Employee class inheriting from IQuittable
    public class Employee : IQuittable
    {
        // Properties of the Employee class (example: FirstName and LastName)
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Implement the Quit() method defined in the IQuittable interface
        public void Quit()
        {
            // Display a message indicating the employee has quit
            Console.WriteLine($"Employee {FirstName} {LastName} has quit their job.");
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // Create an Employee object and set its properties
            Employee employee = new Employee { FirstName = "John", LastName = "Doe" };

            // Use polymorphism to create an IQuittable object referencing the Employee object
            IQuittable quittableEmployee = employee;

            // Call the Quit() method on the IQuittable object
            quittableEmployee.Quit();

            // Keep the console window open until the user presses a key
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
