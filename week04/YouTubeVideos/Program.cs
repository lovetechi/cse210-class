using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a few sample videos
        var videos = new List<Video>();

        var v1 = new Video("Learning C# Basics", "CodeAcademy", 420);
        v1.AddComment(new Comment("Alice", "Great introduction!"));
        v1.AddComment(new Comment("Bob", "Very helpful, thanks."));
        v1.AddComment(new Comment("Charlie", "Could you cover LINQ next?"));

        var v2 = new Video("Top 10 Productivity Tips", "ProductiveLife", 600);
        v2.AddComment(new Comment("Dan", "These tips changed my workflow."));
        v2.AddComment(new Comment("Eve", "Nice examples."));
        v2.AddComment(new Comment("Frank", "Thanks for sharing!"));

        var v3 = new Video("Guitar for Beginners", "MusicMaster", 900);
        v3.AddComment(new Comment("Grace", "I can finally play my first song."));
        v3.AddComment(new Comment("Heidi", "Clear and patient teacher."));
        v3.AddComment(new Comment("Ivan", "Loved the chord diagram."));

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        // Display each video with its comments
        foreach (var video in videos)
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine(video.ToString());
            Console.WriteLine("Comments:");
            foreach (var c in video.GetComments())
            {
                Console.WriteLine("- " + c.ToString());
            }
            Console.WriteLine();
        }
    }
}