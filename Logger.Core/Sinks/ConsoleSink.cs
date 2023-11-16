using Logger.Abstractions;

namespace Logger.Core.Sinks;

public class ConsoleSink : Sink
{
    /// <inheritdoc/>
    public override void Write(LogEntry logEntry)
    {
        Console.WriteLine(FormatMessage(logEntry));
    }
}