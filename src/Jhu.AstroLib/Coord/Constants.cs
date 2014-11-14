using System;

namespace Jhu.AstroLib.Coord
{
    public static class Constants
    {
        public static readonly double DoublePrecision = Math.Pow(2, -53);
        public static readonly double DoublePrecision2x = 2 * DoublePrecision;

        public const float FloatTolerance = 5e-6f;
        public const double DegreeTolerance = 2.777777778e-7;

        public static readonly double Degree2Radian = Math.PI / 180;
        public static readonly double Radian2Degree = 180 / Math.PI;
        public static readonly double HalfPI = 0.5 * Math.PI;

        public static readonly char[] HmsSeparators = new char[] { ':', 'h', 'H', 'm', 'M', 's', 'S', '\'', '"' };
        public static readonly char[] DmsSeparators = new char[] { ':', '°', '\'', '"' };
        public static readonly char[] CoordinateSeparators = new char[] { ' ', '\t', ',', ';' };

        public const double SqlNaN = -9999;
    }
}
