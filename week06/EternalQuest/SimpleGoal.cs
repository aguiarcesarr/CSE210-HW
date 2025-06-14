using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

    public static SimpleGoal FromString(string line)
    {
        string[] parts = line.Split('|');
        return new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]))
        {
            _isComplete = bool.Parse(parts[3])
        };
    }

    public string GetDescription()
    {
        // Added a getter for description
        return _description;
    }
}