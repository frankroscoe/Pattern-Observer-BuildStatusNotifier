using BuildStatusNotifierApp.Observers;
using System;

namespace BuildStatusNotifierApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the subject (publisher)
            BuildStatusNotifier notifier = new BuildStatusNotifier();

            // Create the first observer
            ConsoleLoggerObserver consoleLogger = new ConsoleLoggerObserver();

            // Create the second observer
            FileLoggerObserver fileLogger = new FileLoggerObserver(Paths.LogDirectory);

            // Attach the observers to the subject
            notifier.Attach(consoleLogger);
            notifier.Attach(fileLogger);

            // Execute the simulated build process
            notifier.SimulateBuild();
            
        }
    }
}

