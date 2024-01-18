using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MauiApp3.Pages;

namespace MauiApp3.Data
{

    public class EventManagement : Event
    {
        public EventManagement()
        {
        }



        public EventManagement(int eventID, string eventName, string eventAddress, string eventType, string eventDate, int eventQty, double eventPrice) : base(eventID, eventName, eventAddress, eventType, eventDate, eventQty, eventPrice)

        {
        }

        public static List<Event> matchingEvents = new List<Event>();

        public static List<Event> GetMatchingEvents()
        {
            return matchingEvents;
        }


    }

}