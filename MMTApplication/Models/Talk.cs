using System;
using System.Collections.Generic;

#nullable disable

namespace MMTApplication.Models
{
    public partial class Talk
    {
        public int TalkId { get; set; }
        public int? CampId { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public int Level { get; set; }
        public int? SpeakerId { get; set; }

        public virtual Camp Camp { get; set; }
        public virtual Speaker Speaker { get; set; }
    }
}
