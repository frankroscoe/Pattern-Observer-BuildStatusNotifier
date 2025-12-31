using BuildStatusNotifierApp.Observers;
using System;

namespace BuildStatusNotifierApp
{
    /// <summary>
    /// Entry point for the Build Status Notifier demonstration.
    ///
    /// This class intentionally keeps orchestration logic minimal so the focus
    /// remains on illustrating the Observer pattern in a clean, instructional way.
    /// 
    /// Responsibilities of this file:
    /// - Instantiate the concrete Subject (BuildStatusNotifier)
    /// - Instantiate one or more Observers
    /// - Register Observers with the Subject
    /// - Trigger a simulated build pipeline to demonstrate event notifications
    /// 
    /// This mirrors real-world CI/CD systems where multiple independent components
    /// react to build events (logging, notifications, dashboards, etc.) without
    /// the build engine needing to know who is listening.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the Subject (publisher) responsible for broadcasting
            // build lifecycle events to all registered observers.
            BuildStatusNotifier notifier = new BuildStatusNotifier();

            // Observer #1: Writes build events to the console.
            // This models a real-time, developer-facing output stream.
            ConsoleLoggerObserver consoleLogger = new ConsoleLoggerObserver();

            // Observer #2: Persists build events to disk.
            // This models durable logging used in CI/CD pipelines for auditing,
            // troubleshooting, and post-build analysis.
            FileLoggerObserver fileLogger = new FileLoggerObserver(Paths.LogDirectory);

            // Register both observers with the Subject.
            // The Subject remains unaware of the observers' concrete types,
            // demonstrating loose coupling and extensibility.
            notifier.Attach(consoleLogger);
            notifier.Attach(fileLogger);

            // Trigger a simulated build pipeline.
            // Each stage of the build will notify all observers, allowing them
            // to react independently according to their own responsibilities.
            notifier.SimulateBuild();
        }
    }
}
