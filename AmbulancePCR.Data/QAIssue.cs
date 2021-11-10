using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class QAIssue
    {
        [Key]
        public int IssueID { get; set; }

        public int IncidentNumber { get; set; }
        [Required]
        public string Note { get; set; }

        public string PrimaryCareProvider { get; set; }

        public string PtLastName { get; set; }
        public PatientInformation PatientInformation { get; set; }
        public bool IsResolved { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        [Required]
        public string SupervisorName { get; set; }
        [Required]
        public Guid AuthorID { get; set; }
    }
}
