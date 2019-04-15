using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Exceptions
{
    public class PasswordConfirmationException : Exception
    {
        public PasswordConfirmationException()
        {
        }

        public PasswordConfirmationException(string message) : base(message)
        {
        }
    }
}