// See https://aka.ms/new-console-template for more information

using Logger.Abstractions;
using Logger.Configurations;
using Logger.Core;
using Logger.Sinks.Console;
using Logger.Sinks.File;

// Setup Configurations
var loggerOptions = new LoggerOptions()
{
    Sinks =
    {
        {
            "Console",
            new ConsoleSinkOptions()
            {
                IsEnabled = true,
                ActiveLogLevel = LogLevel.Trace | LogLevel.Debug | LogLevel.Info | LogLevel.Warn | LogLevel.Error | LogLevel.Fatal
            }
        },
        {
            "File",
            new FileSinkOptions()
            {
                IsEnabled = true,
                ActiveLogLevel = LogLevel.Info | LogLevel.Warn | LogLevel.Error | LogLevel.Fatal,
                Path = "",
                NamePrefix = "log"
            }
        }
    }
};

// Create Sinks
var sinks = new Dictionary<string, ISink>
{
    { "Console", new Logger.Sinks.Console.Sink(loggerOptions.Sinks["Console"] as ConsoleSinkOptions) },
    { "File", new Logger.Sinks.File.Sink(loggerOptions.Sinks["File"] as FileSinkOptions) }
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