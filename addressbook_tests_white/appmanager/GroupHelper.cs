using System;
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

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public GroupHelper(ApplicationManager manager) :base(manager)
        {
        }


        public void CreateGroupIfItIsOne()
        {
            if (!GroupIfItIsOne())
            {
                GroupData CreatedNewGroup = new GroupData()
                {
                    Name = "CreatedNewGroup"
                };
                Create(CreatedNewGroup);
            }
            
        }

        private bool GroupIfItIsOne()
        {
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes.First();
            if (root.Nodes.Count == 1)
            {
                CloseGroupDialogue(dialogue);
                return false;
            }
            else
            {
                CloseGroupDialogue(dialogue);
                return true;
            }

        }

        public void Modify(GroupData newData)
        {
            Window dialogue = OpenGroupsDialogue();
            SelectGroup(0, dialogue);
            dialogue.Get<Button>("uxEditAddressButton").Click();

            TextBox textBox = (TextBox)dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newData.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupDialogue(dialogue);

        }

        public void Removal(int index)
        {
            Window dialogue = OpenGroupsDialogue();
            SelectGroup(index, dialogue);
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            dialogue.Get<Button>("uxOKAddressButton").Click();
            CloseGroupDialogue(dialogue);
        }


        public void Create(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupDialogue(dialogue);
        }



        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData() { Name = item.Text });
            }

            CloseGroupDialogue(dialogue);
            return list;
        }

        private void SelectGroup(int index, Window dialogue)
        {
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes.First();
            root.Nodes[0].DoubleClick();
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        private void CloseGroupDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

    }
}