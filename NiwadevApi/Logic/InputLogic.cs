using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.RegularExpressions;

namespace NiwadevApi.Logic
{
    public  static class InputLogic
    {
        public static bool CheckZipCode(string zipcode)
        {
            if(string.IsNullOrEmpty(zipcode))
            {
                return false;
            }
            if (zipcode.Length != 5)
                return false;
            return int.TryParse(zipcode, out int result );
        }
        public static bool CheckName(string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }
            Regex r = new Regex(@"^[a-zA-Z ]+$");
            return r.Match(Name).Success;
        }
        public static bool CheckAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }
            Regex r = new Regex(@"^[a-zA-Z0-9-.]+$");
            return r.Match(address).Success;
        }
        public static bool CheckPlace(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return false;
            }
            Regex r = new Regex(@"^[a-zA-Z-]+$");
            return r.Match(address).Success;
        }
    }
}
