// See https://aka.ms/new-console-template for more information

using Logger.Abstractions;
using Logger.Configurations;
using Logger.Core;
using Logger.Core.Sinks;

// Setup Configurations
var loggerOptions = new LoggerOptions()
{
    Sinks = new SinkOptions[]
    {
        new SinkOptions()
        {
            Name = "Console",
            LogLevels = new[] { "Trace", "Debug", "Info", "Warn", "Error", "Fatal" }
        },
        new SinkOptions()
        {
            Name = "File",
            LogLevels = new[] { "Info", "Warn", "Error", "Fatal" }
        }
    }
};

// Create Sinks
var sinks = new Dictionary<string, ISink>
{
    { "Console", new ConsoleSink() },
    { "File", new FileSink("logs.txt") }
};

// Build LogLevel Sink Map
var logLevelSinkMap = new LogLevelSinkMap(loggerOptions, sinks);

// Testing Logs
var logger = Logger.Core.Logger.GetLogger(logLevelSinkMap);
logger.Log(LogLevel.Trace, "Test:{0}", "Trace");
logger.Log(LogLevel.Debug, "Test:{0}", "Debug");
logger.Log(LogLevel.Info, "Test:{0}", "Info");
logger.Log(LogLevel.Warn, "Test:{0}", "Warn");
logger.Log(LogLevel.Error, "Test:{0}", "Error");
logger.Log(LogLevel.Fatal, "Test:{0}", "Fatal");