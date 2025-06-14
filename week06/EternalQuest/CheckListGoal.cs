using System;

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _targetCount;
    }

    public override void Display()
    {
        Console.WriteLine($"[{(_timesCompleted >= _targetCount ? "X" : " ")}] {GetName()} ({GetDescription()}) -- Completed {_timesCompleted}/{_targetCount} times");
    }

    public override string GetStringRepresentation()
    {
        return $"{GetType().Name}:{GetName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_bonusPoints}|{_timesCompleted}";
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public int GetTimesCompleted()
    {
        return _timesCompleted;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public static ChecklistGoal FromString(string line)
    {
        string[] parts = line.Split('|');
        return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]))
        {
            _timesCompleted = int.Parse(parts[5])
        };
    }

    public string GetDescription()
    {
        // Added a getter for description
        return _description;
    }
}