using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int grade;

        // Validate input
        if (!int.TryParse(input, out grade))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer percentage.");
            return;
        }

        // Determine the letter grade
        string letter = "";
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign for the grade (stretch challenge)
        string sign = "";
        int lastDigit = grade % 10;

        if (letter != "A" && letter != "F") // No A+ or F+/- grades
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A")
        {
            // No A+ grade, only A and A-
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        // For F, no sign

        // Print the letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Check if the user passed the course (>= 70)
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You can do better next time.");
        }
    }
}
