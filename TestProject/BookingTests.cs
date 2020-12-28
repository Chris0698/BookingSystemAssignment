 

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;
using ImplementationOfObjectOrientedDesigns.Utilities;
using NSubstitute;

namespace TestProject
{
    [TestClass]
    public class BookingTests
    {

        [TestMethod]
        public void TestBookingConstructor()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE, 
                mockClient, mockDate, mockTime, mockVenue);

            Assert.AreEqual(ID, booking.bookingID);
            Assert.AreEqual(mockClient.GetID(), booking.client.GetID());
            Assert.AreEqual(mockDate.GetDatabaseFormat(), booking.GetDate().GetDatabaseFormat());
            Assert.AreEqual(mockTime.GetFormatted(), booking.GetTime().GetFormatted());
            Assert.AreEqual(mockVenue, booking.venue);
            Assert.AreEqual(BookingType.SIMPLE, booking.GetBookingType());
            Assert.AreEqual(0.0M, booking.cost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Booking ID is null")]
        public void TestBookingConstructorNullIDRaisesArgumentNullException()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = null;

            new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Client is null")]
        public void TestBookingConstructorNullClientRaisesArgumentNullException()
        {
            //instanciate mock objects
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            new Booking(ID, BookingType.SIMPLE,
                null, mockDate, mockTime, mockVenue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Date is null")]
        public void TestBookingConstructorNullDateRaisesArgumentNullException()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            new Booking(ID, BookingType.SIMPLE,
                mockClient, null, mockTime, mockVenue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Time is null")]
        public void TestBookingConstructorNullTimeRaisesArgumentNullException()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, null, mockVenue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Venue is null")]
        public void TestBookingConstructorNullVenueRaisesArgumentNullException()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            string ID = null;

            new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, null);
        }

        [TestMethod]
        public void TestBookingAddActivity()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            IActivity mockActivity = Substitute.For<IActivity>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            booking.AddActivity(mockActivity);
            Assert.AreEqual(mockActivity, booking.activity);
        }

        [TestMethod]
        public void TestBookingGetActivity()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();

            IActivity mockActivity = Substitute.For<Activity>();
            mockActivity.activityName = "testName";
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            booking.activity = mockActivity;

            Assert.AreEqual(mockActivity.activityName, booking.GetActivity().activityName);
        }

        [TestMethod]
        public void TestBookingGetID()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            Assert.AreEqual(ID, booking.GetID());
        }

        [TestMethod]
        public void TestBookingGetVenue()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<Venue>();
            mockVenue.venueName = "VenueName";
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            Assert.AreEqual(mockVenue.venueName, booking.GetVenue().venueName);
        }

        [TestMethod]
        public void TestBookingGetClient()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            Assert.AreEqual(mockClient.GetID(), booking.GetClient().GetID());
        }

        [TestMethod]
        public void TestBookingGetDate()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            Assert.AreEqual(mockDate.GetFormatted(), booking.GetDate().GetFormatted());
        }

        [TestMethod]
        public void TestBookingGetTime()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            Assert.AreEqual(mockTime.GetFormatted(), booking.GetTime().GetFormatted());
        }

        [TestMethod]
        public void TestBookingGetBookingType()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            Assert.AreEqual(BookingType.SIMPLE, booking.GetBookingType());
        }

        [TestMethod]
        public void TestBookingGetExtras()
        {
            string returnValue = "Extras\nVenueName";
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            mockVenue.venueExtras.Returns(returnValue);
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            Assert.IsTrue(booking.GetExtras().Contains("Extras"));
        }

        [TestMethod]
        public void TestBookingUpdateDate()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            Date date = new Date(12, 9, 2019);
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, date, mockTime, mockVenue);
            PrivateObject privateAccessor = new PrivateObject(date);

            int day = 12;
            int month = 10;
            int year = 1234;

            booking.UpdateDate(day, month, year);
            Assert.AreEqual(day, privateAccessor.GetField("day"));
            Assert.AreEqual(month, privateAccessor.GetField("month"));
            Assert.AreEqual(year, privateAccessor.GetField("year"));
        }

        [TestMethod]
        public void TestBookingUpdateTime()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            IVenue mockVenue = Substitute.For<IVenue>();
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time time = new Time(12, 54);
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, time, mockVenue);
            PrivateObject privateAccessor = new PrivateObject(time);

            int hour = 12;
            int minute = 10;

            booking.UpdateTime(hour, minute);

            Assert.AreEqual(hour, privateAccessor.GetField("hour"));
            Assert.AreEqual(minute, privateAccessor.GetField("minute"));
        }

        [TestMethod]
        public void TestBookingUpdateCostsWithNoActivity()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            IVenue mockVenue = Substitute.For<IVenue>();
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            mockVenue.cost.Returns(15);

            booking.UpdateCosts();
            Assert.AreEqual<decimal>(15, booking.cost);
        }

        [TestMethod]
        public void TestBookingUpdateCostsWithActivity()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            IVenue mockVenue = Substitute.For<IVenue>();
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IActivity mockActivity = Substitute.For<IActivity>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            booking.AddActivity(mockActivity);

            mockVenue.cost.Returns(15);
            mockActivity.cost.Returns(12);

            booking.UpdateCosts();
            Assert.AreEqual<decimal>(27, booking.cost);
        }

        [TestMethod]
        public void TestBookingSetDateAndTime()
        {
            Booking booking = new Booking
            {
                date = "1000-09-12",
                time = "16:23"
            };

            booking.SetDateAndTime();

            PrivateObject privateAccessor = new PrivateObject(booking);

            Date date = (Date)privateAccessor.GetField("bookingDate");
            Time time = (Time)privateAccessor.GetField("bookingTime");

            Assert.AreEqual<int>(1000, date.GetYear());
            Assert.AreEqual<int>(9, date.GetMonth());
            Assert.AreEqual<int>(12, date.GetDay());
            Assert.AreEqual<int>(16, time.GetHour());
            Assert.AreEqual<int>(23, time.GetMinute());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Year could not be cast to an integer")]
        public void TestBookingSetDateAndTimeYearCannotBeParsed()
        {
            Booking booking = new Booking
            {
                date = "year-09-12",
                time = "16:23"
            };

            booking.SetDateAndTime();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Month could not be cast to an integer")]
        public void TestBookingSetDateAndTimeMonthCannotBeParsed()
        {
            Booking booking = new Booking
            {
                date = "1000-Mo-12",
                time = "16:23"
            };

            booking.SetDateAndTime();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Day could not be cast to an integer")]
        public void TestBookingSetDateAndTimeDayCannotBeParsed()
        {
            Booking booking = new Booking
            {
                date = "1000-09-Da",
                time = "16:23"
            };

            booking.SetDateAndTime();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Hour could not be cast to an integer")]
        public void TestBookingSetDateAndTimeHourCannotBeParsed()
        {
            Booking booking = new Booking
            {
                date = "1000-09-12",
                time = "Hr:23"
            };

            booking.SetDateAndTime();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Minute could not be cast to an integer")]
        public void TestBookingSetDateAndTimeMinuteCannotBeParsed()
        {
            Booking booking = new Booking
            {
                date = "year-09-12",
                time = "16:Mi"
            };

            booking.SetDateAndTime();
        }

        [TestMethod]
        public void TestBookingUpdateGetCost()
        {
            //instanciate mock objects
            Client mockClient = Substitute.For<Client>("CliID", "CoName", "CoAddress");
            IVenue mockVenue = Substitute.For<IVenue>();
            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IActivity mockActivity = Substitute.For<IActivity>();
            string ID = "123";

            Booking booking = new Booking(ID, BookingType.SIMPLE,
                mockClient, mockDate, mockTime, mockVenue);

            booking.AddActivity(mockActivity);

            mockVenue.cost.Returns(15);
            mockActivity.cost.Returns(12);

            Assert.AreEqual<decimal>(27, booking.GetCost());
        }
    }
}
