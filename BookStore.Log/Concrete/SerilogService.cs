using BookStore.Log.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Log.Concrete
{
    public class SerilogService : ILogService
    {
        private ILogger _logger;
        public SerilogService(ILogger logger)
        {
            _logger = logger;
        }
        public void LogError(string message)
        {
            _logger.Error(message);
        }

        public void LogError(Exception exception, string message)
        {
            _logger.Error(exception,message);
        }

        public void LogInfo(string message)
        {
            _logger.Information(message);
        }

        public void LogInfo(Exception exception, string message)
        {
            _logger.Information(exception, message);
        }

        public void LogWarning(string message)
        {
            _logger.Warning(message);
        }

        public void LogWarning(Exception exception, string message)
        {
            _logger.Warning(exception, message);
        }
    }
}
