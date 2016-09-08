using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeKoningAutoverhuur.Web.WebApplication.Common.Objects
{
    public class ReserveObject
    {
        public CarObject car;
        public ClientObject client;
        public DateTime FromDateTime;
        public DateTime ToDateTime;
        public DateTime Created;
        public DateTime Modified;
        public Boolean Deleted;
        public DateTime DeletedDate;
    }
}
