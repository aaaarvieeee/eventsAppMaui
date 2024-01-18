using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    public class UserException : Exception
    {
        public UserException() { }
        public UserException(string message) : base(message)
        {

        }
        public UserException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public async Task ShowAlert(string title, string message, string buttonText)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, buttonText);
        }
    }
}
