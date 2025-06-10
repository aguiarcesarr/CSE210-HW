using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStart()
    {
        Console.Clear();
        Console.WriteLine($"== {_name} ==\n");
        Console.WriteLine($"{_description}\n");
        Console.WriteLine("Enter the duration in seconds for this activity:");
        _duration = int.Parse(Console.ReadLine()!);
        Console.WriteLine("\nGet ready to begin...");
        PauseWithSpinner(3);
    }

    public void DisplayEnd()
    {
        Console.Clear();
        Console.WriteLine($"== {_name} ==\n");
        Console.WriteLine("Well done!");
        Console.WriteLine($"You completed the activity for {_duration} seconds.");
        PauseWithSpinner(3);
    }

    protected void PauseWithSpinner(int seconds)
    {
        var spinner = new[] { '|', '/', '-', '\\' };
        var start = DateTime.Now;
        int i = 0;
        while ((DateTime.Now - start).TotalSeconds < seconds)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b"); // Erase the spinner character
            i++;
        }
    }

    protected void PauseWithCoundtdown(int seconds)
    {
        for (int i = seconds; i > 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public abstract void Run();
}