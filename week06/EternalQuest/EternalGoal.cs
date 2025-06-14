using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Eternal goals are never complete, but recording them earns points.
        // No need to change any state here, the GoalManager will handle adding points.
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete.
    }

    public override void Display()
    {
        Console.WriteLine($"[ ] {GetName()} ({GetDescription()}) - Keep it up!");
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{GetName()}|{GetDescription()}|{GetPoints()}";
    }

    public static EternalGoal FromString(string line)
    {
        string[] parts = line.Split('|');
        return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
    }

    public string GetDescription()
    {
        // Added a getter for description
        return _description;
    }
}