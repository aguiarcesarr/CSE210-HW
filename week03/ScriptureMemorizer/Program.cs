using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("This program will help you memorize scriptures by displaying them one word at a time.");

        Reference reference = new Reference("John", 3, 16);
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, text);

        int userAttempts = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have memorized the scripture!");
            }

            Console.Write("\nPress Enter to hide more words, or type 'reset' to reset the scripture: ");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit" || input == "exit")
            {
                Console.WriteLine("Thank you for using the Scripture Memorizer. Goodbye!");
                break;
            }
            else if (input == "reset")
            {
                scripture = new Scripture(reference, text);
                userAttempts = 0;
                Console.WriteLine("Scripture has been reset.");
            }
            else
            {
                scripture.HideRandomWord();
                userAttempts++;
                Console.WriteLine($"You have attempted to memorize this scripture {userAttempts} times.");
            }
        }
    }    
}

