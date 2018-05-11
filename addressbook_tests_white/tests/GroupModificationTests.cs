using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newData = new GroupData()
            {
                Name = "newData"
            };

            app.Groups.Modify(newData);
            GroupData oldData = oldGroups[0];

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldData.Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
