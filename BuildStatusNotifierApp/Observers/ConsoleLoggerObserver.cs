using System;

/// <summary>
/// Observer that logs build status updates to the console.
/// Demonstrates a simple, real-time reaction to build status changes.
/// </summary>
public class ConsoleLoggerObserver : IBuildObserver
{
    public void Update(string status)
    {
        Console.WriteLine($"[Console Logger] {status}");
    }
}
