using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
    internal class Saved
    {
		public int EventID;
		public string EventName;
		public string EventAddress;
		public string EventType;
		public string EventDate;
		public int EventQty;
		public int EventPrice;

		public Saved()
		{ 
		}

		public Saved(int eventID, string eventName, string eventAddress, string eventType, string eventDate, int eventQty, int eventPrice)
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
