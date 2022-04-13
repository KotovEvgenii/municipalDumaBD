using System;
using System.Collections.Generic;

#nullable disable

namespace TestEntityFramework.Models
{
    public partial class LComissionPerson
    {
        public int LComissionPersonId { get; set; }
        public int FComission { get; set; }
        public int FPerson { get; set; }
        public int? Stat { get; set; }
        public int? StatMain { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }

        public virtual FComission FComissionNavigation { get; set; }
        public virtual FPerson FPersonNavigation { get; set; }
    }
}
