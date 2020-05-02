using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSar.Presentation.BlazorSpaUI.Exceptions
{
    public class ApiClientNotInitializedException : Exception
    {
        public ApiClientNotInitializedException()
        {
        }

        public ApiClientNotInitializedException(string message) 
            : base(message)
        {
        }

        public ApiClientNotInitializedException(string message, Exception inner) 
            : base(message, inner)
        {
        }
    }
}
