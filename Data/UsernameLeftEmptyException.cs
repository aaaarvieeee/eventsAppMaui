using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    [Serializable]
    internal class UsernameLeftEmptyException : Exception
    {
        public UsernameLeftEmptyException()
        {
        }

        public UsernameLeftEmptyException(string message) : base(message)
        {
        }


        public UsernameLeftEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UsernameLeftEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
