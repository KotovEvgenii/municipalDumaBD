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
            LComissionPerson = new HashSet<LComissionPerson>();
        }

        public int FComissionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FMeeting> FMeetings { get; set; }
        public virtual ICollection<LComissionPerson> LComissionPerson { get; set; }
    }
}
