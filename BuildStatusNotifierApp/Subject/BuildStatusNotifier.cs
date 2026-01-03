using System.Collections.Generic;
using BuildStatusNotifierApp.Interfaces;

namespace BuildStatusNotifierApp.Subject
{
    /// <summary>
    /// Concrete implementation of the Subject (publisher) in the Observer pattern.
    /// 
    /// This class simulates a simple build pipeline and notifies all registered
    /// observers whenever the build status changes. It demonstrates the core
    /// responsibilities of a Subject:
    ///   • Maintaining a list of observers
    ///   • Allowing observers to subscribe/unsubscribe
    ///   • Broadcasting state changes to all observers
    /// </summary>
    public class BuildStatusNotifier : IBuildSubject
    {
        // Maintains a list of observers that want to receive build status updates.
        // Using explicit types (List<IBuildObserver>) for clarity and teaching value.
        private readonly List<IBuildObserver> _observers = new List<IBuildObserver>();

        /// <summary>
        /// Registers an observer to receive notifications.
        /// </summary>
        public void Attach(IBuildObserver observer)
        {
            _observers.Add(observer);
        }

        /// <summary>
        /// Unregisters an observer so it no longer receives notifications.
        /// </summary>
        public void Detach(IBuildObserver observer)
        {
            _observers.Remove(observer);
        }

        /// <summary>
        /// Notifies all registered observers of a build status change.
        /// </summary>
        public void Notify(string status)
        {
            foreach (IBuildObserver observer in _observers)
            {
                observer.Update(status);
            }
        }

        /// <summary>
        /// Simulates a simple build process by sending a series of status updates.
        /// This method is intentionally simple to keep the focus on the Observer pattern.
        /// </summary>
        public void SimulateBuild()
        {
            Notify("Build started");
            Notify("Compiling...");
            Notify("Running tests...");
            Notify("Build succeeded");
        }
    }
}
