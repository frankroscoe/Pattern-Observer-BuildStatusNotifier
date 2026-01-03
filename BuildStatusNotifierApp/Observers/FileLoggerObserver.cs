using System;
using System.IO;
using BuildStatusNotifierApp.Interfaces;

namespace BuildStatusNotifierApp.Observers
{
    /// <summary>
    /// A concrete Observer in the Observer Pattern.
    /// 
    /// This class listens for build status updates and writes them to a
    /// timestamped log file. It is intentionally designed to be:
    ///   • Educational (clear, explicit, well‑commented)
    ///   • Operationally mature (timestamped filenames, UTC, run boundaries)
    ///   • Portfolio‑ready (clean formatting, reproducible behavior)
    /// </summary>
    public class FileLoggerObserver : IBuildObserver
    {
        private readonly string _logDirectory;
        private readonly string _logFilePath;

        /// <summary>
        /// Constructor.
        /// Creates a new timestamped log file for the current run and writes
        /// a header row plus a START‑OF‑RUN marker.
        /// </summary>
        public FileLoggerObserver(string logDirectory)
        {
            _logDirectory = logDirectory;

            // Ensure the Logs directory exists. This makes the class robust
            // when running in CI/CD environments where folders may not exist.
            Directory.CreateDirectory(_logDirectory);

            // Create a filename with both date and time to avoid collisions.
            // Example: log_20251231_154210.txt
            string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            string fileName = $"log_{timestamp}.txt";

            _logFilePath = Path.Combine(_logDirectory, fileName);

            // Write a header row and a START‑OF‑RUN marker.
            // This makes the log self‑documenting and easy to read.
            using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
            {
                writer.WriteLine("# Timestamp (UTC), Message");
                writer.WriteLine("------------------------------------------------------------");
                writer.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC, START OF RUN");
                writer.WriteLine("------------------------------------------------------------");
                writer.Flush();
            }
        }

        /// <summary>
        /// Called by the Subject whenever a new build status message is available.
        /// Each message is appended to the log with a precise UTC timestamp.
        /// </summary>
        public void Update(string message)
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
            {
                writer.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC, {message}");
                writer.Flush(); // Ensures log integrity even if the process exits abruptly
            }
        }

        /// <summary>
        /// Optional lifecycle hook.
        /// Call this at the end of the build/test pipeline to clearly mark the
        /// end of a run. This is especially useful when multiple runs occur
        /// in the same CI/CD session.
        /// </summary>
        public void EndRun()
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
            {
                writer.WriteLine("------------------------------------------------------------");
                writer.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC, END OF RUN");
                writer.WriteLine("============================================================");
                writer.WriteLine(); // Blank line before next run (if any)
                writer.Flush();
            }
        }
    }
}
