using Microsoft.Maui.Controls;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp3.Pages;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Logging;

namespace MauiApp3.Data
{
	public class Connection : Event 
	{

        public Connection()
        { 
            InitializeConnection();
        }

        public static List<Event> events = new List<Event>();
        public static void InitializeConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                UserID = "root",
                Password = "password",
                Database = "demo222"
            };


            MySqlConnection connections = new MySqlConnection(builder.ConnectionString);
            connections.Open();


            string sqlSelect = "SELECT * FROM Events";

            MySqlCommand command = new MySqlCommand(sqlSelect, connections);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int EventID = reader.GetInt32(0);
                string EventName = reader.GetString(1);
                string EventAddress = reader.GetString(2);
                string EventType = reader.GetString(3);
                string EventDate = reader.GetString(4);
                double EventPrice = reader.GetDouble(5);
                int EventQty = reader.GetInt32(6);

                EventManagement s = new EventManagement(EventID, EventName, EventAddress, EventType, EventDate, EventQty, EventPrice);
                events.Add(s);
            }

            connections.Close();
        }

        public static List<Event> GetEvents()
        {
            return events;
        }

        //List for the bookedevent database
        public static List<User> bookEvent = new List<User>();

        public static List<User> GetUsersBook()
        {
            return bookEvent;
        }

        public async static void AddNewAccount(int AccountNum, string username, string password, string email, string fname, string lname, string phone, string dob)
        {

            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    UserID = "root",
                    Password = "password",
                    Database = "demo222"
                };

                MySqlConnection connections = new MySqlConnection(builder.ConnectionString);
                connections.Open();

                string sqlCheck = "SELECT COUNT(*) FROM account WHERE account_id = @AccountNum";
                using MySqlCommand command = new MySqlCommand(sqlCheck, connections);
                command.Parameters.AddWithValue("@AccountNum", AccountNum);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if(count > 0)
                {
                    throw new UserException("null");

                }
                else
                {
                    string sqlAdd = "INSERT INTO account (account_id, Username, Password, FirstName, LastName, PhoneNumber, EmailAddress, DateOfBirth) VALUES (@AccountNum, @User, @Pass, @Fname, @Lname, @Phone, @Email, @DOB)";
                    using MySqlCommand addCommand = new MySqlCommand(sqlAdd, connections);
                    addCommand.Parameters.AddWithValue("@AccountNum", AccountNum);
                    addCommand.Parameters.AddWithValue("@User", username);
                    addCommand.Parameters.AddWithValue("@Pass", password);
                    addCommand.Parameters.AddWithValue("@Fname", fname);
                    addCommand.Parameters.AddWithValue("@Lname", lname);
                    addCommand.Parameters.AddWithValue("@Phone", phone);
                    addCommand.Parameters.AddWithValue("@Email", email);
                    addCommand.Parameters.AddWithValue("@DOB", dob);

                    addCommand.ExecuteNonQuery();
                }

                connections.Close();
            }
            catch(UserException e)
            {
                UserException myClass = new UserException();
                await myClass.ShowAlert("Error", e.Message, "OK");
            }

        }

        public async void bookedDatabase(string bookingNum, string eventId, string accountNum)
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    UserID = "root",
                    Password = "password",
                    Database = "demo222"
                };

                using MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
                connection.Open();

                string sqlCheck = "SELECT COUNT(*) FROM bookings WHERE event_id = @eventId AND account_id = @accountNum";
                using MySqlCommand command = new MySqlCommand(sqlCheck, connection);
                command.Parameters.AddWithValue("@eventId", eventId);
                command.Parameters.AddWithValue("@accountNum", accountNum);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    throw new UserException("Already Booked");
                }
                else
                {
                    string sqlAdd = "INSERT INTO bookings (booking_number, event_id, account_id) VALUES (@bookingNum, @eventId, @accountNum)";
                    using MySqlCommand addCommand = new MySqlCommand(sqlAdd, connection);
                    addCommand.Parameters.AddWithValue("@bookingNum", bookingNum);
                    addCommand.Parameters.AddWithValue("@eventId", eventId);
                    addCommand.Parameters.AddWithValue("@accountNum", accountNum);

                    addCommand.ExecuteNonQuery();

                    User u = new User(accountNum, eventId);
                    bookEvent.Add(u);
                }

                connection.Close();
            }
            catch (UserException ex)
            {
                UserException myClass = new UserException();
                await myClass.ShowAlert("Error", ex.Message, "OK");
            }
        }



        //list for the saveevent database
        public static List<User> saveEvent = new List<User>();

        public static List<User> GetUserSave()
        {
            return saveEvent;
        }


        public async void savedDatabase(string eventId, string savenum)

        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    UserID = "root",
                    Password = "password",
                    Database = "demo222"
                };

                using MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
                connection.Open();


                string sqlCheck = "SELECT Count(*) FROM savings WHERE event_id = @eventId";
                using MySqlCommand command = new MySqlCommand(sqlCheck, connection);
                command.Parameters.AddWithValue("@eventId", eventId);
                //command.Parameters.AddWithValue("@eventName", eventName);
                //command.Parameters.AddWithValue("@eventType", eventType);
                //command.Parameters.AddWithValue("@eventAddress", eventAddress);
                //command.Parameters.AddWithValue("@eventDate", eventDate);
                //command.Parameters.AddWithValue("@eventQty", eventQty);
                //command.Parameters.AddWithValue("@eventPrice", eventPrice);

				int count = Convert.ToInt32(command.ExecuteScalar());

                if (count > 0)
                {
                    throw new UserException("Already Saved");
                }
                else
                {

                    string sqlAdd = "INSERT INTO savings (savings_id, event_id) VALUES (@save, @eventId)";
                    using MySqlCommand addCommand = new MySqlCommand(sqlAdd, connection);
                    //addCommand.Parameters.AddWithValue("@bookingNum", bookingNum); //Booking number not required for saved // EventType, EventAddress, EventDate, EventQty, EventPrice // @eventType, @eventAddress, @eventQty, @eventPrice
                    addCommand.Parameters.AddWithValue("@eventId", eventId);
                    addCommand.Parameters.AddWithValue("@save", savenum);
                    //addCommand.Parameters.AddWithValue("@eventName", eventName);
                    //addCommand.Parameters.AddWithValue("@eventType", eventType);
                    //addCommand.Parameters.AddWithValue("@eventAddress", eventAddress);
                    //addCommand.Parameters.AddWithValue("@eventDate", eventDate);
                    //addCommand.Parameters.AddWithValue("@eventQty", eventQty);
                    //addCommand.Parameters.AddWithValue("@eventPrice", eventPrice);

                    addCommand.ExecuteNonQuery();

                    User u = new User(eventId, savenum);
                    saveEvent.Add(u);
                }

                connection.Close();
            }
            catch (UserException ex)
            {
                UserException myClass = new UserException();
                await myClass.ShowAlert("Error", ex.Message, "OK");
            }
        }
        
		public async void DeleteSavedFromDatabase(string eventId)
		{
			try
			{
				MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
				{
					Server = "127.0.0.1",
					UserID = "root",
					Password = "password",
					Database = "demo222"
				};

				using MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
				connection.Open();

				string sqlCheck = "SELECT Count(*) FROM saved WHERE event_id = @eventId";
				using MySqlCommand command = new MySqlCommand(sqlCheck, connection);
				command.Parameters.AddWithValue("@eventId", eventId);

				//string sqlCheck = "SELECT * FROM saved WHERE event_id IS NOT NULL";
				//using MySqlCommand command = new MySqlCommand(sqlCheck, connection);
				//command.Parameters.AddWithValue("@eventId", eventId);

				int event_id = Convert.ToInt32(command.ExecuteScalar());

				if (eventId != null)
				{
					throw new UserException("Already Deleted");
				}
				else
				{
					string sqlDelete = "DELETE FROM saved WHERE event_id = @eventId";
					using MySqlCommand deleteCommand = new MySqlCommand(sqlDelete, connection);
					//addCommand.Parameters.AddWithValue("@bookingNum", bookingNum); //Booking number not required for saved // EventType, EventAddress, EventDate, EventQty, EventPrice // @eventType, @eventAddress, @eventQty, @eventPrice
					deleteCommand.Parameters.AddWithValue("@eventId", eventId);
					//addCommand.Parameters.AddWithValue("@accountNum", accountNum);
					//addCommand.Parameters.AddWithValue("@eventName", eventName);
					//addCommand.Parameters.AddWithValue("@eventType", eventType);
					//addCommand.Parameters.AddWithValue("@eventLocation", eventAddress);
					//addCommand.Parameters.AddWithValue("@eventDate", eventDate);
					//addCommand.Parameters.AddWithValue("@eventQty", eventQty);
					//addCommand.Parameters.AddWithValue("@eventPrice", eventPrice);

					deleteCommand.ExecuteNonQuery();

					User u = new User(eventId);
					saveEvent.Remove(u);

				}

				connection.Close();
			}
			catch (UserException ex)
			{
				UserException myClass = new UserException();
				await myClass.ShowAlert("Error", ex.Message, "OK");
			}
		}
	}

}
