///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementationOfObjectOrientedDesigns.Utilities;
using ImplementationOfObjectOrientedDesigns.DataAccess;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class Booking : IBooking
    {
        //EF stuff
        [Key]
        public string bookingID { get; set; }

        public String bookingType { get; set; }        

        public string activityID { get; set; }        

        public string clientID { get; set; }            

        public string venueID { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        public bool confirmed { get; set; }

        public decimal cost
        {
            get
            {
                return _cost;
            }
            set
            {
                if (value < 0.0M)
                {
                    throw new Exception("Cost can't be a negative");
                }

                _cost = value;
            }
        }

        //end of EF data

        public IClient client;
        public IVenue venue;
        public IActivity activity;
        private decimal _cost;
        private BookingType bookingTypeEnum;
        private Date bookingDate;
        private Time bookingTime;


        public Booking() 
        {
            bookingDate = new Date(1, 1, 2000);
            bookingTime = new Time(0, 0);
            cost = 0.0M;
        }


        public Booking(string ID, BookingType bookingType, Client client, Date date, Time time, IVenue venue)
        {
            //bookingType can never be null

            if(String.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("Booking ID is null");
            }
            if(client == null)
            {
                throw new ArgumentNullException("Client is null");
            }
            if(date == null)
            {
                throw new ArgumentNullException("Date is null");
            }
            if(time == null)
            {
                throw new ArgumentNullException("Time is null");
            }
            if(venue == null)
            {
                throw new ArgumentNullException("Venue is null");
            }


            this.bookingTypeEnum = bookingType;
            this.client = client;
            bookingDate = date;
            bookingTime = time;
            this.bookingID = ID.Trim();
            this.venue = venue;
            this.cost = 0.0M;
            cost = 0.0M;
            confirmed = false;
        }

        public void AddActivity(IActivity activity)
        {
            if (activity == null)
            {
                throw new ArgumentNullException("Activity is null");
            }

            this.activity = activity;
        }

        public List<string> GetExtras()
        {
            string notes = venue.venueExtras;

            List<string> extras = new List<string>();

            if(notes != null)
            {
                string[] value = notes.Split('\n');
                
                foreach (string item in value)
                {
                    extras.Add(item);
                }

                //last element is always the venue name itself
                extras.RemoveAt(extras.Count - 1);
                
            }

            return extras;            
        }

        public string GetID()
        {
            return bookingID;
        }

        public IVenue GetVenue()
        {
            return venue.Clone();
        }

        public IClient GetClient()
        {
            return client.Clone();
        }

        public IActivity GetActivity()
        {
            return activity.Clone();
        }

        public Date GetDate()
        {
            return bookingDate.Clone();
        }

        public Time GetTime()
        {
            return bookingTime.Clone();
        }

        public void UpdateDate(int day, int month, int year)
        {
            bookingDate.SetDate(day, month, year);
        }

        public void UpdateTime(int hour, int minute)
        {
            bookingTime.SetTime(hour, minute);
        }

        public void SetDateAndTime()
        {
            int year = 0;
            int month = 0;
            int day = 0;
            int hour = 0;
            int minute = 0;

            if(!Int32.TryParse(date.Substring(0, 4), out year))
            {
                throw new Exception("Year could not be cast to an integer");
            }
            if (!Int32.TryParse(date.Substring(5, 2), out month))
            {
                throw new Exception("Month could not be cast to an integer");
            }
            if (!Int32.TryParse(date.Substring(8, 2), out day))
            {
                throw new Exception("Day could not be cast to an integer");
            }

            if (!Int32.TryParse(time.Substring(0, 2), out hour))
            {
                throw new Exception("Hour could not be cast to an integer");
            }
            if (!Int32.TryParse(time.Substring(3, 2), out minute))
            {
                throw new Exception("Minute could not be cast to an integer");
            }

            UpdateDate(day, month, year);
            UpdateTime(hour, minute);
        }

        public decimal GetCost()
        {
            UpdateCosts();
            return cost;
        }

        public BookingType GetBookingType()
        {
            return bookingTypeEnum;
        }

        public override string ToString()
        {
            return "Ref: " + bookingID + "\t Date: " + bookingDate.GetFormatted() + "\t Time: " + bookingTime.GetFormatted();
        }

        // Checks third party companies are stil avilable
        public bool CheckThirdPartyCompanies()
        {
            // Returns true if companies are still available 
            ThirdPartyCompany company = new ThirdPartyCompany();

            return company.CheckAvailable();
        }

        // Updates costs before booking is confirmed
        public void UpdateCosts()
        {
            decimal activityCost = (activity == null) ? 0M : activity.cost;
            decimal venueAddOnCosts = venue.cost;
            cost = activityCost + venueAddOnCosts;
        }
    }
}
