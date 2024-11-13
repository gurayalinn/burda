// Helpers/Logger.cs
using System;
using Serilog;
using burda.Models;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log = burda.Models.Log;
using System.IO;

namespace burda.Helpers
{
    internal static class Logger
    {
        private static readonly ILogger _logger;

        static Logger()
        {
            var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Path.Combine(logDirectory, "log.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            _logger.Information("Logger initialized.");
        }

        private static async Task SaveLogToDatabase(string logType, string message)
        {
            using (var context = new AppDbContext())
            {
                var logEntry = new Log
                {
                    LogType = logType,
                    Message = message,
                    LogTime = DateTime.Now
                };
                context.Logs.Add(logEntry);
                await context.SaveChangesAsync();
            }
        }

        public static async Task Information(string message)
        {
            _logger.Information(message);
            await SaveLogToDatabase("INFO", message);
        }

        public static async Task Warning(string message)
        {
            _logger.Warning(message);
            await SaveLogToDatabase("WARNING", message);
        }

        public static async Task Error(string message, Exception ex = null)
        {
            var errorMessage = ex == null ? message : $"{message} - {ex.Message}";
            _logger.Error(ex, message);
            await SaveLogToDatabase("ERROR", errorMessage);
        }

        public static async Task Debug(string message)
        {
            _logger.Debug(message);
            await SaveLogToDatabase("DEBUG", message);
        }

        public static async Task Verbose(string message)
        {
            _logger.Verbose(message);
            await SaveLogToDatabase("VERBOSE", message);
        }

        public static async Task LogWithProperties(string message, object properties)
        {
            _logger.Information(message, properties);
            await SaveLogToDatabase("INFO", message);
        }
    }
}
