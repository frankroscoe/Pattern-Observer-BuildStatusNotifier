using System;
using BuildStatusNotifierApp.Interfaces;

namespace BuildStatusNotifierApp.Observers
{
    /// <summary>
    /// A concrete Observer in the Observer Pattern.
    ///
    /// This observer writes build status updates directly to the console.
    /// It represents a real-time, developer-facing output stream—similar to
    /// what you would see in a terminal, CI/CD dashboard, or build monitor.
    ///
    /// Educational goals of this class:
    ///   • Demonstrate how observers react independently to Subject updates
    ///   • Show how multiple observers can coexist without coupling
    ///   • Provide a simple, visible output mechanism for teaching the pattern
    /// </summary>
    public class ConsoleLoggerObserver : IBuildObserver
    {
        /// <summary>
        /// Called by the Subject (publisher) whenever the build status changes.
        /// This method simply writes the status message to the console.
        ///
        /// In a real system, this could represent:
        ///   • A live build monitor
        ///   • A developer console
        ///   • A CI/CD pipeline log stream
        /// </summary>
        /// <param name="status">The build status message sent by the Subject.</param>
        public void Update(string status)
        {
            Console.WriteLine(status);
        }
    }
}
