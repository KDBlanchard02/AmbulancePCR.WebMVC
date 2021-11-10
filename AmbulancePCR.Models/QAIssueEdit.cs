using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class QAIssueEdit
    {
        public int MyProperty { get; set; }
        public string Note { get; set; }
        [Display(Name = "Resolved?")]
        public bool IsResolved { get; set; }
    }
}
