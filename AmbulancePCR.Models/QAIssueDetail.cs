using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class QAIssueDetail
    {
        [Display(Name = "Issue ID")]
        public int IssueID { get; set; }

        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        public string Note { get; set; }
        [Display(Name = "Primary Care Provider")]
        public string PrimaryCareProvider { get; set; }
        [Display(Name = "Patient Last Name")]
        public string PtLastName { get; set; }
        [Display(Name = "Resolved?")]
        public bool IsResolved { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }
    }
}
