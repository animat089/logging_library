using Logger.Configurations;

namespace Logger.Sinks.File;

public class FileSinkOptions : SinkOptions
{
    public string Path { get; set; }

    public string NamePrefix { get; set; }
}