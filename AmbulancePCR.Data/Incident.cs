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
            public double LoadMileage { get; set; }

            public class CrewMemberOne
        }
    }
}
