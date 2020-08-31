///Chris Aston, Carlton Evans, Sam Noble

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;

namespace TestProject
{
    [TestClass]
    public class VenueTests
    {
        [TestMethod]
        public void TestVenueConstructorNameAddressSuccess()
        {
            Venue venue = new Venue("VenueName", "VenueAddress");

            Assert.AreEqual<string>("VenueName", venue.venueName);
            Assert.AreEqual<string>("VenueAddress", venue.venueAddress);
            Assert.AreEqual<string>("", venue.venueExtras);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cannot be null or empty")]
        public void TestVenueConstructorNameAddressRaisesExceptionOnNullName()
        {
            new Venue(null, "VenueAddress");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Address cannot be null or empty")]
        public void TestVenueConstructorNameAddressRaisesExceptionOnNullAddress()
        {
            new Venue("VenueName", null);
        }

        [TestMethod]
        public void TestVenueConstructorNameAddressCostSuccess()
        {
            Venue venue = new Venue("VenueName", "VenueAddress", 10.0M);

            Assert.AreEqual<string>("VenueName", venue.venueName);
            Assert.AreEqual<string>("VenueAddress", venue.venueAddress);
            Assert.AreEqual<string>("", venue.venueExtras);
            Assert.AreEqual<decimal>(10.0M, venue.cost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Cost cannot be negative")]
        public void TestVenueConstructorNameAddressCostRaisesExceptionOnNegativeCost()
        {
            new Venue("VenueName", "VenueAddress", -1.0M);
        }

        [TestMethod]
        public void TestVenueGetAddress()
        {
            Venue venue = new Venue("VenueName", "VenueAddress");
            Assert.AreEqual<string>("VenueAddress", venue.venueAddress);
        }

    }
}
