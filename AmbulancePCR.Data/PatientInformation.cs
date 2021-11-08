using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class PatientInformation
    {
        [Key]
        [Display(Name = "Patient ID")]
        public int PatientID { get; set; }

        [Required]
        [ForeignKey("Incident")]
        [Display(Name = "Incident #")]
        public int IncidentNumber { get; set; }
        public Incident Incident { get; set; }

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
        [DataType(DataType.PhoneNumber)]
        public string PtPhoneNumber { get; set; }
        [Display(Name = "Patient SSN")]
        public string PtSSN { get; set; }
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
    }
}
