using AmbulancePCR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class IncidentListItem
    {
        [ForeignKey("Incident")]
        public int IncidentNumber { get; set; }
        public Guid AuthorID { get; set; }
        public DateTimeOffset IncidentDate { get; set; }
        public string PtLastName { get; set; }
        public ApplicationUser PrimaryCareProvider { get; set; }
    }
}
