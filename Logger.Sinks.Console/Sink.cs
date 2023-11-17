using Logger.Abstractions;
using Logger.Core;

namespace Logger.Sinks.Console;

public class Sink : AbstractSink<ConsoleSinkOptions>
{
    public Sink(ConsoleSinkOptions sinkOptions) : base(sinkOptions)
    {
    }

    /// <inheritdoc/>
    public override void Write(LogEntry logEntry)
    {
        System.Console.WriteLine(FormatMessage(logEntry));
    }
}