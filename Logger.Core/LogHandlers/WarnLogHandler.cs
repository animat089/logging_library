using Logger.Abstractions;

namespace Logger.Core.LogHandlers;

/// <summary>
/// Class to represent Warn Log Handler
/// </summary>
internal class WarnLogHandler : LogHandler
{
    /// <summary>
    /// Create an instance of <see cref="WarnLogHandler"/>
    /// </summary>
    /// <param name="inferiorLogger">Log handlers for the log levels below</param>
    /// <param name="configuredSinks">Sinks configured for this log level</param>
    public WarnLogHandler(LogHandler? inferiorLogger, IReadOnlyList<ISink> configuredSinks) : base(LogLevel.Warn, inferiorLogger, configuredSinks)
    {
    }
}