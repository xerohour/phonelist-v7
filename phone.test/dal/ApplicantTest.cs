using Microsoft.VisualStudio.TestTools.UnitTesting;
using phone.dal;
using phone.dal.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.test.dal
{
    [TestClass]
    public class ApplicantTest
    {
        ApplicantRepo appRepo;
        Applicant a1;
        [TestInitialize]
        public void setup() {
            appRepo = new ApplicantRepo();
            a1 = new Applicant{
                APPLICANT_ID = 1,
                FIRST_NAME_TX = "Wes",
                LAST_NAME_TX = "Reisz",
                MIDDLE_INITIAL_TX = "T",
                MOD_DT = DateTime.Now,
                SSN_TX = "400121234",
                SUFFIX_TX = ""
            };
            appRepo.add(a1);

            appRepo.add(new Applicant{
                    APPLICANT_ID = 2,
                    FIRST_NAME_TX = "Justin",
                    LAST_NAME_TX = "Reisz",
                    MIDDLE_INITIAL_TX = "T",
                    MOD_DT = DateTime.Now,
                    SSN_TX = "400121235",
                    SUFFIX_TX = ""
                }
            );
        }
        [TestMethod]
        public void applicantGetById() { 
            Applicant a2 = appRepo.getById(new Applicant{APPLICANT_ID=1});
            Assert.AreEqual(a1.FIRST_NAME_TX, a2.FIRST_NAME_TX);
            Assert.AreEqual(a1.SSN_TX, a2.SSN_TX);
        }

        [TestMethod]
        public void applicantUpdate()
        {
            Applicant a2 = appRepo.getById(new Applicant { APPLICANT_ID = 1 });
            a2.SSN_TX = "123456789";
            appRepo.update(a2);
            Applicant a3 = appRepo.getById(new Applicant { APPLICANT_ID = 1 });
            Assert.AreEqual(a2.SSN_TX, a3.SSN_TX);
        }
        [TestMethod]
        public void applicantGetAll()
        {
            Applicant[] applicants = appRepo.getAll();
            Assert.AreEqual(true, applicants.Length >= 2);

            appRepo.add(new Applicant
            {
                APPLICANT_ID = 3,
                FIRST_NAME_TX = "Leanne",
                LAST_NAME_TX = "Reisz",
                MIDDLE_INITIAL_TX = "T",
                MOD_DT = DateTime.Now,
                SSN_TX = "11111111",
                SUFFIX_TX = ""
            }
            );
            Applicant[] applicants2 = appRepo.getAll();
            Assert.AreEqual(applicants.Length +1, applicants2.Length);
        }
        [TestCleanup]
        public void cleanup() {
            IQueryable<Applicant> applicants = appRepo.query(a => a.APPLICANT_ID == 1 || a.APPLICANT_ID == 2 || a.APPLICANT_ID == 3);
            foreach (Applicant applicant in applicants.ToList<Applicant>()) {
                appRepo.remove(applicant);
            }
        }
    }
}
