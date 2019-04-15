using System;
using System.Runtime.Serialization;

namespace WcfService
{
    [Serializable]
    internal class UserExistsInDatabaseException : Exception
    {
        public UserExistsInDatabaseException()
        {
        }



        public UserExistsInDatabaseException(string message) : base(message)
        {
        }

        public UserExistsInDatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserExistsInDatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}