using System;

class Program
{
    static void Main(string[] args)
    {
        // This program asks the user for their first and last name and then greets them.
        Console.Write("What is your first name?.");
       
        string firstName = Console.ReadLine();
        
        Console.Write("What is your last name?.");
       
        string lastName = Console.ReadLine();
       
        Console.WriteLine($"Hello {lastName}, {firstName} {lastName}!");
    }
}