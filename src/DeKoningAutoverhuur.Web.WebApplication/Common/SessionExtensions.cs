using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeKoningAutoverhuur.Web.WebApplication.Common
{
    public static class SessionExtensions
    {
        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static bool Contains(this ISession session, string key)
        {
            var data = session.Keys;
            foreach (var sKey in data)
            {
                if (sKey == key)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
