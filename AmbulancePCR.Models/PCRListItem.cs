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
        public string PtLastName { get; set; }
        public string PrimaryCareProvider { get; set; }
        public DateTimeOffset IncidentDate { get; set; }
        public int IncidentNumber { get; set; }
    }
}
