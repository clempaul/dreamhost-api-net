using System;
using System.Xml.Linq;

namespace clempaul
{
    internal static class DreamhostExtensionMethods
    {
        internal static bool AsBool(this XElement element)
        {
                if (element == null)
                {
                    return false;
                }
                else
                {
                    return !element.Value.Equals("0") && !element.Value.Equals("no") && !element.Value.Equals("N");
                }
        }

        internal static string AsString(this XElement element)
        {
            if (element == null)
            {
                return string.Empty;
            }
            else
            {
                return element.Value;
            }
        }

        internal static DateTime AsDateTime(this XElement element)
        {
            if (element == null)
            {
                return new DateTime();
            }
            else
            {
                return DateTime.Parse(element.Value);
            }
        }

        internal static int AsInt(this XElement element) {
            if (element == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(element.Value);
            }
        }

        internal static double AsDouble(this XElement element)
        {
            if (element == null)
            {
                return 0;
            }
            else
            {
                return double.Parse(element.Value);
            }
        }

        internal static string AsYYYYMMDD(this DateTime? value)
        {
            return ((DateTime)value).ToString("YYYY-MM-DD");
        }

        internal static string AsTimestamp(this DateTime? value)
        {
            return ((DateTime)value).ToString("YYYY-MM-DD HH:mm");
        }

        internal static string AsBit(this bool value)
        {
            if (value)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        internal static string AsBit(this bool? value)
        {
            if ((bool)value)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        internal static string AsYN(this bool? value)
        {
            if ((bool)value)
            {
                return "Y";
            }
            else
            {
                return "N";
            }
        }

        internal static string Asyesno(this bool? value)
        {
            if ((bool)value)
            {
                return "yes";
            }
            else
            {
                return "no";
            }
        }
    }
}
