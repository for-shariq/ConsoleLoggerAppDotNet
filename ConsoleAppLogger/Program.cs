using Microsoft.Extensions.Logging;
using System;

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
            var executionStep = ExecutionStep.Entered;
            
            var configurationProvider = new ConfigurationProvider();
            var loggerProvider = new LoggerProvider("YouTube.Logs", configurationProvider.GetLoggingConfiguration, configurationProvider.GetAppInsightsInstrumentationKey());
            var logger = loggerProvider.CreateLogger();
            var appLogger = new ApplicationLogger(logger);
            var obj = new Temp() { Id = 1, Name = "Something", Address = "my address" };

            executionStep = ExecutionStep.LoggerCreated;

            try
            {
                executionStep = ExecutionStep.Step1;
                ////throw new IntentionalException("This is the Exception Message");
                logger.Log(LogLevel.Information, $"The length of segment TestProperty: {123} this TestProperty2: {124} test");
                appLogger.LogDebug(1, "In {MethodName}. In ExecutionStep: {ExecutionStep}. This is a Debug Level Log - Getting item Object: {user}", nameof(Main), executionStep,obj);
                
                executionStep = ExecutionStep.Step2;
                appLogger.LogInformation(2, "In ExecutionStep: {ExecutionStep}. This is an Informational Log - Getting item {@obj}", executionStep, obj);

                executionStep = ExecutionStep.Step3;
                appLogger.LogWarning(3, "In ExecutionStep: {ExecutionStep}. This is a Warning Log - Getting item {Id}", executionStep, 42);


                appLogger.LogInformation(3,$"=>>>>this is info text Property1: {executionStep}, this is second Prop2: {111}",-1);

                executionStep = ExecutionStep.Completed;
            }
            catch (Exception e)
            {
                appLogger.LogInformation(4,"In ExecutionStep: {ExecutionStep}. We Should only see this when an Exception occurs and LogLevel == Error", executionStep);
                appLogger.LogError(5, e, "An Exception occured during the processing of Blah. In ExecutionStep: {ExecutionStep}. Exception Type: {ExceptionType} with Message: {ExceptionMessage}", executionStep, e.GetType().Name, e.Message);                
            }
            finally
            {
                loggerProvider.Dispose();
            }
        }
    }    
}