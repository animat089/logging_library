using Logger.Abstractions;

namespace Logger.Core.LogHandlers;

/// <summary>
/// Class to represent Fatal Log Handler
/// </summary>
internal class FatalLogHandler : LogHandler
{
    /// <summary>
    /// Create an instance of <see cref="FatalLogHandler"/>
    /// </summary>
    /// <param name="inferiorLogger">Log handlers for the log levels below</param>
    /// <param name="configuredSinks">Sinks configured for this log level</param>

    public FatalLogHandler(LogHandler? inferiorLogger, IReadOnlyList<ISink> configuredSinks) : base(LogLevel.Fatal, inferiorLogger, configuredSinks)
    {
    }
}