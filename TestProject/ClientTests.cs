 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;

namespace TestProject
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void TestClientConstructor()
        {
            Client client = new Client("ID", "The Company Name", "Company Street");
            Assert.AreEqual<string>("ID", client.ID);
            Assert.AreEqual<string>("The Company Name", client.companyName);
            Assert.AreEqual<string>("Company Street", client.companyAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Client ID is null")]
        public void TestClientConstructorRaisesArgumentExceptionOnNullID()
        {
            Client client = new Client(null, "Company Name", "Company Street");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Company name is null")]
        public void TestClientConstructorRaisesArgumentExceptionOnNullCompanyName()
        {
            Client client = new Client("Valid ID", null, "Company Street");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Company address is null")]
        public void TestClientConstructorRaisesArgumentExceptionOnNullCompanyAddress()
        {
            Client client = new Client("Valid ID", "Company Name", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Client ID is null")]
        public void TestClientConstructorRaisesArgumentExceptionOnEmptyID()
        {
            Client client = new Client("", "Company Name", "Company Street");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Company name is null")]
        public void TestClientConstructorRaisesArgumentExceptionOnEmptyCompanyName()
        {
            Client client = new Client("Valid ID", "", "Company Street");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Company address is null")]
        public void TestClientConstructorRaisesArgumentExceptionOnEmptyCompanyAddress()
        {
            Client client = new Client("Valid ID", "Company Name", "");
        }

        [TestMethod]
        public void TestGetIDReturnsValueFromConstructor()
        {
            string ID = "ID123";
            Client client = new Client(ID, "Valid Name", "Valid Address");
            Assert.AreEqual<string>(ID, client.GetID());
        }

        [TestMethod]
        public void TestToStringReturnsNameOfCompanyFromConstructor()
        {
            string companyName = "A Valid Company Name";
            Client client = new Client("ID", companyName, "Valid Address");
            Assert.AreEqual<string>(companyName, client.ToString());
        }

        [TestMethod]
        public void TestGetCompanyAddressReturnsValueFromConstructor()
        {
            string companyAddress = "CompanyAddress";
            Client client = new Client("ID", "CompanyName", companyAddress);
            Assert.AreEqual<string>(companyAddress, client.GetCompanyAddress());
        }
    }
}
