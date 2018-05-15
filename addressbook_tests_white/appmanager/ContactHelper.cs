using System.Collections.Generic;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;
using System.Linq;
using System;
using TestStack.White.UIItems.TableItems;

namespace addressbook_tests_white
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Create(ContactData newContact)
        {
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            Window dialogue = manager.MainWindow.ModalWindow("Contact Editor");
            dialogue.Get<TextBox>("ueFirstNameAddressTextBox").Enter(newContact.Firstname);
            dialogue.Get<Button>("uxSaveAddressButton").Click();

        }

        public void Remove(int index)
        {
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");
            table.Rows[index].Click();
            manager.MainWindow.Get<Button>("uxDeleteAddressButton").Click();
            Window dialogue = manager.MainWindow.ModalWindow("Question");
            var p = dialogue.Get<Panel>("uxButtonsFlowLayoutPanel");

            p.Items[1].DoubleClick();

        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> list = new List<ContactData>();
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");

            foreach (TableRow row in table.Rows)
            {

                list.Add(new ContactData()
                {
                    Firstname = row.Cells[0].Value.ToString(),
                    Lastname = row.Cells[1].Value.ToString()
                });

            }

            return list;
        }

        public void CreateContactIfNotExist()
        {
            if (!ContactIfNotExist())
            {
                ContactData newContact = new ContactData()
                {
                    Firstname = "newContact",
                    Lastname = "(не определено)",
                };
                Create(newContact);
            }
        }

        private bool ContactIfNotExist()
        {
            Table table = manager.MainWindow.Get<Table>("uxAddressGrid");
            if (table.Rows.Count == 0)
                return false;
            else return true;
        }
    }
}
