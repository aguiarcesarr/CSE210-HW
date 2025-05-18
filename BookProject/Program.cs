using System;

class Program
{
    static void Main(string[] args)
    {
        Book myBook = new Book();
        myBook._title = "To Kill a Mockingbird";
        myBook._author = "Harper Lee";
        myBook._yearPublished = 1960;

        myBook.DisplayInfo();

        int age = myBook.GetAge();
        Console.WriteLine($"This book is {age} years old.");
    }
}
// public class Book