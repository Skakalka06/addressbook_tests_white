using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.CreateContactIfNotExist();
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
