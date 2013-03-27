using System;
using System.Collections.Generic;
using phone.core.Models;

namespace phone.core.Services
{
    public interface IPhoneService
    {
        ICollection<PhoneModel> listPhones();
        ICollection<PhoneModel> listPhonesByUser(decimal applicantId);
        PhoneModel getPhoneById(decimal phoneId);
        ICollection<PhoneCodeModel> getPhoneCds();
        
        void addOrUpdatePhone(PhoneModel phone);
        void removePhone(PhoneModel phone);
        
        void addPhoneCd(PhoneCodeModel phoneCd);
        void removePhoneCD(PhoneCodeModel phoneCd);
    }
}
