using Logger.Abstractions;

namespace Logger.Configurations;

public abstract class SinkOptions
{
    public bool IsEnabled { get; set; }

    public LogLevel ActiveLogLevel { get; set; }
}