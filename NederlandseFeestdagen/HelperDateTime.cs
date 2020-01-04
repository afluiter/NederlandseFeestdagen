using System;
using System.Globalization;

namespace Generic
{
    public static class HelperDateTime
    {
        public static bool TryParseDutch(string value, out DateTime result)
        {
            return (DateTime.TryParse(value, new CultureInfo("nl-NL", false), DateTimeStyles.None, out result));
        }
    }
}
