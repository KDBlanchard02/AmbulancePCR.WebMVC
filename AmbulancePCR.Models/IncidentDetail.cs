using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class IncidentDetail
    {
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        [Display(Name = "Disposition/Outcome")]
        public string Disposition { get; set; }
        [Display(Name = "Scene Address")]
        public string SceneAddress { get; set; }
        [Display(Name = "CMS Level")]
        public string CmsLevel { get; set; }
        [Display(Name = "Vehicle #")]
        public int VehicleNumber { get; set; }
        [Display(Name = "Incident Date")]
        public DateTimeOffset IncidentDate { get; set; }

        public ICollection<IncidentStatus> Statuses { get; set; }

        /*[Required]
        [Display(Name = "Unit Notified")]
        public DateTimeOffset UnitNotified { get; set; }
        [Required]
        [Display(Name = "En Route")]
        public DateTimeOffset EnRoute { get; set; }
        [Required]
        [Display(Name = "On Scene")]
        public DateTimeOffset OnScene { get; set; }
        [Required]
        public DateTimeOffset Transporting { get; set; }
        [Required]
        public DateTimeOffset Destination { get; set; }
        [Required]
        [Display(Name = "In Service")]
        public DateTimeOffset InService { get; set; }*/

        public enum IncidentStatus
        {
            UnitNotfied = 1,
            EnRoute = 2,
            OnScene = 3,
            Transporting = 4,
            Destination = 5,
            InService = 6
        }

        public ApplicationUser PrimaryCareProvider { get; set; }
        public ApplicationUser AmbulanceDriver { get; set; }


        [Display(Name = "Load Mileage")]
        public double LoadMileage { get; set; }


        [Display(Name = "Destination Address")]
        public string DestinationAddress { get; set; }
        public string Reason { get; set; }
        public string Type { get; set; }
        [Display(Name = "Pt Position")]
        public string PtPosition { get; set; }



        [Display(Name = "Primary Symptom")]
        public string PrimarySymptom { get; set; }
        [Display(Name = "Primary Impression")]
        public string PrimaryImpression { get; set; }
        [Display(Name = "Secondary Impression")]
        public string SecondaryImpression { get; set; }
        [Display(Name = "Alc/Drug Use")]
        public string AlcDrugUse { get; set; }


        [Display(Name = "PCR Narrative")]
        public string PCRNarrative { get; set; }
        [Display(Name = "Reporting Crew Member")]
        public ApplicationUser ReportingCrewMember { get; set; }
    }
}
