using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Exceptions
{
    public class EmptyCyrilicLoginException : Exception
    {
        public EmptyCyrilicLoginException()
        {
        }

        public EmptyCyrilicLoginException(string message) : base(message)
        {
        }
    }
}