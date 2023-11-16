using Logger.Abstractions;

namespace Logger.Core;

public abstract class Sink : ISink
{
    private static readonly object lockObject = new object();

    /// <inheritdoc/>
    public void WriteLog(LogEntry logEntry)
    {
        try
        {
            lock (lockObject)
            {
                Write(logEntry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    /// <summary>
    /// Format the log message
    /// </summary>
    /// <param name="logEntry">Log to be written</param>
    /// <returns>A string representing a log entry</returns>
    protected virtual string FormatMessage(LogEntry logEntry)
    {
        return string.Format(
                "{0}-{1}-{2}\nNamespace:{3}\nMethod:{4}\nException:{5}",
                DateTime.Now.ToString("o"),
                logEntry.LogLevel,
                string.Format(logEntry.Message, logEntry.Values),
                logEntry.CallerNamespace,
                logEntry.CallerMethod,
                logEntry.Exception?.ToString());
    }

    /// <summary>
    /// Writw the log message to sink
    /// </summary>
    /// <param name="logEntry">Log to be written</param>
    public abstract void Write(LogEntry logEntry);
}