using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace burda.Helpers
{
    public class ValidationHelper
    {
        public static bool IsStringNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }
        public static bool IsStringNullOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static bool IsStringValid(string value)
        {
            return !IsStringNullOrEmpty(value) && !IsStringNullOrWhiteSpace(value);
        }
        public static bool IsIntValid(int value)
        {
            return value > 0;
        }
        public static bool IsDateTimeValid(DateTime value)
        {
            return value > DateTime.MinValue;
        }
        public static bool IsListValid<T>(List<T> value)
        {
            return value != null && value.Count > 0;
        }

        public static bool IsEmailValid(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return false;
                }

                if (email.Length > 254)
                {
                    return false;
                }

                if (!email.Contains("@") || !email.Contains("."))
                {
                    return false;
                }

                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}