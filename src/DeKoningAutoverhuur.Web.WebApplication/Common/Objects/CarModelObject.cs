using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeKoningAutoverhuur.Web.WebApplication.Common.Objects
{
    public class CarModelObject
    {
        public string Id;
        public string Brand;
        public string Model;
        public string Transmission;
        public string Segment;
        public double PricePerDay;
        public string Image;
        public DateTime Created;
        public DateTime Modified;
        public Boolean Deleted;
        public DateTime DeletedDate;
    }
}
