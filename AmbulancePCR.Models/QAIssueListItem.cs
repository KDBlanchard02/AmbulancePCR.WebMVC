using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class QAIssueListItem
    {
        [Display(Name = "Issue ID")]
        public int IssueID { get; set; }
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        [Display(Name = "Resolved?")]
        public bool IsResolved { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }
    }
}
