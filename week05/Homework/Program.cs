using System;

class Program
{
    static void Main(string[] args)
    {
        var simple = new Assignment("John Doe", "Math Homework");
        Console.WriteLine(simple.GetSummary());

        // Math assignment example
        var math = new MathAssignment("Jane Smith", "Algebra", "5.2", "1-10");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        // Writing assignment example
        var writing = new WrittingAssignment("Alice Johnson", "Essay on Climate Change", "Climate Change");
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}