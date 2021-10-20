using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class PatientCareReport
    {
        public class Incident
        {
            [Required]
            [Display(Name = "Incident #")]
            public int IncidentNumber { get; set; }
            [Required]
            [Display(Name = "Disposition/Outcome")]
            public string Disposition { get; set; }
            [Required]
            [Display(Name = "Scene Address")]
            public CivicAddress SceneAddress { get; set; }
            [Required]
            [Display(Name = "CMS Level")]
            public string CmsLevel { get; set; }
            [Required]
            [Display(Name = "Vehicle #")]
            public int VehicleNumber { get; set; }
            [Required]
            [Display(Name = "Incident Date")]
            public DateTimeOffset IncidentDate { get; set; }

            public class Timeline
            {
                [Required]
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
                public DateTimeOffset InService { get; set; }
            }

            [Required]
            [Display(Name = "Load Mileage")]
            public double LoadMileage { get; set; }

            public class CrewMemberOne
            {
                [Required]
                public int PSID { get; set; }
                [Required]
                [Display(Name = "First Name")]
                public string FirstName { get; set; }
                [Required]
                [Display(Name = "Last Name")]
                public string LastName { get; set; }
                [Required]
                public string Role { get; set; }
            }

            public class CrewMemberTwo
            {
                [Required]
                public int PSID { get; set; }
                [Required]
                [Display(Name = "First Name")]
                public string FirstName { get; set; }
                [Required]
                [Display(Name = "Last Name")]
                public string LastName { get; set; }
                [Required]
                public string Role { get; set; }
            }
        }

        public class PatientInformation
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            [Required]
            public int Age { get; set; }
            [Required]
            [Display(Name = "Date Of Birth")]
            public DateTime DateOfBirth { get; set; }
            [Required]
            public string Gender { get; set; }
            [Display(Name = "Weight (kg)")]
            public double Weight { get; set; }
            [Required]
            [Display(Name = "Patient Address")]
            public CivicAddress PatientAddress { get; set; }
            [Display(Name = "Patient Phone #")]
            public PhoneAttribute PhoneNumber { get; set; }
            [MaxLength(9)]
            public int SSN { get; set; }
            [Required]
            public string History { get; set; }
            [Display(Name = "Advance Directives")]
            public string AdvanceDirectives { get; set; }
            [Display(Name = "Allergies (Meds)")]
            public string AllergiesMeds { get; set; }
            [Display(Name = "Allergies (Other)")]
            public string AllergiesOther { get; set; }
            public string Medications { get; set; }
        }

        public class Narrative
        {
            [Required]
            [Display(Name = "PCR Narrative")]
            public string PCRNarrative { get; set; }
            [Required]
            [Display(Name = "Reporting Crew Member")]
            public string ReportingCrewMember { get; set; }
        }

        public class Timeline : Incident.Timeline
        {
            [Display(Name = "Vital Signs (Time)")]
            public DateTimeOffset VitalSignsTime { get; set; }
            public class Procedure { }
            public class Medication { }
        }

        public class Destination
        {
            [Required]
            [Display(Name = "Destination Address")]
            public CivicAddress DestinationAddress { get; set; }
            [Required]
            public string Reason { get; set; }
            [Required]
            public string Type { get; set; }
            [Required]
            [Display(Name = "Pt Position")]
            public string PtPosition { get; set; }
        }
        
        public class Vitals
        {
            [Required]
            [Display(Name = "Systolic Blood Pressure")]
            public int SystolicBloodPressure { get; set; }
            [Required]
            [Display(Name = "Diastolic Blood Pressure")]
            public int DiastolicBloodPressure { get; set; }
            [Display(Name = "Mean Pressure")]
            public int MeanPressure { get; }
            [Required]
            [Display(Name = "Heart Rate")]
            public int HeartRate { get; set; }
            [Required]
            [Display(Name = "Respiratory Rate")]
            public int RespiratoryRate { get; set; }
            [Display(Name = "Resp Effort")]
            public string RespEffort { get; set; }
            public string Rhythm { get; set; }
            [Display(Name = "BP Method")]
            public string BPMethod { get; set; }
            [Display(Name = "HR Type")]
            public string HRType { get; set; }
            [MaxLength(100)]
            [Display(Name = "Oximetry (%)")]
            public int Oximetry { get; set; }
            [Required]
            [Display(Name = "GCS (Verbal)")]
            public int GCSVerbal { get; set; }
            [Required]
            [Display(Name = "GCS (Motor)")]
            public int GCSMotor { get; set; }
            [Required]
            [Display(Name = "GCS (Eyes)")]
            public int GCSEyes { get; set; }
            [Display(Name = "GCS (Total)")]
            public int GCSTotal { get; }
            [Display(Name = "Blood Glucose")]
            public int BloodGlucose { get; set; }
            [Display(Name = "Temperature (°F)")]
            public double Temperature { get; set; }
            [Required]
            public DateTime Date { get; set; }
            [Required]
            [Display(Name = "Vital Signs (Time)")]
            public DateTimeOffset VitalSignsTime { get; set; }
        }

        public class Assessment
        {
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
        }
    }
}
