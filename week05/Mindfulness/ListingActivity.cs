using System;
using System.Collections.Generic;

#nullable enable

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
          )
    {
    }

    public override void Run()
    {
        // 1. Pick and show a prompt
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine("\n--- Prompt ---");
        Console.WriteLine(prompt);

        // 2. Countdown so the user can prepare
        Console.WriteLine("\nYou may begin listing in:");
        PauseWithCoundtdown(5);

        // 3. Read items until time runs out
        var items = new List<string>();
        var startTime = DateTime.Now;
        Console.WriteLine("\nStart listing! Enter each item, then press Enter.\n");
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("> ");
            string? entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
            {
                items.Add(entry.Trim());
            }
        }

        // 4. Show how many items were entered
        Console.WriteLine($"\nYou listed {items.Count} items!");
    }
}
