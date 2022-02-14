using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Core.Framework.Logging.Base
{
    public abstract class ApplicationLogger
    {
        private readonly ILogger _logger;

        protected ApplicationLogger(ILogger logger)
        {
            _logger = logger;
        }

       
        public virtual void LogError<T1>(int eventId, Exception exception, string message, T1 param1)
        {
            _logger.LogError(eventId, exception, message, param1);
        }

        public virtual void LogError<T1, T2>(int eventId, Exception exception, string message, T1 param1, T2 param2)
        {
            _logger.LogError(eventId, exception, message, param1, param2);
        }

        public virtual void LogError<T1, T2, T3>(int eventId, Exception exception, string message, T1 param1, T2 param2, T3 param3)
        {
            _logger.LogError(eventId, exception, message, param1, param2, param3);
        }

        public virtual void LogError<T1, T2, T3, T4>(int eventId, Exception exception, string message, T1 param1, T2 param2, T3 param3,
            T4 param4)
        {
            _logger.LogError(eventId, exception, message, param1, param2, param3, param4);
        }

        public virtual void LogWarning<T1>(int eventId, string message, T1 param1)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(eventId, message, param1);
            }
        }

        public virtual void LogWarning<T1, T2>(int eventId, string message, T1 param1, T2 param2)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(eventId, message, param1, param2);
            }
        }

        public virtual void LogInformation<T1>(int eventId, string message, T1 param1)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(eventId, message, param1);
            }
        }

        public virtual void LogInformation<T1, T2>(int eventId, string message, T1 param1, T2 param2)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(eventId, message, param1, param2);
            }
        }

        public virtual void LogInformation<T1, T2, T3>(int eventId, string message, T1 param1, T2 param2, T3 param3)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(eventId, message, param1, param2, param3);
            }
        }

        public virtual void LogInformation<T1, T2, T3, T4>(int eventId, string message, T1 param1, T2 param2, T3 param3, T4 param4)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(eventId, message, param1, param2, param3, param4);
            }
        }
    }
}
