/// <summary> 
/// Defines the contract for all observers in the Observer pattern.
/// Any class that wants to receive build status updates must implement this interface.
/// </summary>
public interface IBuildObserver
{
    /// <summary> 
    /// Called by the subject (publisher) whenever the build status changes.
    /// </summary>
    void Update(string status);
}
