using System;
using System.Collections.Generic;

#nullable disable

namespace TestEntityFramework.Models
{
    public partial class FMeeting
    {
        public FMeeting()
        {
            LMeetingWorks = new HashSet<LMeetingWork>();
        }

        public int FMeetingId { get; set; }
        public int FComission { get; set; }
        public DateTime? DateTime { get; set; }
        public string Place { get; set; }

        public virtual FComission FComissionNavigation { get; set; }
        public virtual ICollection<LMeetingWork> LMeetingWorks { get; set; }
    }
}
