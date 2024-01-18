using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    [Serializable]
    internal class PhoneLeftEmptyException : Exception
    {
        public PhoneLeftEmptyException()
        {
        }

        public PhoneLeftEmptyException(string message) : base(message)
        {
        }


        public PhoneLeftEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PhoneLeftEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
