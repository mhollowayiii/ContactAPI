using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContactAPI.Controllers;
using ContactAPI.Models;

namespace ContactAPITest
{
    [TestFixture]
    public class TestPost
    {
        DummyContacts contacts;
        ContactController controller;

        // Creating four contacts for testing
        [SetUp]
        public void Setup()
        {
            contacts = new DummyContacts();
            controller = new ContactController();
        }

        // Simply deleting all added contacts
        [TearDown]
        public void TearDown()
        {
            foreach (Contact c in controller.Get())
                controller.Delete(c.Id);
        }

        // Test adding contacts; passes as long as no exceptions occur
        [Test]
        public void PostContacts()
        {
            foreach (Contact c in contacts.Contacts)
                Assert.DoesNotThrow(() => controller.Post(c));
        }
    }
}