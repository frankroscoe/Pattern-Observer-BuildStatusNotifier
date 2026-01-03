namespace BuildStatusNotifierApp.Config
{
    /// <summary>
    /// Centralized configuration for application paths.
    ///
    /// This class exists to keep all file-system paths in one place,
    /// making the application easier to maintain, test, and extend.
    ///
    /// Educational goals of this class:
    ///   • Demonstrate clean separation of configuration from logic
    ///   • Show how a single source of truth prevents "magic strings"
    ///   • Provide a clear, intentional location for future path settings
    ///
    /// In a real-world system, this might be replaced by:
    ///   • appsettings.json
    ///   • environment variables
    ///   • dependency-injected configuration providers
    /// </summary>
    public static class Paths
    {
        /// <summary>
        /// The directory where all log files are written.
        ///
        /// This path is intentionally relative so the application behaves
        /// consistently across environments (local development, WSL, CI/CD).
        ///
        /// GitHub Actions uses this directory to:
        ///   • Promote the newest log to latest_log.txt
        ///   • Archive older logs
        ///   • Maintain automation_log.txt
        ///
        /// Keeping this value centralized ensures the entire logging pipeline
        /// (application + workflow automation) stays aligned.
        /// </summary>
        public static readonly string LogDirectory = "BuildStatusNotifierApp/Logs";
    }
}
