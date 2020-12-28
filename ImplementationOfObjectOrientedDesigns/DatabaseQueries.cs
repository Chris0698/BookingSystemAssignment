 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementationOfObjectOrientedDesigns.Domain;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace ImplementationOfObjectOrientedDesigns.DataAccess
{
    public class DatabaseQueries
    {
        private static void ShowErrorMessage(Exception exception)
        {
            System.Windows.Forms.MessageBox.Show(exception.Message, 
                                                 "Exception", 
                                                 System.Windows.Forms.MessageBoxButtons.OK, 
                                                 System.Windows.Forms.MessageBoxIcon.Error
            );
        }


        public static Collection<Client> GetAllClients()
        {
            Collection<Client> clients = new Collection<Client>();
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    IQueryable<Client> query = from client in context.Client select client;
                    foreach (Client client in query)
                    {
                        clients.Add(client);
                    }
                }
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception);    
            }

            return clients;
        }

        public static BookingCollection GetAllBookings()
        {
            BookingCollection bookings = new BookingCollection();

            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    IQueryable<Booking> query = from booking in context.Bookings
                                                where (booking.confirmed == false)
                                                select booking;

                    foreach (Booking booking in query)
                    {
                        Client client = GetClient(booking.clientID);
                        if (client == null)
                        {
                            throw new Exception("Null returned for client");
                        }
                        booking.client = client;

                        IActivity activity = GetActivity(booking.activityID);
                        if (activity == null)
                        {
                            throw new Exception("Null returned for activity");
                        }
                        booking.activity = activity;

                        IVenue venue = GetVenue(booking.venueID);
                        if (venue == null)
                        {
                            throw new Exception("Null returned for venue");
                        }
                        booking.venue = venue;
                        booking.SetDateAndTime();
                        
                        bookings.Add(booking);
                    }
                }
            }
            catch(Exception exception)
            {
                ShowErrorMessage(exception);
            }

            return bookings;
        }

        public static Client GetClient(string ID)
        {
            if(String.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("ID cant be null");
            }

            Client clientPerson = null;
            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    Client query = (from client in context.Client where (client.ID == ID) select client).SingleOrDefault();
                    clientPerson = query;

                }
            }
            catch(Exception exception)
            {
                ShowErrorMessage(exception);
            }

            return clientPerson;            
        }

        public static Venue GetVenue(string bookingID)
        {
            if(String.IsNullOrEmpty(bookingID))
            {
                throw new ArgumentNullException("ID cant be null");
            }

            Venue venueResult = null;
            VenueFactory venueFactory = VenueFactory.GetInstance;
            List<VenueDecorator> venueDecorators = new List<VenueDecorator>();
            List<VenueExtrasLink> extrasLinks = new List<VenueExtrasLink>();

            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    venueResult = (from venue in context.Venue where (venue.ID == bookingID) select venue).SingleOrDefault();

                    IQueryable<VenueExtrasLink> data = from extras in context.VenueExtrasLink
                                                       where extras.bookingID == bookingID
                                                       select extras;

                    foreach (VenueExtrasLink extra in data)
                    {
                        extrasLinks.Add(extra);
                    }


                    foreach (VenueExtrasLink extra in extrasLinks)
                    {
                        IQueryable<VenueDecorator> decorators = from decorator in context.VenueDecorator
                                                                where decorator.ID == extra.extraID
                                                                select decorator;

                        foreach (VenueDecorator decorator in decorators)
                        {
                            venueDecorators.Add(decorator);
                        }
                    }

                    if (venueDecorators.Count > 0)
                    {
                        venueFactory.AddFeatures(venueResult, venueDecorators);
                    }
                }
            }
            catch(Exception exception)
            {
                ShowErrorMessage(exception);
            }
           
            return venueResult;
        }


        public static IActivity GetActivity(string ID)
        {
            if(String.IsNullOrEmpty(ID))
            {
                throw new ArgumentNullException("ID cant be null");
            }

            IActivity activityResult = null;
            ActivityFactory activityFactory = ActivityFactory.GetInstance;

            try
            {
                using (DatabaseEntities context = new DatabaseEntities())
                {
                    Activity query = (from activity in context.Activity where (activity.ID == ID) select activity).SingleOrDefault();

                    switch (query.activityName)
                    {
                        case "Go Kart":
                            activityResult = activityFactory.CreateActivity(ActivityTypes.GO_KART, query.ID, query.cost);
                            break;
                        case "Wall Climbing":
                            activityResult = activityFactory.CreateActivity(ActivityTypes.WALL_CLIMBING, query.ID, query.cost);
                            break;
                        case "Meditation and Mindfulness":
                            activityResult = activityFactory.CreateActivity(ActivityTypes.MEDITATION_AND_MINDFULLNESS, query.ID, query.cost);
                            break;
                        case "Team Building and Problem Solving":
                            activityResult = activityFactory.CreateActivity(ActivityTypes.TEAM_BUILDING_AND_PROBLEM_SOLVING, query.ID, query.cost);
                            break;
                        case "Choclate Producing and Marketing":
                            activityResult = activityFactory.CreateActivity(ActivityTypes.CHOCOLATE_PRODUCING_AND_MARKETING, query.ID, query.cost);
                            break;
                        default:
                            throw new Exception("Activity doesn't exist.");
                    }
                }
            }
            catch(Exception exception)
            {
                ShowErrorMessage(exception);
            }

            return activityResult;
        }

        public static void CancelBooking(IBooking bookingToCancel)
        {
            if(bookingToCancel == null)
            {
                throw new ArgumentNullException("Booking cant be null");
            }

            using (DatabaseEntities context = new DatabaseEntities())
            {
                Booking result = (from booking in context.Bookings
                                  where booking.bookingID == bookingToCancel.bookingID
                                  select booking).SingleOrDefault();

                if (result != null)
                {
                    context.Bookings.Remove(result);
                    context.SaveChanges();
                }
            }
        }

        public static void ConfirmBooking(IBooking bookingToConfirm)
        {
            if(bookingToConfirm == null)
            {
                throw new ArgumentNullException("Booking cant be null");
            }

            using (DatabaseEntities context = new DatabaseEntities())
            {
                Booking result = (from booking in context.Bookings
                                  where booking.bookingID == bookingToConfirm.bookingID
                                  select booking).SingleOrDefault();

                if (result != null)
                {
                    result.confirmed = true;
                    result.date = bookingToConfirm.GetDate().GetDatabaseFormat();
                    result.time = bookingToConfirm.GetTime().GetFormatted();
                    result.cost = bookingToConfirm.GetCost();
                    if (bookingToConfirm.GetBookingType() == BookingType.SIMPLE)
                    {
                        result.bookingType = "simple";
                    }
                    else
                    {
                        result.bookingType = "facilitated";
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
