using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class Medication
    {
        [Required]
        [ForeignKey("Incident")]
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
    }
}
