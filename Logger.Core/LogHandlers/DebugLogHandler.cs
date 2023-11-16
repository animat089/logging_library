using Logger.Abstractions;

namespace Logger.Core.LogHandlers;

/// <summary>
/// Class to represent Debug Log Handler
/// </summary>
internal class DebugLogHandler : LogHandler
{
    /// <summary>
    /// Create an instance of <see cref="DebugLogHandler"/>
    /// </summary>
    /// <param name="inferiorLogger">Log handlers for the log levels below</param>
    /// <param name="configuredSinks">Sinks configured for this log level</param>
    public DebugLogHandler(LogHandler? inferiorLogger, IReadOnlyList<ISink> configuredSinks) : base(LogLevel.Debug, inferiorLogger, configuredSinks)
    {
    }
}