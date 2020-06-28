using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSar.Presentation.BlazorSpaUI.Exceptions
{
    public class ServerValidationException : Exception
    {
        public IDictionary<string, string[]> ErrorDictionary { get; private set; }

        // Consider: Adding a general message string parameter
        public ServerValidationException(IDictionary<string, string[]> errorDictionary)
        {
            ErrorDictionary = errorDictionary;
        }
    }
}