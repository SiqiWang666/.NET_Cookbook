using Microsoft.Extensions.Logging;

namespace PracticeNotebook.EF.Helpers
{
    public class EfLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new EfLogger(categoryName);

        public void Dispose()
        {
        }
    }
}