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
    class TestGet
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

        // Test GETting contacts; passes if we get back all the contacts we put in
        [Test]
        public void GetContacts()
        {
            List<Contact> result = controller.Get().ToList();
            Assert.That(result.Any());
            Assert.That(contacts.Contacts.Count == result.Count);
            foreach (Contact c in result)
                Assert.That(contacts.Contacts.FindAll(x => x.Equals(c)).Any());
        }
    }
}
