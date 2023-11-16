using Logger.Abstractions;

namespace Logger.Core.Sinks;

public class FileSink : Sink
{
    private readonly string logPath;

    public FileSink(string logPath)
    {
        this.logPath = logPath;
    }

    /// <inheritdoc/>
    public override void Write(LogEntry logEntry)
    {
        File.AppendAllText(logPath, FormatMessage(logEntry));
    }

    /// <inheritdoc/>
    protected override string FormatMessage(LogEntry logEntry)
    {
        return base.FormatMessage(logEntry) + "\n";
    }
}