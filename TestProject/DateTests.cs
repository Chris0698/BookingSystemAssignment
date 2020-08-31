///Chris Aston, Carlton Evans, Sam Noble

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace TestProject
{
    [TestClass]
    public class DateTests
    {
        [TestMethod]
        public void TestDateConstructor()
        {
            Date date = new Date(10, 12, 2108);
            PrivateObject privateAccessor = new PrivateObject(date);

            Assert.AreEqual<int>(10, (int)privateAccessor.GetField("day"));
            Assert.AreEqual<int>(12, (int)privateAccessor.GetField("month"));
            Assert.AreEqual<int>(2108, (int)privateAccessor.GetField("year"));
        }

        [TestMethod]
        public void TestDateGetDay()
        {
            int day = 10;
            Date date = new Date(day, 12, 2019);

            Assert.AreEqual<int>(day, date.GetDay());
        }

        [TestMethod]
        public void TestDateGetMonth()
        {
            int month = 12;
            Date date = new Date(10, month, 2019);

            Assert.AreEqual<int>(month, date.GetMonth());
        }

        [TestMethod]
        public void TestDateGetYear()
        {
            int year = 2019;
            Date date = new Date(10, 12, year);

            Assert.AreEqual<int>(year, date.GetYear());
        }

        [TestMethod]
        public void TestDateSetDaySuccessful()
        {
            Date date = new Date(10, 12, 2108);
            PrivateObject privateAccessor = new PrivateObject(date);
            int newDay = 29;
            date.SetDay(newDay);

            Assert.AreEqual<int>(newDay, (int)privateAccessor.GetField("day"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"Day must be between 1 and 31")]
        public void TestDateSetDayRaisesArgumentExceptionUpperBoundary()
        {
            Date date = new Date(10, 12, 2108);
            int invalidNewDay = 32;
            date.SetDay(invalidNewDay);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Day must be between 1 and 31")]
        public void TestDateSetDayRaisesArgumentExceptionLowerBoundary()
        {
            Date date = new Date(10, 12, 2108);
            int invalidNewDay = 0;
            date.SetDay(invalidNewDay);
        }

        [TestMethod]
        public void TestDateSetMonthSuccessful()
        {
            Date date = new Date(10, 12, 2108);
            PrivateObject privateAccessor = new PrivateObject(date);
            int newMonth = 6;
            date.SetMonth(newMonth);

            Assert.AreEqual<int>(newMonth, (int)privateAccessor.GetField("month"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Month must be between 1 and 12")]
        public void TestDateSetMonthRaisesArgumentExceptionUpperBoundary()
        {
            Date date = new Date(10, 12, 2108);
            int invalidNewMonth = 13;
            date.SetMonth(invalidNewMonth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Month must be between 1 and 12")]
        public void TestDateSetMonthRaisesArgumentExceptionLowerBoundary()
        {
            Date date = new Date(10, 12, 2108);
            int invalidNewMonth = 0;
            date.SetMonth(invalidNewMonth);
        }

        [TestMethod]
        public void TestDateSetYearSuccessful()
        {
            Date date = new Date(10, 12, 2108);
            PrivateObject privateAccessor = new PrivateObject(date);
            int newYear = 2019;
            date.SetYear(newYear);

            Assert.AreEqual<int>(newYear, (int)privateAccessor.GetField("year"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Year should be 4 digits long")]
        public void TestDateSetYearRaisesArgumentExceptionUpperBoundary()
        {
            Date date = new Date(10, 12, 2108);
            int invalidNewYear = 13321;
            date.SetMonth(invalidNewYear);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Year should be 4 digits long")]
        public void TestDateSetYearRaisesArgumentExceptionLowerBoundary()
        {
            Date date = new Date(10, 12, 2108);
            int invalidNewYear = 999;
            date.SetMonth(invalidNewYear);
        }

        [TestMethod]
        public void TestDateSetDate()
        {
            Date date = new Date(10, 12, 2108);
            PrivateObject privateAccessor = new PrivateObject(date);
            int newDay = 14;
            int newMonth = 6;
            int newYear = 2019;
            date.SetDate(newDay, newMonth, newYear);

            Assert.AreEqual<int>(newDay, (int)privateAccessor.GetField("day"));
            Assert.AreEqual<int>(newMonth, (int)privateAccessor.GetField("month"));
            Assert.AreEqual<int>(newYear, (int)privateAccessor.GetField("year"));
        }

        [TestMethod]
        public void TestDateGetFormatted()
        {
            Date date = new Date(10, 12, 2108);

            string expectedValue = "10/12/08";
            Assert.AreEqual<string>(expectedValue, date.GetFormatted());
        }

        [TestMethod]
        public void TestDateGetFormattedPlaces0BeforeSingleDigitDay()
        {
            Date date = new Date(9, 12, 2108);

            string expectedValue = "09/12/08";
            Assert.AreEqual<string>(expectedValue, date.GetFormatted());
        }

        [TestMethod]
        public void TestDateGetFormattedPlaces0BeforeSingleDigitMonth()
        {
            Date date = new Date(9, 3, 2108);

            string expectedValue = "09/03/08";
            Assert.AreEqual<string>(expectedValue, date.GetFormatted());
        }

        [TestMethod]
        public void TestDateGetDatabaseFormat()
        {
            Date date = new Date(9, 2, 1023);

            string expectedValue = "1023-02-09";
            Assert.AreEqual<string>(expectedValue, date.GetDatabaseFormat());
        }
    }
}
