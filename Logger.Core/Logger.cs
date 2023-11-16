using Logger.Abstractions;
using System.Diagnostics;

namespace Logger.Core;

/// <summary>
/// Class representing the logger
/// </summary>
public class Logger : ILogger
{
    private static ILogger logger;
    private readonly LogHandler loggerChain;

    private static readonly object lockObject = new object();

    private Logger(LogLevelSinkMap logSinkConfiguration)
    {
        this.loggerChain = LogManager.BuildLoggerChain(logSinkConfiguration);
    }

    /// <summary>
    /// Get an instance of <see cref="ILogger"/>
    /// </summary>
    /// <returns></returns>
    public static ILogger GetLogger(LogLevelSinkMap logSinkConfiguration)
    {
        lock (lockObject)
        {
            if (logger == null)
            {
                logger = new Logger(logSinkConfiguration);
            }
        }

        return logger;
    }

    /// <inheritdoc/>
    public void Log(LogLevel logLevel, string message, params object[] values) => loggerChain.WriteLog(CreateLogEntry(logLevel, null, message, values));

    /// <inheritdoc/>
    public void Log(LogLevel logLevel, Exception? exception, string message, params object[] values) => loggerChain.WriteLog(CreateLogEntry(logLevel, exception, message, values));

    /// <summary>
    /// Create a LogEntry for the sink
    /// </summary>
    /// <param name="logLevel">Log level for the log</param>
    /// <param name="exception">Eception to the logged</param>
    /// <param name="message">Message to be looged</param>
    /// <param name="values">Parameters for the log message</param>
    /// <returns>An object of <see cref="LogEntry"/></returns>
    private static LogEntry CreateLogEntry(LogLevel logLevel, Exception? exception, string message, params object[] values)
    {
        var methodBase = new StackTrace().GetFrame(2)?.GetMethod();
        var callerMethod = methodBase?.Name;
        var callerNamespace = methodBase?.ReflectedType?.FullName;

        return new LogEntry(callerNamespace, callerMethod, logLevel, exception, message, values);
    }
}