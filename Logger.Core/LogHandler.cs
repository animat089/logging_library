using Logger.Abstractions;

namespace Logger.Core;

/// <summary>
/// Class representing a Log Handler
/// </summary>
internal abstract class LogHandler
{
    private readonly LogLevel logLevel;
    private readonly LogHandler? inferiorLogger;
    private readonly IReadOnlyList<ISink> configuredSinks;

    /// <summary>
    /// Create an instance of <see cref="LogHandler"/>
    /// </summary>
    /// <param name="logLevel">Log Level for the Log</param>
    /// <param name="inferiorLogger">Log handlers for the log levels below</param>
    /// <param name="configuredSinks">Sinks configured for this log level</param>
    protected LogHandler(LogLevel logLevel, LogHandler? inferiorLogger, IReadOnlyList<ISink> configuredSinks)
    {
        this.logLevel = logLevel;
        this.inferiorLogger = inferiorLogger;
        this.configuredSinks = configuredSinks;
    }

    /// <summary>
    /// Write the log
    /// </summary>
    /// <param name="logEntry">Log to be made</param>
    public void WriteLog(LogEntry logEntry)
    {
        if (this.logLevel > logEntry.LogLevel
            && this.inferiorLogger != null)
        {
            inferiorLogger.WriteLog(logEntry);
        }
        else
        {
            foreach (var sink in configuredSinks)
            {
                sink.WriteLog(logEntry);
            }
        }
    }
}