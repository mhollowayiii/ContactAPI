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
    class TestPutId
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

        // Test PUTting one contact; passes if we get back the contact we updated
        [Test]
        public void PutContact()
        {
            Contact c = controller.Get().First();
            c.Name.First = "Changed";
            controller.Put(c.Id, c);
            Contact result = controller.Get(c.Id);
            Assert.That(result is not null);
            Assert.That(result.Equals(c));
        }
    }
}
