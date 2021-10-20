using AmbulancePCR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class PCRListItem
    {
        public int IncidentNumber { get; set; }
        public Guid AuthorID { get; set; }
        public DateTimeOffset IncidentDate { get; set; }
        public string PtLastName { get; set; }
        //public AmbulanceCrewMember PrimaryCareProvider { get; set; }
    }
}
