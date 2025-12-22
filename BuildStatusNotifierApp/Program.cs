using System;

/// <summary>
/// Entry point for the Build Status Notifier observer pattern demonstration.
/// Wires up the subject and observers, then simulates a build process.
/// </summary>
class Program
{
    static void Main()
    {
        // Create the subject (publisher)
        BuildStatusNotifier notifier = new BuildStatusNotifier();

        // Create the first observer
        ConsoleLoggerObserver consoleLogger = new ConsoleLoggerObserver();

        // Attach the observer to the subject
        notifier.Attach(consoleLogger);

        // Execute the simulated build process
        notifier.SimulateBuild();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
