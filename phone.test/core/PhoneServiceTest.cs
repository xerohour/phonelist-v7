using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phone.core.Services;
using phone.core.Models;
using phone.dal.repositories;
using phone.dal;

namespace phone.test.core
{
    [TestClass]
    public class PhoneServiceTest
    {
        IPhoneService phoneService;
        IApplicantService applicantService;

        [TestInitialize]
        public void setupData() {
            //add and test phonecodes
            phoneService = new PhoneService();
            applicantService = new ApplicantService();

            ApplicantModel applicant = new ApplicantModel { applicantId = 1, firstName = "Wes", lastName = "Reisz", lastUpdated = DateTime.Now, middleInitial = "T", ssn = "123456789", suffix = "JR" };
            applicantService.addOrUpdateApplicant(applicant);
            
            PhoneCodeModel hm = new PhoneCodeModel { phoneCodeDescription = "Home Phone", phoneCode = "AA", lastModifiedDate = DateTime.Now };
            phoneService.addPhoneCd(hm);
            phoneService.addOrUpdatePhone(new PhoneModel {applicantId=applicant.applicantId,createDate=DateTime.Now, lastModifiedDate=DateTime.Now, phoneCd=hm.phoneCode,phoneNumber=1231231233});

        }
        [TestCleanup]
        public void removePhones() {
            PhoneRepo phoneRepo = new PhoneRepo();
            Phone phone = phoneRepo.query(p => p.APPLICANT_ID==1).First<Phone>();
            phoneService.removePhone(new PhoneModel { phoneId = phone.PHONE_ID});

            applicantService.removeApplicant(new ApplicantModel { applicantId = 1 });
            phoneService.removePhoneCD(new PhoneCodeModel { phoneCode = "AA" });
        }

        [TestMethod]
        public void simplePhoneServiceTest() {

            IPhoneService service = new PhoneService();
            ICollection<PhoneModel> phones = service.listPhonesByUser(1);
            bool hasPhones = false;
            foreach (PhoneModel phone in phones) {
                hasPhones = true;
                Assert.AreEqual(1, phone.applicantId);
                if (phone.phoneCd.ToUpper().Equals("HM")){
                    Assert.AreEqual(5028011112, phone.phoneNumber);
                }
            }
            Assert.AreEqual(true, hasPhones, "No Phones were returned from the service call.");
            
        }
        [TestMethod]
        public void simplePhoneServiceTestWithFake() {
            IPhoneService service = new PhoneServiceFake();
            ICollection<PhoneModel> phones = service.listPhones();
            Assert.AreEqual(3, phones.Count);
        }
        [TestMethod]
        public void simplePhoneServiceByUserTestWithFake()
        {
            IPhoneService service = new PhoneServiceFake();
            ICollection<PhoneModel> phones = service.listPhonesByUser(1);
            Assert.AreEqual(2, phones.Count);
        }
    }
}
