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
        public Guid AuthorID { get; set; }
        public string PtLastName { get; set; }
        public ApplicationUser PrimaryCareProvider { get; set; }
        public DateTimeOffset IncidentDate { get; set; }
        public int IncidentNumber { get; set; }
    }
}
