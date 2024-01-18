using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    [Serializable]
    internal class EmailLeftEmptyException : Exception
    {
        public EmailLeftEmptyException()
        {
        }

        public EmailLeftEmptyException(string message) : base(message)
        {
        }


        public EmailLeftEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailLeftEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
