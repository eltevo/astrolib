using System;

namespace Jhu.AstroLib.Coord
{
    public static class Constants
    {
        public const float FloatTolerance = 5e-6f;
        public const double DegreeTolerance = 2.777777778e-7;

        public static readonly char[] HmsSeparators = new char[] { ':', 'h', 'H', 'm', 'M', 's', 'S', '\'', '"' };
        public static readonly char[] DmsSeparators = new char[] { ':', '°', '\'', '"' };
        public static readonly char[] CoordinateSeparators = new char[] { ' ', '\t', ',', ';' };
    }
}
