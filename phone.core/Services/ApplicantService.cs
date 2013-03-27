using phone.dal;
using phone.dal.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.core.Services
{
    public class ApplicantService : IApplicantService
    {
        public Models.ApplicantModel addOrUpdateApplicant(Models.ApplicantModel applicant)
        {
            Applicant a = new Applicant
            {
                APPLICANT_ID = applicant.applicantId,
                FIRST_NAME_TX = applicant.firstName,
                LAST_NAME_TX = applicant.lastName,
                MIDDLE_INITIAL_TX = applicant.middleInitial,
                MOD_DT = DateTime.Now,
                SSN_TX = applicant.ssn,
                SUFFIX_TX = applicant.suffix
            };
            ApplicantRepo appRepo = new ApplicantRepo();
            if (appRepo.getById(a) != null)
            {
                appRepo.update(a);
            }
            else {
                appRepo.add(a);
            }
            return applicant;
        }

        public void removeApplicant(Models.ApplicantModel applicant)
        {
            ApplicantRepo appRepo = new ApplicantRepo();
            appRepo.remove(appRepo.getById(new Applicant { APPLICANT_ID = applicant.applicantId }));
        }
    }
}
