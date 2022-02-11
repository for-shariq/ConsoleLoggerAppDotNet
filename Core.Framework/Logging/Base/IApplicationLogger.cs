using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Framework.Logging.Base
{
    internal interface IApplicationLogger
    {
        #region Error
        void LogError<T1>(int eventId, Exception exception, string message, T1 param1);
        void LogError<T1, T2>(int eventId, Exception exception, string message, T1 param1, T2 param2);
        void LogError<T1, T2, T3>(int eventId, Exception exception, string message, T1 param1, T2 param2, T3 param3);
        void LogError<T1, T2, T3,T4>(int eventId, Exception exception, string message, T1 param1, T2 param2, T3 param3, T4 param4);
        #endregion

        #region Warning

        void LogWarning<T1>(int eventId, string message, T1 param1);
        void LogWarning<T1, T2>(int eventId, string message, T1 param1, T2 param2);

        #endregion

        #region Information

        void LogInformation<T1>(int eventId, string message, T1 param1);
        void LogInformation<T1, T2>(int eventId, string message, T1 param1, T2 param2);
        void LogInformation<T1, T2, T3>(int eventId, string message, T1 param1, T2 param2, T3 param3);
        void LogInformation<T1, T2, T3, T4>(int eventId, string message, T1 param1, T2 param2, T3 param3, T4 param4);

        #endregion
    }

   
}
