using System;
using Microsoft.Extensions.Logging;

namespace PracticeNotebook.EF.Helpers
{
    public class EfLogger : ILogger
    {
        private readonly string _categoryName;

        public EfLogger(string categoryName) => _categoryName = categoryName;
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (_categoryName.Equals("Microsoft.EntityFrameworkCore.Database.Command") && logLevel == LogLevel.Information)
            {
                var logContent = formatter(state, exception);
                Console.WriteLine();
                Console.WriteLine(logContent);
            }
        }

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}