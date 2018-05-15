using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            ContactData newContact = new ContactData()
            {
                Firstname = "test",
                Lastname = "(не определено)",
            };

            app.Contacts.Create(newContact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(newContact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
