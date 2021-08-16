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
    class TestDelete
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

        // Test DELETEing one contact; passes if a GET does not return the deleted contact
        [Test]
        public void DeleteContact()
        {
            Contact c = controller.Get().First();
            controller.Delete(c.Id);
            List<Contact> contacts = controller.Get().ToList();
            Assert.That(!contacts.FindAll(x => x.Equals(c)).Any());
        }
    }
}
