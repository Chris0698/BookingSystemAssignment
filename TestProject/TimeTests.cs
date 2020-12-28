 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace TestProject
{
    [TestClass]
    public class TimeTests
    {
        [TestMethod]
        public void TestTimeConstructor()
        {
            Time time = new Time(12, 43);
            PrivateObject privateAccessor = new PrivateObject(time);

            Assert.AreEqual<int>(12, (int)privateAccessor.GetField("hour"));
            Assert.AreEqual<int>(43, (int)privateAccessor.GetField("minute"));
        }

        [TestMethod]
        public void TestTimeGetHour()
        {
            int hour = 12;
            Time time = new Time(hour, 43);

            Assert.AreEqual<int>(hour, time.GetHour());
        }

        [TestMethod]
        public void TestTimeGetMinute()
        {
            int minute = 43;
            Time time = new Time(12, minute);

            Assert.AreEqual<int>(minute, time.GetMinute());
        }

        [TestMethod]
        public void TestTimeSetHourSucceeds()
        {
            Time time = new Time(12, 43);
            PrivateObject privateAccessor = new PrivateObject(time);
            int newHour = 15;
            time.SetHour(newHour);

            Assert.AreEqual<int>(newHour, (int)privateAccessor.GetField("hour"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Hour must be between 0 and 23")]
        public void TestTimeSetHourRaisesArgumentExceptionUpperBound()
        {
            Time time = new Time(12, 43);
            int invalidNewHour = 24;
            time.SetHour(invalidNewHour);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Hour must be between 0 and 23")]
        public void TestTimeSetHourRaisesArgumentExceptionLowerBound()
        {
            Time time = new Time(12, 43);
            int invalidNewHour = -1;
            time.SetHour(invalidNewHour);
        }

        [TestMethod]
        public void TestTimeSetMinuteSucceeds()
        {
            Time time = new Time(12, 43);
            PrivateObject privateAccessor = new PrivateObject(time);
            int newMinute = 15;
            time.SetMinute(newMinute);

            Assert.AreEqual<int>(newMinute, (int)privateAccessor.GetField("minute"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Minute must be between 0 and 59")]
        public void TestTimeSetMinuteRaisesArgumentExceptionUpperBound()
        {
            Time time = new Time(12, 43);
            int invalidNewMinute = 60;
            time.SetMinute(invalidNewMinute);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Minute must be between 0 and 59")]
        public void TestTimeSetMinuteRaisesArgumentExceptionLowerBound()
        {
            Time time = new Time(12, 43);
            int invalidNewMinute = -1;
            time.SetMinute(invalidNewMinute);
        }

        [TestMethod]
        public void TestTimeSetTime()
        {
            Time time = new Time(12, 43);
            PrivateObject privateAccessor = new PrivateObject(time);

            int newHour = 23;
            int newMinute = 59;
            time.SetTime(newHour, newMinute);

            Assert.AreEqual<int>(newHour, (int)privateAccessor.GetField("hour"));
            Assert.AreEqual<int>(newMinute, (int)privateAccessor.GetField("minute"));
        }

        [TestMethod]
        public void TestTimeGetFormatted()
        {
            Time time = new Time(12, 43);
            string expectedValue = "12:43";
            Assert.AreEqual<string>(expectedValue, time.GetFormatted());
        }

        [TestMethod]
        public void TestTimeGetFormattedPlaces0BeforeSingleDigitHour()
        {
            Time time = new Time(9, 54);
            string expectedValue = "09:54";
            Assert.AreEqual<string>(expectedValue, time.GetFormatted());
        }

        [TestMethod]
        public void TestTimeGetFormattedPlaces0BeforeSingleDigitMinute()
        {
            Time time = new Time(9, 9);
            string expectedValue = "09:09";
            Assert.AreEqual<string>(expectedValue, time.GetFormatted());
        }
    }
}
