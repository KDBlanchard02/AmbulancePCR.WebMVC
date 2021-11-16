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
        [Required]
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        [Required]
        public string Note { get; set; }
        [Required]
        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }
        [Display(Name = "Resolved?")]
        public bool IsResolved { get; set; }
        public string UserId { get; set; }
    }
}
