using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    [Serializable]
    internal class NameLeftEmptyException : Exception
    {
        public NameLeftEmptyException()
        {
        }

        public NameLeftEmptyException(string message) : base(message)
        {
        }


        public NameLeftEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameLeftEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
