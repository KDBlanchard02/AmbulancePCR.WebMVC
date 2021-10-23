using AmbulancePCR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class QAIssueCreate
    {
        [ForeignKey("Incident")]
        public int IncidentNumber { get; set; }
        public Incident Incident { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        public ApplicationUser PrimaryCareProvider { get; set; }
        [Required]
        public string PtLastName { get; set; }
        public PatientInformation PatientInformation { get; set; }
        public bool IsResolved { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
