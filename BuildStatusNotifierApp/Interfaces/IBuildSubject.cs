/// <summary>
/// Represents the subject (publisher) in the Observer pattern.
/// Maintains a list of observers and notifies them of state changes.
/// </summary>
public interface IBuildSubject
{
    /// <summary>
    /// Registers an observer to receive notifications.
    /// </summary>
    void Attach(IBuildObserver observer);

    /// <summary>
    /// Unregisters an observer from receiving notifications.
    /// </summary>
    void Detach(IBuildObserver observer);

    /// <summary>
    /// Notifies all registered observers of a build status change.
    /// </summary>
    void Notify(string status);
}
