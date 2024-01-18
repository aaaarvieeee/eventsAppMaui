using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    public class User : IBooking
    {

        public string accountNum { get; set; }
        public string bookingNum { get; set; }
        public string eventId { get; set; }

        public string eventName { get; set; }

        public string eventLocation { get; set; }
        public string eventType { get; set; }

        public string eventDate { get; set; }
        public int eventQty { get; set; }
        public int eventPrice { get; set; }


        public User(string accountNum, string bookingNum, string eventId)

        {
            this.accountNum = accountNum;
            this.bookingNum = bookingNum;
            this.eventId = eventId;
        }

        public User(string accountNum, string eventId)
        {
            this.accountNum = accountNum;
            this.eventId = eventId;
        }

        public User(string accountNum, string eventId, string eventName, string eventAddress, string eventType, string eventDate, int eventQty, int eventPrice)
        {
            this.accountNum = accountNum;
            this.eventId = eventId;
            this.eventName = eventName;
            this.eventLocation = eventAddress;
            this.eventType = eventType;
            this.eventDate = eventDate;
            this.eventQty = eventQty;
            this.eventPrice = eventPrice;
        }

        public User(string eventId) { this.eventId = eventId; }

        public User()
        {
        }

        public string GenerateBookingNum()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string chars1 = "0123456789";
            var random = new Random();
            int index = random.Next(chars.Length);
            var a = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                int index1 = random.Next(chars1.Length);
                a.Append(chars1[index1]);
            }
            return bookingNum = chars[index] + a.ToString();
        }

        public static string GenerateRandomSaveCode()
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


        public string GenerateAccountNum()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string chars1 = "0123456789";
            var random = new Random();
            int index = random.Next(chars.Length);
            var a = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                int index1 = random.Next(chars1.Length);
                a.Append(chars1[index1]);
            }
            return bookingNum = chars[index] + a.ToString();
        }
    }
}