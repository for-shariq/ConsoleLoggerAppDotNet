//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Text;

//namespace ConsoleAppLogger
//{
//    internal sealed class ApplicationLogger
//    {
//        private readonly ILogger _logger;
//        public ApplicationLogger(ILogger logger)
//        {
//            _logger = logger;
//        }

//        public void LogError<T1, T2, T3>(int eventId, Exception exception, string message, T1 param1, T2 param2, T3 param3)
//        {
//            _logger.LogError(eventId, exception, message, param1, param2, param3);
//        }

//        public void LogWarning<T1, T2>(int eventId, string message, T1 param1, T2 param2)
//        {
//            if (_logger.IsEnabled(LogLevel.Warning))
//            {
//                _logger.LogWarning(eventId, message, param1, param2);
//            }
//        }
        
//        public void LogInformation<T1>(int eventId, string message, T1 param1)
//        {
//            if (_logger.IsEnabled(LogLevel.Information))
//            {
//                _logger.LogInformation(eventId, message, param1);
//            }
//        }

//        public void LogInformation<T1, T2>(int eventId, string message, T1 param1, T2 param2)
//        {
//            if (_logger.IsEnabled(LogLevel.Information))
//            {
//                _logger.LogInformation(eventId, message, param1, param2);
//            }
//        }

//        public void LogInformation<T1, T2, T3>(int eventId, string message, T1 param1, T2 param2, T3 param3)
//        {
//            if (_logger.IsEnabled(LogLevel.Information))
//            {
//                _logger.LogInformation(eventId, message, param1, param2, param3);
//            }
//        }

//        public void LogDebug<T1, T2, T3>(int eventId, string message, T1 param1, T2 param2, T3 param3)
//        {
//            if (_logger.IsEnabled(LogLevel.Debug))
//            {
//                _logger.LogDebug(eventId, message, param1, param2, param3);
//            }
//        }
//    }


//    [InterpolatedStringHandler]
//    public ref struct StructuredLoggingInterpolatedStringHandler
//    {
//        private readonly StringBuilder _template = null!;
//        private readonly List<object?> _arguments = null!;

//        public bool IsEnabled { get; }

//        public StructuredLoggingInterpolatedStringHandler(int literalLength, int formattedCount, ILogger logger, LogLevel logLevel, out bool isEnabled)
//        {
//            IsEnabled = isEnabled = logger.IsEnabled(logLevel);
//            if (isEnabled)
//            {
//                _template = new(literalLength);
//                _arguments = new(formattedCount);
//            }
//        }

//        public void AppendLiteral(string s)
//        {
//            if (!IsEnabled)
//                return;

//            _template.Append(s.Replace("{", "{{", StringComparison.Ordinal).Replace("}", "}}", StringComparison.Ordinal));
//        }

//        public void AppendFormatted<T>(
//            T value,
//            [CallerArgumentExpression("value")] string name = "")
//        {
//            if (!IsEnabled)
//                return;

//            _arguments.Add(value);
//            _template.Append($"{{@{name}}}");
//        }

//        public (string, object?[]) GetTemplateAndArguments() => (_template.ToString(), _arguments.ToArray());
//    }

//    public static partial class LoggerExtensions
//    {
//        public static void Log(this ILogger logger, LogLevel logLevel,
//            [InterpolatedStringHandlerArgument("logger", "logLevel")] ref StructuredLoggingInterpolatedStringHandler handler)
//        {
//            if (handler.IsEnabled)
//            {
//                var (template, arguments) = handler.GetTemplateAndArguments();
//                logger.Log(logLevel, template, arguments);
//            }
//        }
//    }
//}
