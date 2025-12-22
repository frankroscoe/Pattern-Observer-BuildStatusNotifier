using System.Collections.Generic;

/// <summary>
/// Concrete implementation of the subject (publisher) in the Observer pattern.
/// Simulates a build pipeline and notifies registered observers of status changes.
/// </summary>
public class BuildStatusNotifier : IBuildSubject
{
    // Maintains a list of registered observers that want to receive build status updates.
    private readonly List<IBuildObserver> _observers = new List<IBuildObserver>();

    public void Attach(IBuildObserver observer)
    {
        // Adds an observer to the notification list of registered observers.
        _observers.Add(observer);
    }

    public void Detach(IBuildObserver observer)
    {
        // Removes an observer from the notification list of registered observers.
        _observers.Remove(observer);
    }

    public void Notify(string status)
    {
        // Sends the build status update to all registered observers.
        foreach (IBuildObserver observer in _observers)
        {
            observer.Update(status);
        }
    }

    /// <summary>
    /// Simulates a simple build process by sending a series of status updates to observers.
    /// </summary>
    public void SimulateBuild()
    {
        Notify("Build started");
        Notify("Compiling...");
        Notify("Running tests...");
        Notify("Build succeeded");
    }
}
