using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_white
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return (Lastname == other.Lastname) && (Firstname == other.Firstname);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compareFirstname = Firstname.CompareTo(other.Firstname);

            if (compareFirstname == 0 || string.IsNullOrWhiteSpace(Firstname))
            {
                if (string.IsNullOrWhiteSpace(Lastname)) return 0;
                return Lastname.CompareTo(other.Lastname);
            }
            return compareFirstname;
        }
    }
}
