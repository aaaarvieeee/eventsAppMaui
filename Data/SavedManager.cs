using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Data
{
	internal class SavedManager : Saved
	{
		public SavedManager()
		{
		}

		public SavedManager(int eventID, string eventName, string eventAddress, string eventType, string eventDate, int eventQty, int eventPrice) : base(eventID, eventName, eventAddress, eventType, eventDate, eventQty, eventPrice)
		{
		}

		public static List<Saved> savedEvents = new List<Saved>();

		/*
		public static List<Saved> GetSavedEvents()
		{
			return savedEvents;
		}
		*/
	}
}
