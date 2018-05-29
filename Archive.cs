using System;

namespace Project_Part1
{
    internal class Archive : IComparable<Archive>
    {
        public String Name { get; set; }
        public DateTime ArchivedDate { get; set; }
        public int IdentificationNumber { get; set; }

        public int CompareTo(Archive other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return this.IdentificationNumber.CompareTo(other.IdentificationNumber);
            }
        }
    }
}
