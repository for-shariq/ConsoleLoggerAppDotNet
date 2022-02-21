using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Framework.Logging.ApplicationLogger
{
    public interface IConstants
    {
        #region Error
        string GetErrorMessage<T1>(T1 param1);
        string GetErrorMessage<T1,T2>(T1 param1, T2 param2);
        string GetErrorMessage<T1, T2, T3>(T1 param1, T2 param2, T3 param3);
        string GetErrorMessage<T1, T2, T3, T4>(T1 param1, T2 param2, T3 param3, T4 param4);
        #endregion
       
    }
    public class Constants: IConstants
    {
        public string GetErrorMessage<T1>(T1 param1) => "Something went wrong Exception Message: {ExceptionMessage}";
        public string GetErrorMessage<T1,T2>(T1 param1,T2 param2) 
            => "Error occurred in Method Name: {MethodName} with Exception Message: {ExceptionMessage}";
        public string GetErrorMessage<T1, T2, T3>(T1 methodName, T2 exceptionTypeName, T3 exceptionMessage)
            => "Error occurred in Method Name: {MethodName} of Exception Name: {ExceptionTypeName} with Exception Message: {ExceptionMessage}";
        public string GetErrorMessage<T1, T2, T3, T4>(T1 methodName, T2 executionStep,
            T3 exceptionTypeName, T4 exceptionMessage)
            => "Error occurred in Method Name: {MethodName} at Execution Step: {ExecutionStep} with Exception Name: {ExceptionTypeName} " +
               "Exception Message:  {ExceptionMessage}";

    }
}
