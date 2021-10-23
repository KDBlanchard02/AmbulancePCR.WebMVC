using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class Vitals
    {
        [Required]
        [ForeignKey("Incident")]
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        public Incident Incident { get; set; }

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
