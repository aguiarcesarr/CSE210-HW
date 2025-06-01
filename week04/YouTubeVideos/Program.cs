using System;

class Program
{
    static void Main(string[] args)
    {
        // List of Videos
        Video video1 = new Video
        {
            Title = "Learning C# Basics",
            Author = "ProgrammingDoe",
            LengthInSeconds = 338
        };
        Video video2 = new Video
        {
            Title = "Advanced C# Techniques",
            Author = "CodeMaster",
            LengthInSeconds = 720
        };

        Video video3 = new Video
        {
            Title = "C# Design Patterns",
            Author = "DesignGuru",
            LengthInSeconds = 540
        };

        // Adding comments to Videos

        video1.AddComment(new Comment("Alice", "Great introduction to C#!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I love the examples!"));

        video2.AddComment(new Comment("Dave", "This is exactly what I needed!"));
        video2.AddComment(new Comment("Eve", "Advanced topics explained well."));
        video2.AddComment(new Comment("Frank", "I learned a lot from this video."));

        video3.AddComment(new Comment("Grace", "Design patterns are so useful!"));
        video3.AddComment(new Comment("Helen", "This video is a game-changer!"));
        video3.AddComment(new Comment("Ian", "I wish I had seen this earlier."));

        //List of Videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying Video Information and Comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }    
}