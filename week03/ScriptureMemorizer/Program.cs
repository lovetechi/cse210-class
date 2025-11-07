using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // A small library of scriptures (you can add more or load from a file)
        var scriptures = new List<Scripture>
        {
            new Scripture(
                new ScriptureReference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),

            new Scripture(
                new ScriptureReference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
        };

        var rand = new Random();
        var scripture = scriptures[rand.Next(scriptures.Count)];

        RunMemorizer(scripture);
    }

    static void RunMemorizer(Scripture scripture)
    {
        const int hideEachStep = 3; // number of words hidden each Enter press

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.AllHidden())
            {
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to hide some words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(hideEachStep);
        }
    }
}