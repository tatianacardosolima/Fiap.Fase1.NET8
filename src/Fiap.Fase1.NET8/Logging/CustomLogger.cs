using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Fase1.NET8.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string loggerName;
        private readonly CustomLoggerProviderConfiguration providerConfiguration;
        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration providerConfiguration)
        {
            this.loggerName = loggerName;
            this.providerConfiguration = providerConfiguration;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = $"Log de Execução {logLevel}: {eventId} - {formatter(state, exception)}";

            var pathFile = @$"{Environment.CurrentDirectory}\logs\LOG-{DateTime.Now:yyyy-MM-dd}.log";
            if  (!File.Exists(pathFile)) 
            { 
                Directory.CreateDirectory(Path.GetDirectoryName(pathFile));
                File.Create(pathFile).Dispose();
            }
            using StreamWriter sw = new(pathFile,true);
            sw.WriteLine(message);
            sw.Close();
            Console.WriteLine(message);
                 
        }
    }
}
