///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace TestProject
{
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void CollectionGetSizeReturns0OnEmptyList()
        {
            Collection<string> testCollection = new Collection<string>();

            Assert.AreEqual<int>(0, testCollection.GetSize());
        }

        [TestMethod]
        public void CollectionGetSizeReturnsSizeOfList()
        {
            Collection<string> testCollection = new Collection<string>();
            testCollection.Add("Test1");
            Assert.AreEqual<int>(1, testCollection.GetSize());

            testCollection.Add("Test2");
            Assert.AreEqual<int>(2, testCollection.GetSize());

            testCollection.Add("Test3");
            Assert.AreEqual<int>(3, testCollection.GetSize());
        }

        [TestMethod]
        public void CollectionGetStringsReturnsEmptyStringListOnEmpty()
        {
            Collection<int> testCollection = new Collection<int>();

            Assert.AreEqual<int>(0, testCollection.GetStrings().Count);
            Assert.IsInstanceOfType(testCollection.GetStrings(), typeof(List<string>));
        }

        [TestMethod]
        public void CollectionGetStringsReturnsStringList()
        {
            Collection<int> testCollection = new Collection<int>{ 1, 2, 3 };

            Assert.AreEqual<int>(3, testCollection.GetStrings().Count);
            Assert.IsTrue(testCollection.GetStrings().Contains("1"));
            Assert.IsTrue(testCollection.GetStrings().Contains("2"));
            Assert.IsTrue(testCollection.GetStrings().Contains("3"));
            Assert.IsInstanceOfType(testCollection.GetStrings(), typeof(List<string>));
        }
    }
}
