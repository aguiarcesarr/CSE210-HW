using System;

public abstract class Goal
{
    private string _name;
    protected string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual void Display()
    {
        Console.WriteLine($"[{(IsComplete() ? "X" : " ")}] {_name} ({_description})");
    }

    public virtual string GetStringRepresentation()
    {
        return $"{GetType().Name}:{_name}|{_description}|{_points}";
    }

    public string GetName()
    {
        return _name;
    }

    public int GetPoints()
    {
        return _points;
    }
}