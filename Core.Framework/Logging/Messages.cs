using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Framework.Logging
{
    internal abstract class MessagesBase
    {
        private readonly IConstants _constants;
        protected Dictionary<string, string> _tokens;

        protected MessagesBase(IConstants constants)
        {
            _constants = constants;

            foreach (var constant in constants.GetType().GetProperties())
            {
               // _tokens.Add(constant.Name, constant());
               constant.
            }
        }

        public abstract string Get(string key);
    }

   
}
