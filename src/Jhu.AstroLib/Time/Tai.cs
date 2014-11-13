using System;

namespace Jhu.AstroLib.Time
{
    [Serializable]
    public struct Tai
    {
        private DateTime value;

        public DateTime Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public static explicit operator DateTime(Tai utc)
        {
            return utc.value;
        }

        public static implicit operator Tai(DateTime dateTime)
        {
            return new Tai() { value = dateTime.ToUniversalTime() };
        }

        public static Tai FromParts(int year, int month, int day, int hour, int minute, int second, double millisecond)
        {
            return new DateTime(year, month, day, hour, minute, second, (int)millisecond, DateTimeKind.Utc);
        }

        public static Tai FromUtc(Utc utc)
        {
            return LeapSecondsConverter.AddLeapSeconds(utc.Value);
        }

        public static Tai FromJd(Jd jd)
        {
            return JulianDateConverter.ToDateTime(jd.Value);
        }

        public static Tai FromMjd(Mjd mjd)
        {
            var jd = Jd.FromMjd(mjd);
            return JulianDateConverter.ToDateTime(jd.Value);
        }
    }
}