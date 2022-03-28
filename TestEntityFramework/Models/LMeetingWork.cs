using System;
using System.Collections.Generic;

#nullable disable

namespace TestEntityFramework.Models
{
    public partial class LMeetingWork
    {
        public int LMeetingWorkId { get; set; }
        public int FMeeting { get; set; }
        public int FPerson { get; set; }
        public bool IsAbsent { get; set; }

        public virtual FMeeting FMeetingNavigation { get; set; }
        public virtual FPerson FPersonNavigation { get; set; }
    }
}
