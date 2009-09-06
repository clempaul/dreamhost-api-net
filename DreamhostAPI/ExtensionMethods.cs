using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace clempaul
{
    internal static class ExtensionMethods
    {
        internal static bool AsBool(this XElement element)
        {
                if (element == null)
                {
                    return false;
                }
                else
                {
                    return !element.Value.Equals("0") && !element.Value.Equals("no");
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

    }
}
