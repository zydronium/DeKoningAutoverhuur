using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeKoningAutoverhuur.Web.WebApplication.Common.Objects
{
    public class ClientObject
    {
        public string CompanyName;
        public string Vat;
        public NameObject Name;
        public string Gender;
        public AddressObject Address;
        public PhoneObject Phone;
        public PhoneObject Fax;
        public string Email;
        public DateTime Created;
        public DateTime Modified;
        public Boolean Deleted;
        public DateTime DeletedDate;
    }
}
