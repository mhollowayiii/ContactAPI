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
    class TestGetId
    {
        DummyContacts contacts;
        ContactController controller;

        // Creating four contacts for testing
        [SetUp]
        public void Setup()
        {
            contacts = new DummyContacts();
            controller = new ContactController();
            foreach (Contact c in contacts.Contacts)
                controller.Post(c);
        }

        // Simply deleting all added contacts
        [TearDown]
        public void TearDown()
        {
            foreach (Contact c in controller.Get())
                controller.Delete(c.Id);
        }

        // Test GETting one contact; passes if we're able to get the first contact by its id
        [Test]
        public void GetContactById()
        {
            Contact c = controller.Get().First();
            Assert.That(controller.Get(c.Id).Equals(c));
        }
    }
}
