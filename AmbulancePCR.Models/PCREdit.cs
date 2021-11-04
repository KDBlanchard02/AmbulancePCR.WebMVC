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
    public class PCREdit
    {
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

        [Required]
        [Display(Name = "Patient First Name")]
        public string PtFirstName { get; set; }
        [Required]
        [Display(Name = "Patient Last Name")]
        public string PtLastName { get; set; }
        [Required]
        [Display(Name = "Patient Age")]
        public int PtAge { get; set; }
        [Required]
        [Display(Name = "Patient Date Of Birth")]
        public DateTime PtDateOfBirth { get; set; }
        [Required]
        [Display(Name = "Patient Gender")]
        public string PtGender { get; set; }
        [Display(Name = "Patient Weight (kg)")]
        public double PtWeight { get; set; }
        [Required]
        [Display(Name = "Patient Address")]
        public string PatientAddress { get; set; }
        [Display(Name = "Patient Phone #")]
        public int PtPhoneNumber { get; set; }
        [Display(Name = "Patient SSN")]
        public int PtSSN { get; set; }
        [Required]
        [Display(Name = "Patient Medical History")]
        public string PtHistory { get; set; }
        [Display(Name = "Patient Advance Directives")]
        public string PtAdvanceDirectives { get; set; }
        [Display(Name = "Patient Allergies (Meds)")]
        public string PtAllergiesMeds { get; set; }
        [Display(Name = "Patient Allergies (Other)")]
        public string PtAllergiesOther { get; set; }
        [Display(Name = "Patient Medications")]
        public string PtMedications { get; set; }


        [Required]
        [Display(Name = "Systolic Blood Pressure")]
        public int SystolicBloodPressure { get; set; }
        [Required]
        [Display(Name = "Diastolic Blood Pressure")]
        public int DiastolicBloodPressure { get; set; }
        [Display(Name = "Mean Pressure")]
        public int MeanPressure { get; set; }
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
        public int GCSTotal { get; set; }
        [Display(Name = "Blood Glucose")]
        public int BloodGlucose { get; set; }
        [Display(Name = "Temperature (°F)")]
        public double Temperature { get; set; }
        [Required]
        [Display(Name = "Vital Signs (Time)")]
        public DateTimeOffset VitalSignsTime { get; set; }
    }
}
