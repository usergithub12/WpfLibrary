using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Exceptions
{
    public class PasswordEqualsInDataBaseException : Exception
    {
        public PasswordEqualsInDataBaseException()
        {
        }

        public PasswordEqualsInDataBaseException(string message) : base(message)
        {
        }
    }
}