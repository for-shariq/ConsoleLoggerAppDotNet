using Core.Framework.Logging.Common;
using Core.Framework.Logging.Base;
using Microsoft.Extensions.Logging;
using System;
using Core.Framework.Logging;
using Core.Framework.Logging.PropertyLogger;
using Microsoft.Extensions.Logging.ApplicationInsights;

namespace ConsoleAppLogger
{
    public class Temp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var executionStep = ExecutionStep.Init;
            
            var configurationProvider = new ConfigurationProvider();
            var loggerProvider = new LoggerProvider("SNK.Logs", configurationProvider.GetLoggingConfiguration, 
                configurationProvider.GetAppInsightsInstrumentationKey());
            var logger = loggerProvider.CreateLogger();
            var appLogger = new PropertyLogger(logger, new Constants());
            var obj = new Temp() { Id = 1, Name = "Something", Address = "my address" };


            try
            {
                var constants = new Constants();
                
                executionStep = ExecutionStep.Step1;
                ////throw new IntentionalException("This is the Exception Message");
                //logger.Log(LogLevel.Information, $"The length of segment TestProperty: {123} this TestProperty2: {124} test");
                //appLogger.LogError(LogEvents,)
                
                executionStep = ExecutionStep.Step2;
                appLogger.LogInformation(2, "In ExecutionStep: {ExecutionStep}. This is an Informational Log - Getting item {@obj}", executionStep, obj);

                executionStep = ExecutionStep.Step3;
                appLogger.LogWarning(3, "In ExecutionStep: {ExecutionStep}. This is a Warning Log - Getting item {Id}", executionStep, 42);

                executionStep = ExecutionStep.Completed;
                throw new IntentionalException("This is the Exception Message");
            }
            catch (Exception e)
            {
               // appLogger.LogError(5, e, "An Exception occured during the processing of Blah. In ExecutionStep: {ExecutionStep}. Exception Type: {ExceptionType} with Message: {ExceptionMessage}", executionStep, e.GetType().Name, e.Message);                
               appLogger.LogError(LogEvents.InsertItem,e,string.Empty,e.Message);
               appLogger.LogError(LogEvents.InsertItem,e,string.Empty,nameof(Main),e.Message);
               appLogger.LogError(
                   eventId: LogEvents.InsertItem,e,string.Empty,
                   methodName: nameof(Main),
                   exceptionTypeName: e.GetType().Name,
                   exceptionMessage: e.Message);

               appLogger.LogError(
                   LogEvents.InsertItem, e, string.Empty,
                   methodName: nameof(Main),
                   exceptionTypeName: e.GetType().Name,
                   exceptionMessage: e.Message,
                   executionStep:executionStep);

            }
            finally
            {
                loggerProvider.Dispose();
            }
        }
    }    
}