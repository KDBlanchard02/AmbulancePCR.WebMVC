using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmbulancePCR.Data
{
    public class AmbulanceCrewMember
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public int PSID { get; set; }
        public string Certification { get; set; }
        
    }
}
