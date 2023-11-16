namespace Logger.Abstractions;

/// <summary>
/// Interface representing the actions that a sink can perform
/// </summary>
public interface ISink
{
    /// <summary>
    /// Write the log
    /// </summary>
    /// <param name="logEntry">Log to be made</param>
    void WriteLog(LogEntry logEntry);
}