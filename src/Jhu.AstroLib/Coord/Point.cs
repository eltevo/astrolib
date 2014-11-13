using System;
using System.Text;
using System.Globalization;

namespace Jhu.AstroLib.Coord
{
    public struct Point
    {
        private Degree ra;
        private Degree dec;
        private double x;
        private double y;
        private double z;

        public Degree RA
        {
            get { return ra; }
            set { ra = value; }
        }

        public Degree Dec
        {
            get { return dec; }
            set { dec = value; }
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public static Point Parse(string value)
        {
            double ra, dec;

            if (!TryParseCoordinates(value, out ra, out dec))
            {
                throw new FormatException();
            }

            return new Point()
            {
                ra = ra,
                dec = dec,
            };
        }

        private static bool TryParseCoordinates(string value, out double ra, out double dec)
        {
            ra = dec = double.NaN;

            // First identify parts seperated by whitespaces, colons, semicolons,
            // anything that's not used in degree notation

            var parts = value.Split(Constants.CoordinateSeparators, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                // Coordinates have two parts

                return false;
            }

            // Now try to parse coordinates as decimal values

            if (double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out ra) &&
                double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out dec))
            {
                // Coordinates are decimal numbers

                return true;
            }

            // Now try to interpret them as HMS and DMS values

            if (Degree.TryParseHms(parts[0], out ra) &&
                Degree.TryParseDms(parts[1], out dec))
            {
                // Coordinates are indeed HMS and DMS values

                return true;
            }

            // If everything fails, it must be some invalid string (possibly object name)

            return false;
        }

        public string ToString(DegreeFormatInfo raFormat, DegreeFormatInfo decFormat)
        {
            return ra.ToString(raFormat) + " " + dec.ToString(decFormat);
        }

        public string ToString()
        {
            return ToString(DegreeFormatInfo.DefaultHours, DegreeFormatInfo.DefaultDegrees);
        }
    }
}
