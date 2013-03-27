using phone.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.core.Services
{
    public interface IApplicantService
    {
        ApplicantModel addOrUpdateApplicant(ApplicantModel applicant);
        void removeApplicant(ApplicantModel applicant);
    }
}
