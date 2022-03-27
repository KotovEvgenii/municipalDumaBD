using System;
using System.Collections.Generic;

#nullable disable

namespace TestEntityFramework.Models
{
    public partial class FComission
    {
        public FComission()
        {
            FMeetings = new HashSet<FMeeting>();
            LComissionPeople = new HashSet<LComissionPerson>();
        }

        public int FComission1 { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FMeeting> FMeetings { get; set; }
        public virtual ICollection<LComissionPerson> LComissionPeople { get; set; }
    }
}
