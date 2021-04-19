using System;
using System.Collections.Generic;

#nullable disable

namespace MMTApplication.Models
{
    public partial class Camp
    {
        public Camp()
        {
            Talks = new HashSet<Talk>();
        }

        public int CampId { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        public int? LocationId { get; set; }
        public DateTime EventDate { get; set; }
        public int Length { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Talk> Talks { get; set; }
    }
}
