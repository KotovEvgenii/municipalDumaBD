using System;
using System.Collections.Generic;

#nullable disable

namespace TestEntityFramework.Models
{
    public partial class LMeetingWork
    {
        public int LMeetingWork1 { get; set; }
        public int FMeeting { get; set; }
        public int FPeople { get; set; }
        public bool IsAbsent { get; set; }

        public virtual FMeeting FMeetingNavigation { get; set; }
        public virtual FPerson FPeopleNavigation { get; set; }
    }
}
