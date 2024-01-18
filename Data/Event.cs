using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    public abstract class Event
    {

        public int EventID;
        public string EventName;
        public string EventAddress;
        public string EventType;
        public string EventDate;
        public int EventQty;
        public double EventPrice;

        public Event()
        {
        }

        public Event(int eventID, string eventName, string eventAddress, string eventType, string eventDate, int eventQty, double eventPrice)
        {

            EventID = eventID;
            EventName = eventName;
            EventAddress = eventAddress;
            EventType = eventType;
            EventDate = eventDate;
            EventQty = eventQty;
            EventPrice = eventPrice;
        }
    }

}
