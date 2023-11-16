namespace Logger.Abstractions;

public interface ILogger
{
    /// <summary>
    /// Log a record to the available sinks
    /// </summary>
    /// <param name="logLevel">Log level for the log</param>
    /// <param name="message">Message to be looged</param>
    /// <param name="values">Parameters for the log message</param>
    void Log(LogLevel logLevel, string message, params object[] values);

    /// <summary>
    /// Log a record to the available sinks
    /// </summary>
    /// <param name="logLevel">Log level for the log</param>
    /// <param name="exception">Eception to the logged</param>
    /// <param name="message">Message to be looged</param>
    /// <param name="values">Parameters for the log message</param>
    void Log(LogLevel logLevel, Exception? exception, string message, params object[] values);
}