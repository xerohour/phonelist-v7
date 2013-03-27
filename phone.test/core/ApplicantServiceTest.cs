using Microsoft.VisualStudio.TestTools.UnitTesting;
using phone.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.test.core
{
    [TestClass]
    public class ApplicantServiceTest
    {
        [TestInitialize]
        void addApplicant() {
            PhoneCodeModel hm = new PhoneCodeModel { phoneCodeDescription = "Home Phone", phoneCode = "AA", lastModifiedDate = DateTime.Now };
            PhoneCodeModel cm = new PhoneCodeModel { phoneCodeDescription = "Cell Phone", phoneCode = "BB", lastModifiedDate = DateTime.Now };

            List<PhoneModel> phones = new List<PhoneModel>();
            PhoneModel p1 = new PhoneModel();
            p1.createDate = DateTime.Now;
            p1.lastModifiedDate = DateTime.Now;
            p1.phoneNumber = 1231231233;
            p1.phoneCd = hm.phoneCode;
            phones.Add(p1);

            PhoneModel p2 = new PhoneModel();
            p2.createDate = DateTime.Now;
            p2.lastModifiedDate = DateTime.Now;
            p2.phoneNumber = 9999999999;
            p2.phoneCd = cm.phoneCode;
            phones.Add(p2);

            ApplicantModel a1 = new ApplicantModel();
            a1.applicantId = 1;
            a1.firstName = "Wes";
            a1.lastName = "Reisz";
            a1.middleInitial = "T";
            a1.ssn = "111111111";
            a1.suffix = ""; //this should default if nothing
            a1.phones = phones.ToArray<PhoneModel>();

            //IService service = new PhoneService();
            //service.addOrUpdatePhone(a1);
        }
    }
}
