using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    public abstract class Account
    {
        public int AccountNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

        public Account(int accountNumber, string username, string password, string email, string firstName, string lastName, string phoneNumber, string dateOfBirth)
        {
            AccountNumber = accountNumber;
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
        }
    }
}
