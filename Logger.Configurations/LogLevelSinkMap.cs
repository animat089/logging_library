using Logger.Abstractions;
using Logger.Configurations;

namespace Logger.Core;

public class LogLevelSinkMap
{
    private readonly Dictionary<LogLevel, List<ISink>> logLevelSinkMap;

    public LogLevelSinkMap(LoggerOptions loggerOptions, IDictionary<string, ISink> sinks)
    {
        logLevelSinkMap = new();

        foreach (var sinkOptions in loggerOptions.Sinks)
        {
            if (sinks.TryGetValue(sinkOptions.Name, out ISink? sink))
            {
                foreach (var logLevel in sinkOptions.LogLevels)
                {
                    if (LogLevel.TryParse(logLevel, out LogLevel level))
                    {
                        Add(level, sink);
                    }
                }
            }
        }
    }

    private void Add(LogLevel logLevel, ISink sink)
    {
        var logLevelSinks = logLevelSinkMap.GetValueOrDefault(logLevel);
        if (logLevelSinks == null)
        {
            var tempLobgLevelSink = new List<ISink>() { sink };
            logLevelSinkMap.Add(logLevel, tempLobgLevelSink);
        }
        else
        {
            logLevelSinks.Add(sink);
            logLevelSinkMap[logLevel] = logLevelSinks;
        }
    }

    public IReadOnlyList<ISink> Get(LogLevel logLevel)
    {
        if (logLevelSinkMap.TryGetValue(logLevel, out var sinks))
            return sinks;

        return Array.Empty<ISink>();
    }
}