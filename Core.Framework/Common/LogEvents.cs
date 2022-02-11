﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Framework.Logging
{
    public class LogEvents
    {
        public const int GetItems = 1000;
        public const int ListItems = 1001;

        public const int GetItem = 1002;
        public const int InsertItem = 1003;
        public const int UpdateItem = 1004;
        public const int DeleteItem = 1005;

        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;

        public const int GetManagedIdentityToken = 5000;
        public const int SqlConnectionError = 5001;
        public const int SqlConnectionSuccess = 5003;
        public const int SqlConnectionRetryError = 5004;

    }
}
