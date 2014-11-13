using System;
using System.Text;
using System.Globalization;

namespace Jhu.AstroLib.Coord
{
    public class Degree
    {
        private double value;

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public static explicit operator double(Degree degree)
        {
            return degree.value;
        }

        public static implicit operator Degree(double degree)
        {
            return new Degree() { value = degree };
        }

        public static Degree ParseHms(string value)
        {
            double degree;

            if (!TryParseHms(value, out degree))
            {
                throw new FormatException();
            }

            return degree;
        }

        public static Degree ParseDms(string value)
        {
            double degree;

            if (!TryParseDms(value, out degree))
            {
                throw new FormatException();
            }

            return degree;
        }

        public static bool TryParseHms(string value, out double ra)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            ra = double.NaN;

            // Break string into parts
            var parts = value.Split(Constants.HmsSeparators);

            // There can be three or four parts. Three parts means fractional seconds
            // are attached to the seconds part, in case of four parts, they're separate, but
            // stich them now and handle them together

            if (parts.Length < 3 || parts.Length > 4)
            {
                return false;
            }
            else if (parts.Length == 4)
            {
                // Stich fractional part to seconds
                parts[2] += parts[3];
            }

            // Now we have to parse the three parts only
            int hours, minutes;
            double seconds;

            if (!int.TryParse(parts[0], out hours) ||
                !int.TryParse(parts[1], out minutes) ||
                !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out seconds))
            {
                // parsing any of the three parts failed
                return false;
            }

            // So far so good, but check ranges
            if (hours < -12 || hours > 23)
            {
                return false;
            }

            if (minutes < 0 || minutes > 59)
            {
                return false;
            }

            if (seconds < 0 || seconds >= 60)
            {
                return false;
            }

            // Everything seems fine, convert to degrees

            ra = 15.0 * hours + 0.25 * minutes + 0.25 / 60.0 * seconds;

            return true;
        }

        public static bool TryParseDms(string value, out double dec)
        {
            dec = double.NaN;

            // Break string into parts

            var parts = value.Split(Constants.DmsSeparators);

            // There can be three or four parts. Three parts means fractional seconds
            // are attached to the seconds part, in case of four parts, they're separate, but
            // stich them now and handle them together

            if (parts.Length < 3 || parts.Length > 4)
            {
                return false;
            }
            else if (parts.Length == 4)
            {
                // Stich fractional part to seconds
                parts[2] += parts[3];
            }

            // Now we have to parse the three parts only
            int degrees, minutes;
            double seconds;

            if (!int.TryParse(parts[0], out degrees) ||
                !int.TryParse(parts[1], out minutes) ||
                !double.TryParse(parts[2], NumberStyles.Float, CultureInfo.InvariantCulture, out seconds))
            {
                // parsing any of the three parts failed
                return false;
            }

            // So far so good, but check ranges
            if (degrees < -90 || degrees > 90)
            {
                return false;
            }

            if (minutes < 0 || minutes > 59)
            {
                return false;
            }

            if (seconds < 0 || seconds >= 60)
            {
                return false;
            }

            // Everything seems fine, convert to degrees

            dec = degrees + minutes / 60.0 + seconds / 3600.0;

            return true;
        }

        /// <summary>
        /// Breaks a decimal degree into degree, minutes and seconds.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="deg"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        public static void GetDegreeParts(double value, out double deg, out double min, out double sec)
        {
            value += Constants.DegreeTolerance;

            deg = Math.Floor(value);
            min = Math.Floor((value - deg) * 60);
            sec = ((value - deg) * 60 - min) * 60;
        }

        /// <summary>
        /// Breaks a decimal degree in hours, minutes and seconds.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hour"></param>
        /// <param name="min"></param>
        /// <param name="sec"></param>
        public static void GetHourParts(double value, out double hour, out double min, out double sec)
        {
            value = value / 15 + Constants.DegreeTolerance;

            hour = Math.Floor(value);
            min = Math.Floor((value - hour) * 60);
            sec = ((value - hour) * 60 - min) * 60;
        }

        /// <summary>
        /// Returns the angle as a formatted string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string FormatDegree(double value, DegreeFormatInfo degreeFormat)
        {
            var sb = new StringBuilder();

            if (degreeFormat.DegreeWrapAroundStyle == DegreeWrapAroundStyle.PlusMinus180 &&
                value > 180)
            {
                value -= 360;
            }

            if (degreeFormat.LeadingPositiveSign && value > 0)
            {
                sb.Append(degreeFormat.PositiveSign);
            }
            else if (value < 0)
            {
                sb.Append(degreeFormat.NegativeSign);
            }
            else
            {
                sb.Append(degreeFormat.FigureSpace);
            }

            switch (degreeFormat.DegreeStyle)
            {
                case DegreeStyle.Decimal:
                    FormatDegreeDecimal(value, sb, degreeFormat);
                    break;
                case DegreeStyle.Symbols:
                    FormatDegreeSymbols(value, sb, degreeFormat);
                    break;
                case DegreeStyle.Hours:
                    FormatDegreeHours(value, sb, degreeFormat);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Formats a decimal degree to the D.FF° format.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sb"></param>
        private static void FormatDegreeDecimal(double value, StringBuilder sb, DegreeFormatInfo degreeFormat)
        {
            sb.Append(Math.Abs(value).ToString(degreeFormat.NumberFormatString, degreeFormat.NumberFormat));

            sb.Append(degreeFormat.DegreeSymbol);
        }

        /// <summary>
        /// Formats a degree in DD°MM'SS".FF format from a decimal degree value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sb"></param>
        private static void FormatDegreeSymbols(double value, StringBuilder sb, DegreeFormatInfo degreeFormat)
        {
            double deg, min, sec;
            GetDegreeParts(value, out deg, out min, out sec);

            var secfloor = Math.Floor(sec);
            var secfrac = sec - secfloor;

            // Display degree always
            sb.Append(Math.Abs(deg).ToString("0", degreeFormat.NumberFormat));
            sb.Append(degreeFormat.DegreeSymbol);

            // Display minute and seconds only if increment makes it necessary
            if (degreeFormat.Increment < 1)
            {
                sb.Append(min.ToString("00", degreeFormat.NumberFormat));
                sb.Append(degreeFormat.ArcMinuteSymbol);
            }

            if (degreeFormat.Increment < 1 / 60.0)
            {
                sb.Append(secfloor.ToString("00", degreeFormat.NumberFormat));
                sb.Append(degreeFormat.ArcSecondSymbol);
            }

            if (degreeFormat.Increment < 1 / 3600.0)
            {
                sb.Append(secfrac.ToString(degreeFormat.NumberFormatString, degreeFormat.NumberFormat));
            }
        }

        /// <summary>
        /// Formats a degree in HH:MM:SS.FF format from a decimal degree value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sb"></param>
        private static void FormatDegreeHours(double value, StringBuilder sb, DegreeFormatInfo degreeFormat)
        {
            double hour, min, sec;

            GetHourParts(value, out hour, out min, out sec);

            var secfloor = Math.Floor(sec);
            var secfrac = sec - secfloor;

            // Display degree always
            sb.Append(Math.Abs(hour).ToString("0", degreeFormat.NumberFormat));
            sb.Append(degreeFormat.HourSymbol);

            // Display minute and seconds only if increment makes it necessary
            if (degreeFormat.Increment < 15)
            {
                sb.Append(min.ToString("00", degreeFormat.NumberFormat));
                sb.Append(degreeFormat.MinuteSymbol);
            }

            if (degreeFormat.Increment < 15 / 60.0)
            {
                sb.Append(secfloor.ToString("00", degreeFormat.NumberFormat));
                sb.Append(degreeFormat.SecondSymbol);
            }

            if (degreeFormat.Increment < 15 / 3600.0)
            {
                sb.Append(secfrac.ToString(degreeFormat.NumberFormatString, degreeFormat.NumberFormat));
            }
        }

        public string ToString(DegreeFormatInfo degreeFormat)
        {
            return FormatDegree(value, degreeFormat);
        }
    }
}
