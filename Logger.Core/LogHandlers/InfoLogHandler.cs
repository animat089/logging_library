using Logger.Abstractions;

namespace Logger.Core.LogHandlers;

/// <summary>
/// Class to represent Info Log Handler
/// </summary>
internal class InfoLogHandler : LogHandler
{
    /// <summary>
    /// Create an instance of <see cref="InfoLogHandler"/>
    /// </summary>
    /// <param name="inferiorLogger">Log handlers for the log levels below</param>
    /// <param name="configuredSinks">Sinks configured for this log level</param>

    public InfoLogHandler(LogHandler? inferiorLogger, IReadOnlyList<ISink> configuredSinks) : base(LogLevel.Info, inferiorLogger, configuredSinks)
    {
    }
}