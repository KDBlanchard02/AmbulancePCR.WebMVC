using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class PCRDetail
    {
        [Display(Name = "PCR ID")]
        public int PatientCareReportId { get; set; }
        [Display(Name = "Date Created")]
        public DateTimeOffset DateCreated { get; set; }
        [Display(Name = "Date Modified")]
        public DateTimeOffset DateModified { get; set; }
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
        [DataType(DataType.Date)]
        public DateTime? IncidentDate { get; set; }

        [Display(Name = "Unit Notified")]
        public TimeSpan UnitNotified { get; set; }
        [Display(Name = "En Route")]
        public TimeSpan EnRoute { get; set; }
        [Display(Name = "On Scene")]
        public TimeSpan OnScene { get; set; }
        public TimeSpan Transporting { get; set; }
        public TimeSpan Destination { get; set; }
        [Display(Name = "In Service")]
        public TimeSpan InService { get; set; }

        public string PrimaryCareProvider { get; set; }
        public string AmbulanceDriver { get; set; }


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
        public string ReportingCrewMember { get; set; }

        public Incident Incident { get; set; }

        [Display(Name = "Patient First Name")]
        public string PtFirstName { get; set; }
        [Display(Name = "Patient Last Name")]
        public string PtLastName { get; set; }
        [Display(Name = "Patient Age")]
        public int PtAge { get; set; }
        [Display(Name = "Patient Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? PtDateOfBirth { get; set; }
        [Display(Name = "Patient Gender")]
        public string PtGender { get; set; }
        [Display(Name = "Patient Weight (kg)")]
        public double PtWeight { get; set; }
        [Display(Name = "Patient Address")]
        public string PatientAddress { get; set; }
        [Display(Name = "Patient Phone #")]
        public string PtPhoneNumber { get; set; }
        [Display(Name = "Patient SSN")]
        public string PtSSN { get; set; }
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

        [Display(Name = "Systolic Blood Pressure")]
        public int SystolicBloodPressure { get; set; }
        [Display(Name = "Diastolic Blood Pressure")]
        public int DiastolicBloodPressure { get; set; }
        [Display(Name = "Mean Pressure")]
        public int MeanPressure { get; set; }
        [Display(Name = "Heart Rate")]
        public int HeartRate { get; set; }
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
        [Display(Name = "GCS (Verbal)")]
        public string GCSVerbal { get; set; }
        [Display(Name = "GCS (Motor)")]
        public string GCSMotor { get; set; }
        [Display(Name = "GCS (Eyes)")]
        public string GCSEyes { get; set; }
        [Display(Name = "GCS (Total)")]
        public int GCSTotal { get; set; }
        [Display(Name = "Blood Glucose")]
        public int BloodGlucose { get; set; }
        [Display(Name = "Temperature (°F)")]
        public double Temperature { get; set; }
        [Display(Name = "Vital Signs (Time)")]
        public TimeSpan VitalSignsTime { get; set; }
    }
}
