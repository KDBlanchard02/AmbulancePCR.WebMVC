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
        [Key]
        public int VitalsId { get; set; }

        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        [Required]
        [Display(Name = "Systolic Blood Pressure")]
        public int SystolicBloodPressure { get; set; }
        [Required]
        [Display(Name = "Diastolic Blood Pressure")]
        public int DiastolicBloodPressure { get; set; }
        [Display(Name = "Mean Pressure")]
        public int MeanPressure 
        {
            get
            {
                int mean = (DiastolicBloodPressure + SystolicBloodPressure) / 2;
                return mean;
            }
        }
        [Required]
        [Display(Name = "Heart Rate")]
        public int HeartRate { get; set; }
        [Required]
        [Range(1, 80)]
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
        [Range(1, 100)]
        public int Oximetry { get; set; }
        [Required]
        [Display(Name = "GCS (Verbal)")]
        [Range(1, 5)]
        public string GCSVerbal { get; set; }
        [Required]
        [Display(Name = "GCS (Motor)")]
        [Range(1, 6)]
        public string GCSMotor { get; set; }
        [Required]
        [Display(Name = "GCS (Eyes)")]
        [Range(1, 4)]
        public string GCSEyes { get; set; }
        [Display(Name = "GCS (Total)")]
        public int GCSTotal 
        { 
            get
            {
                int total = (Int32.Parse(GCSEyes) + Int32.Parse(GCSMotor) + Int32.Parse(GCSVerbal));
                return total;
            }
        }
        [Display(Name = "Blood Glucose")]
        public int BloodGlucose { get; set; }
        [Display(Name = "Temperature (°F)")]
        public double Temperature { get; set; }
        [Required]
        [Display(Name = "Vital Signs (Time)")]
        public TimeSpan VitalSignsTime { get; set; }
    }
}
