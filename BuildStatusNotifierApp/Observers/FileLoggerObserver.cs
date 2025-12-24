using System;
using System.IO;

namespace BuildStatusNotifierApp.Observers
{
    /// <summary>
    /// FileLoggerObserver is a concrete Observer in the Observer Pattern.
    /// 
    /// ROLE IN THE PATTERN:
    /// ---------------------
    /// - The Subject (BuildStatusNotifier) calls Update(...) on all registered observers.
    /// - This observer responds by writing each status update to a log file.
    /// 
    /// EDUCATIONAL PURPOSE:
    /// ---------------------
    /// This class demonstrates how an Observer can perform a *side effect* (file I/O)
    /// in response to notifications. It also models:
    ///   • Constructor injection for configuration (log directory)
    ///   • Safe directory creation
    ///   • Timestamped log entries
    ///   • Daily log file rotation using date-based filenames
    /// 
    /// This mirrors real-world logging frameworks and helps students understand how
    /// the Observer Pattern can be used to decouple event generation from event handling.
    /// </summary>
    public class FileLoggerObserver : IBuildObserver
    {
        // Directory where log files will be written.
        // Using a readonly field reinforces that this value is fixed after construction.
        private readonly string _logDirectory;

        /// <summary>
        /// Constructor accepts the directory where log files should be stored.
        /// 
        /// WHY THIS MATTERS:
        /// ------------------
        /// - The Subject should not decide where logs go; that is the Observer's concern.
        /// - Constructor injection keeps the class flexible and testable.
        /// - Ensuring the directory exists prevents runtime exceptions during logging.
        /// </summary>
        public FileLoggerObserver(string logDirectory)
        {
            _logDirectory = logDirectory;

            // Ensure the directory exists before writing any files.
            // This makes the observer self-contained and robust.
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        /// <summary>
        /// Called by the Subject whenever a new build status message is available.
        /// 
        /// BEHAVIOR:
        /// ---------
        /// - Appends the message to a daily log file.
        /// - Each entry is timestamped for chronological review.
        /// - A new file is created automatically if it does not exist.
        /// 
        /// This demonstrates how Observers can react to events without the Subject
        /// needing to know *how* the reaction is implemented.
        /// </summary>
        public void Update(string status)
        {
            // Build a filename based on the current date.
            // Example: log_20251222.txt
            string filePath = Path.Combine(
                _logDirectory,
                "log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt"
            );

            // Format a single log entry with a timestamp.
            string logEntry =
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                " - " +
                status +
                Environment.NewLine;

            // Append the entry to the file.
            // If the file does not exist, AppendAllText creates it automatically.
            File.AppendAllText(filePath, logEntry);
        }
    }
}
