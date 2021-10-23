using AmbulancePCR.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Models
{
    public class IncidentCreate
    {
        public Guid AuthorID { get; set; }
        [Required]
        [Key]
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        [Required]
        [Display(Name = "Disposition/Outcome")]
        public string Disposition { get; set; }
        [Required]
        [Display(Name = "Scene Address")]
        public string SceneAddress { get; set; }
        [Required]
        [Display(Name = "CMS Level")]
        public string CmsLevel { get; set; }
        [Required]
        [Display(Name = "Vehicle #")]
        public int VehicleNumber { get; set; }
        [Required]
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

        [Required]
        public ApplicationUser PrimaryCareProvider { get; set; }
        [Required]
        public ApplicationUser AmbulanceDriver { get; set; }


        [Required]
        [Display(Name = "Load Mileage")]
        public double LoadMileage { get; set; }


        [Required]
        [Display(Name = "Destination Address")]
        public string DestinationAddress { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Pt Position")]
        public string PtPosition { get; set; }



        [Required]
        [Display(Name = "Primary Symptom")]
        public string PrimarySymptom { get; set; }
        [Required]
        [Display(Name = "Primary Impression")]
        public string PrimaryImpression { get; set; }
        [Required]
        [Display(Name = "Secondary Impression")]
        public string SecondaryImpression { get; set; }
        [Required]
        [Display(Name = "Alc/Drug Use")]
        public string AlcDrugUse { get; set; }


        [Required]
        [Display(Name = "PCR Narrative")]
        public string PCRNarrative { get; set; }
        [Required]
        [Display(Name = "Reporting Crew Member")]
        public ApplicationUser ReportingCrewMember { get; set; }
    }
}
