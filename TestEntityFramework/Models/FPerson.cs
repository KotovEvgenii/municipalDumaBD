using System;
using System.Collections.Generic;

#nullable disable

namespace TestEntityFramework.Models
{
    public partial class FPerson
    {
        public FPerson()
        {
            LComissionPeople = new HashSet<LComissionPerson>();
            LMeetingWorks = new HashSet<LMeetingWork>();
        }

        public int FPeople { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<LComissionPerson> LComissionPeople { get; set; }
        public virtual ICollection<LMeetingWork> LMeetingWorks { get; set; }
    }
}
