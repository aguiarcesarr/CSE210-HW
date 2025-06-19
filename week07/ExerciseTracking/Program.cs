using System;
using System.Collections.Generic;
// Base class: Activity
// Contains shared attributes and defines abstract methods for common behaviors
// that will be implemented differently by derived classes (polymorphism).
public abstract class Activity
{
    // Private member variables, demonstrating encapsulation.
    private DateTime _date;
    private int _minutes;

    // Constructor for the base Activity class.
    // Initializes the common attributes.
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Public properties to access the private data (getters).
    // This allows controlled access to the encapsulated data.
    public DateTime Date
    {
        get { return _date; }
        // Can add a setter here if modification is allowed after creation,
    }

    public int Minutes
    {
        get { return _minutes; }
    }

    public abstract double GetDistance(); // Distance in miles (or km if chosen)
    public abstract double GetSpeed();    // Speed in mph (or kph)
    public abstract double GetPace();     // Pace in min per mile (or min per km)

    // This supports polymorphism for obtaining the activity type.
    public virtual string GetActivityType()
    {
        return "Generic Activity";
    }

    // GetSummary method: Provides a formatted string summary of the activity.
        public virtual string GetSummary()
    {
        // Format the date as "dd MMM yyyy" (e.g., "03 Nov 2022").
        string formattedDate = _date.ToString("dd MMM yyyy");

        return $"{formattedDate} {GetActivityType()} ({_minutes} min): " +
               $"Distance {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }

   
}

// Derived class: Running
// Inherits from Activity and provides specific implementations for running.
public class Running : Activity
{
    // Specific attribute for Running: distance covered.
    private double _distanceMiles;

    // Constructor for Running, calls the base class constructor.
    public Running(DateTime date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    // Overrides the abstract GetDistance method from the base class.
    public override double GetDistance()
    {
        return _distanceMiles;
    }

    // Overrides the abstract GetSpeed method, calculating speed for running.
    // Speed (mph) = (distance / minutes) * 60
    public override double GetSpeed()
    {
        // Avoid division by zero if minutes is 0
        if (Minutes == 0) return 0;
        return (_distanceMiles / Minutes) * 60;
    }

    // Overrides the abstract GetPace method, calculating pace for running.
    // Pace (min per mile) = minutes / distance
    public override double GetPace()
    {
        // Avoid division by zero if distance is 0
        if (_distanceMiles == 0) return 0;
        return (double)Minutes / _distanceMiles;
    }

    // Overrides the virtual GetActivityType method.
    public override string GetActivityType()
    {
        return "Running";
    }

    
}

// Derived class: Cycling
// Inherits from Activity and provides specific implementations for cycling.
public class Cycling : Activity
{
    // Specific attribute for Cycling: average speed.
    private double _speedMph;

    // Constructor for Cycling, calls the base class constructor.
    public Cycling(DateTime date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    // Overrides the abstract GetDistance method, calculating distance for cycling.
    // Distance (miles) = (speed / 60) * minutes
    public override double GetDistance()
    {
        return (_speedMph / 60) * Minutes;
    }

    // Overrides the abstract GetSpeed method, returning the stored speed.
    public override double GetSpeed()
    {
        return _speedMph;
    }

    // Overrides the abstract GetPace method, calculating pace for cycling.
    // Pace (min per mile) = 60 / speed
    // Avoid division by zero if speed is 0
    public override double GetPace()
    {
        if (_speedMph == 0) return 0;
        return 60 / _speedMph;
    }

    // Overrides the virtual GetActivityType method.
    public override string GetActivityType()
    {
        return "Cycling";
    }

}

// Derived class: Swimming
// Inherits from Activity and provides specific implementations for swimming.
public class Swimming : Activity
{
    // Specific attribute for Swimming: number of laps.
    private int _laps;
    // Constants for calculations.
    private const double LAP_LENGTH_METERS = 50.0;
    private const double METERS_PER_MILE = 1609.34; // 1 mile = 1609.34 meters

    // Constructor for Swimming, calls the base class constructor.
    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // Overrides the abstract GetDistance method, calculating distance for swimming.
    // Distance (miles) = swimming laps * 50 / 1609.34 (meters per mile)
    public override double GetDistance()
    {
        return (_laps * LAP_LENGTH_METERS) / METERS_PER_MILE;
    }

    // Overrides the abstract GetSpeed method, calculating speed for swimming.
    // Uses the GetDistance() method which will call the Swimming-specific implementation.
    // Speed (mph) = (distance / minutes) * 60
    public override double GetSpeed()
    {
        if (Minutes == 0) return 0;
        return (GetDistance() / Minutes) * 60;
    }

    // Overrides the abstract GetPace method, calculating pace for swimming.
    // Uses the GetDistance() method which will call the Swimming-specific implementation.
    // Pace (min per mile) = minutes / distance
    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0;
        return (double)Minutes / distance;
    }

    // Overrides the virtual GetActivityType method.
    public override string GetActivityType()
    {
        return "Swimming";
    }

 
  
}

// Program.cs - The main program file where activities are created and processed.
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to hold various activities.
        // This list is typed as 'Activity' (the base class), which is crucial
        // for demonstrating polymorphism.
        List<Activity> activities = new List<Activity>();

        // Create instances of each derived activity type and add them to the list.
        // Note the use of DateTime.Today for dynamic date assignment.
        activities.Add(new Running(DateTime.Today.AddDays(-1), 30, 3.0)); // 3 miles in 30 mins
        activities.Add(new Cycling(DateTime.Today.AddDays(-2), 45, 15.0)); // 15 mph for 45 mins
        activities.Add(new Swimming(DateTime.Today.AddDays(-3), 20, 40));   // 40 laps (50m each) in 20 mins

        // Display a summary of each activity using polymorphism.
        Console.WriteLine("--- Exercise Tracking Summary ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            
        }

        Console.WriteLine("\n--- Program End ---");
    }
}
