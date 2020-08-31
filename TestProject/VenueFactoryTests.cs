///Chris Aston, Carlton Evans, Sam Noble

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

namespace TestProject
{
    [TestClass]
    public class VenueFactoryTests
    {
        [TestMethod]
        public void TestVenueFactoryGetInstance()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;
            PrivateObject privateAccessor = new PrivateObject(venueFactory);
            privateAccessor.SetField("venueFeatures", new Hashtable()); // Reset venueFeatures

            Assert.IsInstanceOfType(VenueFactory.GetInstance, typeof(VenueFactory));
            Hashtable refVenueFeatures = (Hashtable)privateAccessor.GetField("venueFeatures");
            Assert.AreEqual<int>(0, refVenueFeatures.Count);
        }

        [TestMethod]
        public void TestVenueFactoryGetInstanceReturnsSameInstance()
        {
            VenueFactory venueFactory1 = VenueFactory.GetInstance;
            VenueFactory venueFactory2 = VenueFactory.GetInstance;

            Assert.AreEqual<VenueFactory>(venueFactory1, venueFactory2);
        }

        [TestMethod]
        public void TestVenueFactoryRegisterSuccess()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;
            PrivateObject privateAccessor = new PrivateObject(venueFactory);
            privateAccessor.SetField("venueFeatures", new Hashtable()); // Reset venueFeatures
            Hashtable refVenueFeatures = (Hashtable)privateAccessor.GetField("venueFeatures");


            VenueAfternoonRefreshments mockVAfterRef = Substitute.For<VenueAfternoonRefreshments>();
            VenueMorningRefreshments mockVMornRef = Substitute.For<VenueMorningRefreshments>();
            VenueEveningMeal mockVEveMeal = Substitute.For<VenueEveningMeal>();
            VenueBusTransport mockVBusTrans = Substitute.For<VenueBusTransport>();
            VenueMiddayLunch mockVMidLunch = Substitute.For<VenueMiddayLunch>();

            venueFactory.Register(VenueAddOns.MORNING_REFRESHMENTS, mockVMornRef);
            Assert.IsTrue(refVenueFeatures.ContainsKey(VenueAddOns.MORNING_REFRESHMENTS));
            Assert.IsTrue(refVenueFeatures.ContainsValue(mockVMornRef));
            Assert.AreEqual<int>(1, refVenueFeatures.Count);

            venueFactory.Register(VenueAddOns.AFTERNOON_REFRESHMENTS, mockVAfterRef);
            Assert.IsTrue(refVenueFeatures.ContainsKey(VenueAddOns.AFTERNOON_REFRESHMENTS));
            Assert.IsTrue(refVenueFeatures.ContainsValue(mockVAfterRef));
            Assert.AreEqual<int>(2, refVenueFeatures.Count);

            venueFactory.Register(VenueAddOns.EVENING_MEAL, mockVEveMeal);
            Assert.IsTrue(refVenueFeatures.ContainsKey(VenueAddOns.EVENING_MEAL));
            Assert.IsTrue(refVenueFeatures.ContainsValue(mockVEveMeal));
            Assert.AreEqual<int>(3, refVenueFeatures.Count);

            venueFactory.Register(VenueAddOns.BUS_TRANSPORTS, mockVBusTrans);
            Assert.IsTrue(refVenueFeatures.ContainsKey(VenueAddOns.BUS_TRANSPORTS));
            Assert.IsTrue(refVenueFeatures.ContainsValue(mockVBusTrans));
            Assert.AreEqual<int>(4, refVenueFeatures.Count);

            venueFactory.Register(VenueAddOns.MIDDAY_LUNCH, mockVMidLunch);
            Assert.IsTrue(refVenueFeatures.ContainsKey(VenueAddOns.MIDDAY_LUNCH));
            Assert.IsTrue(refVenueFeatures.ContainsValue(mockVMidLunch));
            Assert.AreEqual<int>(5, refVenueFeatures.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Venue Decorator is null")]
        public void TestVenueFactoryRegisterRaisesExceptionOnNullDecorator()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;

            venueFactory.Register(VenueAddOns.AFTERNOON_REFRESHMENTS, null);
        }

        [TestMethod]
        public void TestVenueFactoryRegisterDoesNotOverwriteExisitingKeys()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;
            PrivateObject privateAccessor = new PrivateObject(venueFactory);
            privateAccessor.SetField("venueFeatures", new Hashtable()); // Reset venueFeatures
            Hashtable refVenueFeatures = (Hashtable)privateAccessor.GetField("venueFeatures");

            VenueAfternoonRefreshments mockVAfterRef = Substitute.For<VenueAfternoonRefreshments>();
            VenueBusTransport mockVBusTrans = Substitute.For<VenueBusTransport>();

            venueFactory.Register(VenueAddOns.AFTERNOON_REFRESHMENTS, mockVAfterRef);
            venueFactory.Register(VenueAddOns.AFTERNOON_REFRESHMENTS, mockVBusTrans);

            Assert.IsTrue(refVenueFeatures.ContainsKey(VenueAddOns.AFTERNOON_REFRESHMENTS));
            Assert.IsTrue(refVenueFeatures.ContainsValue(mockVAfterRef));
            Assert.AreEqual<int>(1, refVenueFeatures.Count);
        }

        [TestMethod]
        public void TestVenueFactoryAddFeaturesSuccess()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;
            PrivateObject privateAccessor = new PrivateObject(venueFactory);
            privateAccessor.SetField("venueFeatures", new Hashtable()); // Reset venueFeatures
            Venue venue = new Venue();
            List<VenueDecorator> venueAddOnList = new List<VenueDecorator>();

            VenueAfternoonRefreshments decorator1 = new VenueAfternoonRefreshments();
            PrivateObject refDecorator1 = new PrivateObject(decorator1, new PrivateType(typeof(VenueDecorator)));
            VenueMorningRefreshments decorator2 = new VenueMorningRefreshments();
            PrivateObject refDecorator2 = new PrivateObject(decorator2, new PrivateType(typeof(VenueDecorator)));

            //set up venue and decorator values
            venue.venueName = "Venue";

            decorator1.ID = "0";
            decorator1.name = "decorator1";
            decorator1.cost = 10.0M;
            decorator2.ID = "3";
            decorator2.name = "decorator2";
            decorator2.cost = 15.0M;

            venueFactory.Register(VenueAddOns.AFTERNOON_REFRESHMENTS, decorator1);
            venueFactory.Register(VenueAddOns.MORNING_REFRESHMENTS, decorator2);

            venueAddOnList.Add(decorator1);
            venueAddOnList.Add(decorator2);

            venueFactory.AddFeatures(venue, venueAddOnList);

            Assert.AreEqual<VenueComponent>(venue, (VenueComponent)refDecorator1.GetField("venueComponent"));
            Assert.AreEqual<VenueComponent>(decorator1, (VenueComponent)refDecorator2.GetField("venueComponent"));
            Assert.AreEqual<decimal>(25.0M, venue.GetCost());
            Assert.AreEqual<string>("Venue", venue.GetName());
            Assert.AreEqual<string>("decorator1\nVenue", decorator1.GetName());
            Assert.AreEqual<string>("decorator2\ndecorator1\nVenue", decorator2.GetName());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Venue add on does not exists. Has it been registered?")]
        public void TestVenueFactoryAddFeaturesRaisesExceptionOnUnregisteredVenue()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;
            PrivateObject privateAccessor = new PrivateObject(venueFactory);
            privateAccessor.SetField("venueFeatures", new Hashtable()); // Reset venueFeatures

            Venue venue = new Venue();
            List<VenueDecorator> venueAddOnList = new List<VenueDecorator>();

            VenueAfternoonRefreshments decorator1 = new VenueAfternoonRefreshments();
            VenueMorningRefreshments decorator2 = new VenueMorningRefreshments();

            //set up venue and decorator values
            venue.venueName = "Venue";
            venue.cost = 25.0M;

            decorator1.ID = "0";
            decorator1.name = "decorator1";
            decorator1.cost = 10.0M;
            decorator2.ID = "1";
            decorator2.name = "decorator2";
            decorator2.cost = 15.0M;

            venueAddOnList.Add(decorator1);
            venueAddOnList.Add(decorator2);

            venueFactory.AddFeatures(venue, venueAddOnList);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Error parsing ID")]
        public void TestVenueFactoryAddFeaturesRaisesExceptionFailingToParseID()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;
            Venue venue = new Venue();
            List<VenueDecorator> venueAddOnList = new List<VenueDecorator>();

            VenueAfternoonRefreshments decorator1 = new VenueAfternoonRefreshments();
            VenueMorningRefreshments decorator2 = new VenueMorningRefreshments();

            //set up venue and decorator values
            venue.venueName = "Venue";
            venue.cost = 25.0M;

            decorator1.ID = "brokenID";
            decorator1.name = "decorator1";
            decorator1.cost = 10.0M;
            decorator2.ID = "1";
            decorator2.name = "decorator2";
            decorator2.cost = 15.0M;

            venueAddOnList.Add(decorator1);
            venueAddOnList.Add(decorator2);

            venueFactory.AddFeatures(venue, venueAddOnList);
        }
    }
}
