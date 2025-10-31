using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		Journal journal = new Journal();
		PromptGenerator prompts = new PromptGenerator();

		bool running = true;
		while (running)
		{
			Console.WriteLine();
			Console.WriteLine("Journal Menu");
			Console.WriteLine("1. Write a new entry");
			Console.WriteLine("2. Display the journal");
			Console.WriteLine("3. Save the journal to a file");
			Console.WriteLine("4. Load the journal from a file");
			Console.WriteLine("5. Quit");
			Console.Write("Choose an option: ");
			string choice = Console.ReadLine();

			switch (choice)
			{
				case "1":
					WriteEntry(journal, prompts);
					break;
				case "2":
					journal.Display();
					break;
				case "3":
					SaveJournal(journal);
					break;
				case "4":
					LoadJournal(journal);
					break;
				case "5":
					running = false;
					break;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
		}
	}

	static void WriteEntry(Journal journal, PromptGenerator prompts)
	{
		string prompt = prompts.GetRandomPrompt();
		Console.WriteLine("Prompt: " + prompt);
		Console.Write("Your response: ");
	string response = Console.ReadLine();
	if (response == null) response = "";
		string date = DateTime.Now.ToString("yyyy-MM-dd");
		Entry entry = new Entry(prompt, response, date);
		journal.AddEntry(entry);
		Console.WriteLine("Entry added.");
	}

	static void SaveJournal(Journal journal)
	{
		Console.Write("Enter filename to save to: ");
	string filename = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(filename))
		{
			Console.WriteLine("Invalid filename.");
			return;
		}
		try
		{
			journal.Save(filename);
			Console.WriteLine($"Journal saved to {filename}");
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error saving journal: " + ex.Message);
		}
	}

	static void LoadJournal(Journal journal)
	{
		Console.Write("Enter filename to load from: ");
	string filename = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(filename))
		{
			Console.WriteLine("Invalid filename.");
			return;
		}
		if (!File.Exists(filename))
		{
			Console.WriteLine("File not found.");
			return;
		}
		try
		{
			journal.Load(filename);
			Console.WriteLine($"Journal loaded from {filename}");
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error loading journal: " + ex.Message);
		}
	}
}

