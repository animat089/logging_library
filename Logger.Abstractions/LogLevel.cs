namespace Logger.Abstractions;

/// <summary>
/// Enumeration representing log levels
/// </summary>
[Flags]
public enum LogLevel
{
    /// <summary>
    /// Log level to represent log trace
    /// </summary>
    Trace = 0,

    /// <summary>
    /// Log level to represent log debug
    /// </summary>
    Debug = 1,

    /// <summary>
    /// Log level to represent log information
    /// </summary>
    Info = 2,

    /// <summary>
    /// Log level to represent log warning
    /// </summary>
    Warn = 4,

    /// <summary>
    /// Log level to represent log error
    /// </summary>
    Error = 8,

    /// <summary>
    /// Log level to represent log fatal
    /// </summary>
    Fatal = 16
}