using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Testing Square Class.");
        Square mySquare = new Square("Red", 5.0);
        Console.WriteLine($"Color: {mySquare.Color}");
        Console.WriteLine($"Area: {mySquare.Area()}");
        Console.WriteLine();

        // Testing Rectangle Class
        Console.WriteLine("Testing Rectangle Class.");
        Rectangle myRectangle = new Rectangle("Blue", 4.0, 6.0);
        Console.WriteLine($"Color: {myRectangle.Color}");
        Console.WriteLine($"Area: {myRectangle.Area()}");
        Console.WriteLine();

        // Testing Circle Class
        Console.WriteLine("Testing Circle Class.");
        Circle myCircle = new Circle("Green", 3.0);
        Console.WriteLine($"Color: {myCircle.Color}");
        Console.WriteLine($"Area: {myCircle.Area()}");
        Console.WriteLine();
    }
}