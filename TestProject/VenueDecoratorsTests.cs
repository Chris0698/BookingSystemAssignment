///Chris Aston, Carlton Evans, Sam Noble

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;
using NSubstitute;

namespace TestProject
{
    [TestClass]
    public class VenueDecoratorsTests
    {
        [TestMethod]
        public void TestVenueAfternoonRefDecoratorConstructor()
        {
            VenueAfternoonRefreshments decorator = new VenueAfternoonRefreshments();

            Assert.AreEqual<string>("", decorator.name);
            Assert.AreEqual<decimal>(0.0M, decorator.cost);
        }

        [TestMethod]
        public void TestVenueMorningRefDecoratorConstructor()
        {
            VenueMorningRefreshments decorator = new VenueMorningRefreshments();

            Assert.AreEqual<string>("", decorator.name);
            Assert.AreEqual<decimal>(0.0M, decorator.cost);
        }

        [TestMethod]
        public void TestVenueEveMealDecoratorConstructor()
        {
            VenueEveningMeal decorator = new VenueEveningMeal();

            Assert.AreEqual<string>("", decorator.name);
            Assert.AreEqual<decimal>(0.0M, decorator.cost);
        }

        [TestMethod]
        public void TestVenueBusTransDecoratorConstructor()
        {
            VenueBusTransport decorator = new VenueBusTransport();

            Assert.AreEqual<string>("", decorator.name);
            Assert.AreEqual<decimal>(0.0M, decorator.cost);
        }

        [TestMethod]
        public void TestVenueMiddayLunchDecoratorConstructor()
        {
            VenueMiddayLunch decorator = new VenueMiddayLunch();

            Assert.AreEqual<string>("", decorator.name);
            Assert.AreEqual<decimal>(0.0M, decorator.cost);
        }

        [TestMethod]
        public void TestVenueDecoratorSetBaseComponent()
        {
            VenueComponent baseComponent = Substitute.For<VenueComponent>();

            VenueAfternoonRefreshments decorator = new VenueAfternoonRefreshments();
            PrivateObject privateAccessor = new PrivateObject(decorator, new PrivateType(typeof(VenueDecorator)));

            decorator.SetBaseComponent(baseComponent);

            Assert.AreEqual<VenueComponent>(baseComponent, (VenueComponent)privateAccessor.GetField("venueComponent"));
        }

        [TestMethod]
        public void TestVenueDecoratorGetCost()
        {
            Venue baseVenue = new Venue();
            VenueMorningRefreshments testDecorator = new VenueMorningRefreshments();

            baseVenue.cost = 10.0M;
            testDecorator.cost = 15.0M;

            testDecorator.SetBaseComponent(baseVenue);
            Assert.AreEqual<decimal>(25.0M, testDecorator.GetCost());
        }

        [TestMethod]
        public void TestVenueDecoratorGetName()
        {
            Venue baseVenue = new Venue();
            VenueEveningMeal testDecorator = new VenueEveningMeal();

            baseVenue.venueName = "base";
            testDecorator.name = "eveningMeal";

            testDecorator.SetBaseComponent(baseVenue);
            string expectedValue = "eveningMeal\nbase";

            Assert.AreEqual<string>(expectedValue, testDecorator.GetName());
        }
    }
}
