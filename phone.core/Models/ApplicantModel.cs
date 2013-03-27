using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.core.Models
{
    public class ApplicantModel
    {
        public decimal applicantId { get; set; }
        public String lastName { get; set; }
        public String firstName { get; set; }
        public String middleInitial { get; set; }
        public String suffix { get; set; }
        public String ssn { get; set; }
        public DateTime lastUpdated { get; set;}
        public PhoneModel[] phones { get; set; }
    }
}
