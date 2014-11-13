using System;

namespace Jhu.AstroLib.Time
{
    [Serializable]
    public struct Jd
    {
        private double value;

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public static explicit operator double(Jd jd)
        {
            return jd.value;
        }

        public static implicit operator Jd(double jd)
        {
            return new Jd() { value = jd };
        }

        public static Jd FromParts(int year, int month, int day, int hour, int minute, int second, double millisecond)
        {
            var tai = Tai.FromParts(year, month, day, hour, minute, second, millisecond);
            return FromTai(tai);
        }

        public static Jd FromUtc(Utc utc)
        {
            var tai = Tai.FromUtc(utc);
            return FromTai(tai);
        }

        public static Jd FromTai(Tai tai)
        {
            return JulianDateConverter.FromDateTime(tai.Value);
        }

        public static Jd FromMjd(Mjd mjd)
        {
            double jd = mjd.Value + 2400000.5;
            return jd;
        }
    }
}