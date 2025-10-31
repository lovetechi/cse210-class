using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private const string Separator = "~|~"; // unlikely to appear in normal text

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
            return;
        }

        foreach (var e in _entries)
        {
            Console.WriteLine("===============================");
            Console.WriteLine(e.ToString());
        }
        Console.WriteLine("===============================");
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var e in _entries)
            {
                // Save as: date~|~prompt~|~response
                writer.WriteLine($"{e.Date}{Separator}{e.Prompt}{Separator}{e.Response}");
            }
        }
    }

    public void Load(string filename)
    {
        var newEntries = new List<Entry>();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(new string[] { Separator }, StringSplitOptions.None);
                if (parts.Length >= 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    // If response contains separator it will have been split; re-join the rest
                    string response = string.Join(Separator, parts, 2, parts.Length - 2);
                    newEntries.Add(new Entry(prompt, response, date));
                }
            }
        }

        _entries = newEntries;
    }
}
