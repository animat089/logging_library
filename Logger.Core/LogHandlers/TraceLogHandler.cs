using Logger.Abstractions;

namespace Logger.Core.LogHandlers;

/// <summary>
/// Class to represent Trace Log Handler
/// </summary>
internal class TraceLogHandler : LogHandler
{
    /// <summary>
    /// Create an instance of <see cref="TraceLogHandler"/>
    /// </summary>
    /// <param name="inferiorLogger">Log handlers for the log levels below</param>
    /// <param name="configuredSinks">Sinks configured for this log level</param>
    public TraceLogHandler(LogHandler? inferiorLogger, IReadOnlyList<ISink> configuredSinks) : base(LogLevel.Trace, null, configuredSinks)
    {
    }
}