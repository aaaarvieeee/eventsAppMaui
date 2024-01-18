using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    public class AccountManager : Account
    {

        public static List<AccountManager> accList = new List<AccountManager>();
        public AccountManager(int accountNumber, string username, string password, string email, string firstName, string lastName, string phoneNumber, string dateOfBirth) : base(accountNumber, username, password, email, firstName, lastName, phoneNumber, dateOfBirth)
        {
        }

        public static string GenerateRandomAccountCode()
        {
            const string chars1 = "0123456789";
            var random = new Random();
            var a = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int index1 = random.Next(chars1.Length);
                a.Append(chars1[index1]);
            }
            return a.ToString();
        }

        public static List<AccountManager> GetAccounts()
        {
            return accList;
        }

    }
}
