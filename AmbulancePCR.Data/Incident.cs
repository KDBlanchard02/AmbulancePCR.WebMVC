using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class Incident
    {
        [Key]
        public int PatientCareReportId { get; set; }
        [Required]
        public Guid AuthorID { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset DateModified { get; set; }
        [Required]
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        [Required]
        [Display(Name = "Disposition/Outcome")]
        public string Disposition { get; set; }

        /*public static class DispositionSelect
        {
            public static String Emergency { get { return "Transported (Emergency)"; } }
            public static String NonEmergent { get { return "Transported (Non-Emergent)"; } }
            public static String Refusal { get { return "Patient Refusal"; } }
            public static String Cancelled { get { return "Cancelled"; } }
            public static String NoTreatmentRequired { get { return "No Treatment Required"; } }
            public static String NoPatientIdentified { get { return "No Patient Identified"; } }
        }*/

        [Required]
        [Display(Name = "Scene Address")]
        public string SceneAddress { get; set; }
        [Required]
        [Display(Name = "CMS Level")]
        public string CmsLevel { get; set; }

       /* public static class CmsLevels
        {
            public static String BLS { get { return "Basic Life Support (BLS)"; } }
            public static String BLSEmergency { get { return "Basic Life Support (BLS) - Emergency"; } }
            public static String ALSOne { get { return "Advanced Life Support, Level 1 (ALS1)"; } }
            public static String ALSOneEmergency { get { return "Advanced Life Support, Level 1 (ALS1) - Emergency"; } }
            public static String ALSTwo { get { return "Advanced Life Support, Level 2 (ALS2)"; } }
            public static String SCT { get { return "Specialty Care Transport (SCT)"; } }
            public static String PI { get { return "Paramedic Intercept (PI)"; } }
        }*/

        [Required]
        [Display(Name = "Vehicle #")]
        public int VehicleNumber { get; set; }
        [Required]
        [Display(Name = "Incident Date")]
        [DataType(DataType.Date)]
        public DateTime? IncidentDate { get; set; }


        [Required]
        [Display(Name = "Unit Notified")]
        public TimeSpan UnitNotified { get; set; }
        [Required]
        [Display(Name = "En Route")]
        public TimeSpan EnRoute { get; set; }
        [Required]
        [Display(Name = "On Scene")]
        public TimeSpan OnScene { get; set; }
        [Required]
        public TimeSpan Transporting { get; set; }
        [Required]
        public TimeSpan Destination { get; set; }
        [Required]
        [Display(Name = "In Service")]
        public TimeSpan InService { get; set; }


        [Required]
        public string PrimaryCareProvider { get; set; }
        [Required]
        public string AmbulanceDriver { get; set; }


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

        /*public static class PatientPositions
        {
            public static String Supine { get { return "Supine"; } }
            public static String Prone { get { return "Prone"; } }
            public static String RightLateral { get { return "Right Lateral Recumbent"; } }
            public static String LeftLateral { get { return "Left Lateral Recumbent"; } }
            public static String Fowlers { get { return "Fowler's"; } }
            public static String SemiFowlers { get { return "Semi-Fowler's"; } }
            public static String Trendelenberg { get { return "Trendelenberg"; } }
            public static String Sitting { get { return "Sitting"; } }
        }*/

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
        public string ReportingCrewMember { get; set; }


    }
}
