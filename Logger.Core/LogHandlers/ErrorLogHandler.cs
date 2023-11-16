using Logger.Abstractions;

namespace Logger.Core.LogHandlers;

/// <summary>
/// Class to represent Error Log Handler
/// </summary>
internal class ErrorLogHandler : LogHandler
{
    /// <summary>
    /// Create an instance of <see cref="ErrorLogHandler"/>
    /// </summary>
    /// <param name="inferiorLogger">Log handlers for the log levels below</param>
    /// <param name="configuredSinks">Sinks configured for this log level</param>
    public ErrorLogHandler(LogHandler? inferiorLogger, IReadOnlyList<ISink> configuredSinks) : base(LogLevel.Error, inferiorLogger, configuredSinks)
    {
    }
}