namespace Logger.Abstractions;

public record LogEntry
{
    /// <summary>
    /// Gets the LogLevel
    /// </summary>
    public LogLevel LogLevel { get; }

    /// <summary>
    /// Gets the log caller namespace
    /// </summary>
    public string? CallerNamespace { get; }

    /// <summary>
    /// Gets the log caller namespace
    /// </summary>
    public string? CallerMethod { get; }

    /// <summary>
    /// Gets the log exception
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// Gets the message template
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the values
    /// </summary>
    public object?[] Values { get; }

    /// <summary>
    /// Create a new instance of type <see cref="LogRecord"/>
    /// </summary>
    /// <param name="nameSpace">Namespace for the associated log</param>
    /// <param name="logLevel">Log level for the log</param>
    /// <param name="exception">Eception to the logged</param>
    /// <param name="message">Message to be looged</param>
    /// <param name="values">Parameters for the log message</param>
    public LogEntry(
        string? callerNamespace,
        string? callerMethod,
        LogLevel logLevel,
        Exception? exception,
        string message,
        params object?[] values)
    {
        LogLevel = logLevel;
        CallerNamespace = callerNamespace;
        CallerMethod = callerMethod;
        Exception = exception;
        Message = message;
        Values = values;
    }
}