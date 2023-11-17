namespace Logger.Configurations;

public class LoggerOptions
{
    public Dictionary<string, SinkOptions> Sinks { get; set; } = new();
}