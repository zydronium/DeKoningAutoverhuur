using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeKoningAutoverhuur.Web.WebApplication.Models.ReserveViewModels
{
    public class DetailsViewModel
    {
        public string name_initials { get; set; }
        public string name_firstname { get; set; }
        public string name_prefix { get; set; }
        public string name_lastname { get; set; }
        public string phone_countrycode { get; set; }
        public string phone_areacode { get; set; }
        public string phone_subscribernumber { get; set; }
        public string email { get; set; }
        public string address_country { get; set; }
    }
}
