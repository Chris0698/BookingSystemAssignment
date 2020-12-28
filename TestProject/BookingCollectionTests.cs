 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Utilities;
using ImplementationOfObjectOrientedDesigns.Domain;
using NSubstitute;

namespace TestProject
{
    [TestClass]
    public class BookingCollectionTests
    {
        [TestMethod]
        public void BookingCollectionGetClientBookingsReturnsList()
        {
            BookingCollection testCollection = new BookingCollection();

            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();

            Client client1 = new Client("123", "CompanyName1", "CompanyAddress1");
            Client client2 = new Client("456", "CompanyName2", "CompanyAddress2");

            Booking booking1 = new Booking("1", BookingType.FACILITATED,
                client1, mockDate, mockTime, mockVenue);
            Booking booking2 = new Booking("2", BookingType.FACILITATED,
                client2, mockDate, mockTime, mockVenue);

            testCollection.Add(booking1);
            testCollection.Add(booking2);

            Assert.IsTrue(testCollection.GetClientBookings(client1).Contains(booking1));
            Assert.AreEqual(1, testCollection.GetClientBookings(client1).Count);
            Assert.IsInstanceOfType(testCollection.GetClientBookings(client1), typeof(BookingCollection));
        }

        [TestMethod]
        public void BookingCollectionGetClientBookingsReturnsEmptyList()
        {
            BookingCollection testCollection = new BookingCollection();

            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();

            Client client1 = new Client("123", "CompanyName1", "CompanyAddress1");
            Client client2 = new Client("456", "CompanyName2", "CompanyAddress2");

            Booking booking1 = new Booking("1", BookingType.FACILITATED,
                client1, mockDate, mockTime, mockVenue);
            Booking booking2 = new Booking("2", BookingType.FACILITATED,
                client1, mockDate, mockTime, mockVenue);

            testCollection.Add(booking1);
            testCollection.Add(booking2);

            Assert.AreEqual(0, testCollection.GetClientBookings(client2).Count);
            Assert.IsInstanceOfType(testCollection.GetClientBookings(client1), typeof(BookingCollection));
        }

        [TestMethod]
        public void BookingCollectionDeleteIDSuccess()
        {
            BookingCollection testCollection = new BookingCollection();

            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            Client mockClient = Substitute.For<Client>("123", "CompanyName1", "CompanyAddress1");

            Booking booking1 = new Booking("1", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);
            Booking booking2 = new Booking("2", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);

            testCollection.Add(booking1);
            testCollection.Add(booking2);

            testCollection.DeleteID("1");

            Assert.AreEqual<int>(1, testCollection.GetSize());
            Assert.IsTrue(testCollection.Contains(booking2));
        }

        [TestMethod]
        public void BookingCollectionDeleteIDWithNoMatchingID()
        {
            BookingCollection testCollection = new BookingCollection();

            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            Client mockClient = Substitute.For<Client>("123", "CompanyName1", "CompanyAddress1");

            Booking booking1 = new Booking("1", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);
            Booking booking2 = new Booking("2", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);

            testCollection.Add(booking1);
            testCollection.Add(booking2);

            testCollection.DeleteID("3");

            Assert.AreEqual<int>(2, testCollection.GetSize());
            Assert.IsTrue(testCollection.Contains(booking1));
            Assert.IsTrue(testCollection.Contains(booking2));
        }

        [TestMethod]
        public void BookingCollectionGetByIDSuccess()
        {
            BookingCollection testCollection = new BookingCollection();

            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            Client mockClient = Substitute.For<Client>("123", "CompanyName1", "CompanyAddress1");

            Booking booking1 = new Booking("1", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);
            Booking booking2 = new Booking("2", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);

            testCollection.Add(booking1);
            testCollection.Add(booking2);

            Assert.AreEqual<Booking>(booking1, testCollection.GetByID("1"));
            Assert.AreEqual<Booking>(booking2, testCollection.GetByID("2"));
        }

        [TestMethod]
        public void BookingCollectionGetByIDReturnsNullOnNoBookingFound()
        {
            BookingCollection testCollection = new BookingCollection();

            Date mockDate = Substitute.For<Date>(12, 9, 2019);
            Time mockTime = Substitute.For<Time>(12, 54);
            IVenue mockVenue = Substitute.For<IVenue>();
            Client mockClient = Substitute.For<Client>("123", "CompanyName1", "CompanyAddress1");

            Booking booking1 = new Booking("1", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);
            Booking booking2 = new Booking("2", BookingType.FACILITATED,
                mockClient, mockDate, mockTime, mockVenue);

            testCollection.Add(booking1);
            testCollection.Add(booking2);

            Assert.AreEqual<Booking>(null, testCollection.GetByID("3"));
        }
    }
}
