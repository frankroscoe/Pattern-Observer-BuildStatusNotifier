using BuildStatusNotifierApp.Interfaces;

namespace BuildStatusNotifierApp.Interfaces
{
    /// <summary>
    /// Represents the Subject (publisher) in the Observer pattern.
    /// 
    /// The Subject maintains a list of observers and notifies them whenever
    /// its internal state changes. This interface defines the contract for
    /// managing observer registration and broadcasting updates.
    /// </summary>
    public interface IBuildSubject
    {
        /// <summary>
        /// Registers an observer to receive notifications.
        /// </summary>
        void Attach(IBuildObserver observer);

        /// <summary>
        /// Unregisters an observer so it no longer receives notifications.
        /// </summary>
        void Detach(IBuildObserver observer);

        /// <summary>
        /// Notifies all registered observers of a build status change.
        /// </summary>
        void Notify(string status);
    }
}
