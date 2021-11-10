using AmbulancePCR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class PCRListItem
    {
        [Display(Name = "PCR ID")]
        public int PatientCareReportId { get; set; }
        [Display(Name = "Patient Last Name")]
        public string PtLastName { get; set; }
        [Display(Name = "Primary Care Provider")]
        public string PrimaryCareProvider { get; set; }
        [Display(Name = "Incident Date")]
        [DataType(DataType.Date)]
        public DateTime? IncidentDate { get; set; }
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }

    }
}
