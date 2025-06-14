using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        LoadGoals(); // Load goals when the program starts

        int choice;
        do
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice from the menu: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal();
                        break;
                    case 2:
                        ListGoals();
                        break;
                    case 3:
                        RecordEvent();
                        break;
                    case 4:
                        DisplayScore();
                        break;
                    case 5:
                        SaveGoals();
                        break;
                    case 6:
                        LoadGoals();
                        break;
                    case 7:
                        Console.WriteLine("Thank you for playing Eternal Quest!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 7);
    }

    private void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        if (int.TryParse(Console.ReadLine(), out int goalType))
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Write("What is a short description of your goal? ");
            string description = Console.ReadLine();
            Console.Write("What is the amount of points associated with this goal? ");
            if (int.TryParse(Console.ReadLine(), out int points))
            {
                switch (goalType)
                {
                    case 1:
                        _goals.Add(new SimpleGoal(name, description, points));
                        Console.WriteLine("Simple goal created successfully!");
                        break;
                    case 2:
                        _goals.Add(new EternalGoal(name, description, points));
                        Console.WriteLine("Eternal goal created successfully!");
                        break;
                    case 3:
                        Console.Write("How many times does this goal need to be accomplished in total? ");
                        if (int.TryParse(Console.ReadLine(), out int targetCount))
                        {
                            Console.Write("What is the bonus points for accomplishing it that many times? ");
                            if (int.TryParse(Console.ReadLine(), out int bonusPoints))
                            {
                                _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints));
                                Console.WriteLine("Checklist goal created successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for bonus points.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for target count.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid goal type selected.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input for points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for goal type.");
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _goals[i].Display();
            }
        }
    }

    private void RecordEvent()
    {
        Console.Write("Enter the number of the goal you have completed: ");
        if (int.TryParse(Console.ReadLine(), out int goalNumber))
        {
            if (goalNumber > 0 && goalNumber <= _goals.Count)
            {
                Goal selectedGoal = _goals[goalNumber - 1];
                selectedGoal.RecordEvent();
                Console.WriteLine($"Event recorded for: {selectedGoal.GetName()}");

                // Award points
                int pointsEarned = selectedGoal.GetPoints();
                if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    pointsEarned += checklistGoal.GetBonusPoints();
                }
                _score += pointsEarned;
                Console.WriteLine($"You earned {pointsEarned} points!");
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    private void DisplayScore()
    {
        Console.WriteLine($"Your current score is: {_score}");
    }

    private void SaveGoals()
    {
        Console.WriteLine("Saving goals...");
        string filename = "goals.txt";
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score); // Save the score first
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully to " + filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving goals: " + ex.Message);
        }
    }

    private void LoadGoals()
    {
        Console.WriteLine("Loading goals...");
        string filename = "goals.txt";
        if (File.Exists(filename))
        {
            try
            {
                _goals.Clear(); // Clear existing goals before loading
                using (StreamReader reader = new StreamReader(filename))
                {
                    if (reader.ReadLine() is string scoreLine && int.TryParse(scoreLine, out int loadedScore))
                    {
                        _score = loadedScore;
                    }
                    else
                    {
                        Console.WriteLine("Warning: Could not load the score from the save file, or file is empty.");
                        _score = 0; // Default score if loading fails
                    }

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        if (parts.Length == 2)
                        {
                            string goalType = parts[0];
                            string goalData = parts[1];
                            switch (goalType)
                            {
                                case "SimpleGoal":
                                    _goals.Add(SimpleGoal.FromString(goalData));
                                    break;
                                case "EternalGoal":
                                    _goals.Add(EternalGoal.FromString(goalData));
                                    break;
                                case "ChecklistGoal":
                                    _goals.Add(ChecklistGoal.FromString(goalData));
                                    break;
                                default:
                                    Console.WriteLine($"Unknown goal type found in file: {goalType}");
                                    break;
                            }
                        }
                    }
                }
                Console.WriteLine("Goals loaded successfully from " + filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading goals: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public int GetScore()
    {
        return _score;
    }
}