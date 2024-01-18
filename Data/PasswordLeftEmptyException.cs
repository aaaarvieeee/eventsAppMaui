using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    [Serializable]
    internal class PasswordLeftEmptyException : Exception
    {
        public PasswordLeftEmptyException()
        {
        }

        public PasswordLeftEmptyException(string message) : base(message)
        {
        }


        public PasswordLeftEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PasswordLeftEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
