using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Framework.Logging.Base;
using Microsoft.Extensions.Logging;

namespace Core.Framework.Logging.ApplicationLogger
{
    public sealed class ApplicationLogger : LoggerBase
    {
        private readonly ILogger _logger;
        private readonly IConstants _constants;
        public ApplicationLogger(ILogger logger, IConstants constants): base(logger)
        {
            _logger = logger;
            _constants = constants;
        }

        /// <summary>
        /// Something went wrong Exception Message: {ExceptionMessage}
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="exceptionMessage"></param>
        /// <param name="param1"></param>
        public override void LogError<T1>(int eventId, Exception exception, string exceptionMessage, T1 param1)
        {
            exceptionMessage = _constants.GetErrorMessage(exceptionMessage);
            _logger.LogError(eventId, exception, exceptionMessage, param1);
        }

        /// <summary>
        /// Error occurred in Method Name: {MethodName} with Exception Message: {ExceptionMessage}
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="customMessage"></param>
        /// <param name="methodName"></param>
        /// <param name="exceptionMessage"></param>
        public override void LogError<T1, T2>(int eventId, Exception exception, string customMessage, T1 methodName, T2 exceptionMessage)
        {
            customMessage = _constants.GetErrorMessage(methodName, exceptionMessage);
            _logger.LogError(eventId, exception, customMessage, methodName, exceptionMessage);
        }

        /// <summary>
        /// Error occurred in Method Name: {MethodName} of Exception Name: {ExceptionTypeName} with Exception Message: {ExceptionMessage}
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <param name="exceptionTypeName"></param>
        /// <param name="exceptionMessage"></param>
        public override void LogError<T1, T2, T3>(int eventId, Exception exception, string message, T1 methodName, T2 exceptionTypeName, T3 exceptionMessage)
        {
            message = _constants.GetErrorMessage(methodName, exceptionTypeName, exceptionMessage);
            base.LogError(eventId, exception, message, methodName, exceptionTypeName, exceptionMessage);
        }


        /// <summary>
        /// Error occurred in Method Name: {MethodName} at Execution Step: {ExecutionStep} with Exception Name: {ExceptionTypeName}
        /// Exception Message:  {ExceptionMessage}
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="eventId"></param>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <param name="executionStep"></param>
        /// <param name="exceptionTypeName"></param>
        /// <param name="exceptionMessage"></param>
        public override void LogError<T1, T2, T3, T4>(int eventId, Exception exception, string message,
            T1 methodName, T2 executionStep, T3 exceptionTypeName, T4 exceptionMessage)
        {
            message = _constants.GetErrorMessage(methodName, executionStep, exceptionTypeName, exceptionMessage);
            base.LogError(eventId, exception, message, methodName, executionStep, exceptionTypeName, exceptionMessage);
        }
        
    }
}
