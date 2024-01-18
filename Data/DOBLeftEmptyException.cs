using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    [Serializable]
    internal class DOBLeftEmptyException : Exception
    {
        public DOBLeftEmptyException()
        {
        }

        public DOBLeftEmptyException(string message) : base(message)
        {
        }


        public DOBLeftEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DOBLeftEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
