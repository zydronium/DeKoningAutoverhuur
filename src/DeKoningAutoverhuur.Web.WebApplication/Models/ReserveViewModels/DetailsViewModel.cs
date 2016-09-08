using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeKoningAutoverhuur.Web.WebApplication.Models.ReserveViewModels
{
    public class DetailsViewModel
    {
        public string companyname { get; set; }
        public string vat { get; set; }
        public string name_initials { get; set; }
        public string name_firstname { get; set; }
        public string name_prefix { get; set; }
        public string name_lastname { get; set; }
        public string gender { get; set; }
        public string phone_countrycode { get; set; }
        public string phone_areacode { get; set; }
        public string phone_subscribernumber { get; set; }
        public string email { get; set; }
        public string address_street { get; set; }
        public string address_number { get; set; }
        public string address_suffix { get; set; }
        public string address_zipcode { get; set; }
        public string address_city { get; set; }
        public string address_state { get; set; }
        public string address_country { get; set; }
        public string fromdatetime { get; set; }
        public string todatetime { get; set; }
        public string car { get; set; }
    }
}
