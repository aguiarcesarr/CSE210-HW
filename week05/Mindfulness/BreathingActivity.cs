using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
          )
    {
    }

    public override void Run()
    {
        var startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("\nBreathe in... ");
            PauseWithCoundtdown(4);   // 4-second inhale

            Console.Write("\nBreathe out... ");
            PauseWithCoundtdown(4);   // 4-second exhale
        }
    }
}
