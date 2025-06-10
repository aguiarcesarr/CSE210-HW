using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.DisplayStart();
                    breathing.Run();
                    breathing.DisplayEnd();
                    break;

                case "2":
                    var reflection = new ReflectionActivity();
                    reflection.DisplayStart();
                    reflection.Run();
                    reflection.DisplayEnd();
                    break;

                case "3":
                    var listing = new ListingActivity();
                    listing.DisplayStart();
                    listing.Run();
                    listing.DisplayEnd();
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;        
            }
        }
    }
}