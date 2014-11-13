using System;

namespace Jhu.AstroLib.Time
{
    [Serializable]
    public struct Mjd
    {
        private double value;

        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public static explicit operator double(Mjd mjd)
        {
            return mjd.value;
        }

        public static implicit operator Mjd(double mjd)
        {
            return new Mjd() { value = mjd };
        }

        public static Mjd FromParts(int year, int month, int day, int hour, int minute, int second, double millisecond)
        {
            var tai = Tai.FromParts(year, month, day, hour, minute, second, millisecond);
            return FromTai(tai);
        }

        public static Mjd FromUtc(Utc utc)
        {
            var tai = Tai.FromUtc(utc);
            return FromTai(tai);
        }

        public static Mjd FromTai(Tai tai)
        {
            var jd = Jd.FromTai(tai);
            return FromJd(jd);
        }

        public static Mjd FromJd(Jd jd)
        {
            double mjd = jd.Value - 2400000.5;
            return mjd;
        }        
    }
}