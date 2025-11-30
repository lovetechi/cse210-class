using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue.");
                    Console.ReadLine();
                    continue;
            }

            activity.SetDurationFromUser();
            activity.Start();
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}

/*
  Exceeding requirements notes:
  - ReflectionActivity avoids repeating questions until all have been used in the session.
  - ListingActivity accepts multiple items within the time limit and displays them back to the user.
  - Spinner, countdown and small readiness pauses provide simple animations during pauses.
*/