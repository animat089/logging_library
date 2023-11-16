using Logger.Abstractions;
using Logger.Core.LogHandlers;

namespace Logger.Core;

internal static class LogManager
{
    internal static LogHandler BuildLoggerChain(LogLevelSinkMap logLevelSinkMapper)
    {
        var traceLogHandler = new TraceLogHandler(null, logLevelSinkMapper.Get(LogLevel.Trace));
        var debugLogHandler = new DebugLogHandler(traceLogHandler, logLevelSinkMapper.Get(LogLevel.Debug));
        var infoLogHandler = new InfoLogHandler(debugLogHandler, logLevelSinkMapper.Get(LogLevel.Info));
        var warnLogHandler = new WarnLogHandler(infoLogHandler, logLevelSinkMapper.Get(LogLevel.Warn));
        var errorLogHandler = new ErrorLogHandler(warnLogHandler, logLevelSinkMapper.Get(LogLevel.Error));
        var fatalLogHandler = new FatalLogHandler(errorLogHandler, logLevelSinkMapper.Get(LogLevel.Fatal));

        return fatalLogHandler;
    }
}