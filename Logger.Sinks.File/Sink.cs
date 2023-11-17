using Logger.Abstractions;
using Logger.Core;

namespace Logger.Sinks.File
{
    public class Sink : AbstractSink<FileSinkOptions>
    {
        public Sink(FileSinkOptions fileSinkOptions) : base(fileSinkOptions)
        {
        }

        /// <inheritdoc/>
        public override void Write(LogEntry logEntry)
        {
            System.IO.File.AppendAllText(FilePath, FormatMessage(logEntry));
        }

        /// <inheritdoc/>
        protected override string FormatMessage(LogEntry logEntry)
        {
            return base.FormatMessage(logEntry) + "\n";
        }

        private string FilePath => Path.Combine(sinkOptions.Path, string.Format($"{sinkOptions.NamePrefix}_{DateTime.Now.ToString("yyyyMMdd")}.log"));
    }
}