namespace BuildStatusNotifierApp.Interfaces
{
    /// <summary>
    /// Represents an Observer in the Observer pattern.
    /// 
    /// Any class that wants to receive build status updates must implement
    /// this interface. The Subject calls <see cref="Update"/> whenever its
    /// state changes.
    /// </summary>
    public interface IBuildObserver
    {
        /// <summary>
        /// Called by the Subject (publisher) whenever the build status changes.
        /// </summary>
        void Update(string status);
    }
}
