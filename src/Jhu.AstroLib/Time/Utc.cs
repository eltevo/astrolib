using System;

namespace Jhu.AstroLib.Time
{
    [Serializable]
    public struct Utc
    {
        private DateTime value;

        public DateTime Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public static explicit operator DateTime(Utc utc)
        {
            return utc.value;
        }

        public static implicit operator Utc(DateTime dateTime)
        {
            return new Utc() { value = dateTime };
        }

        public static Utc FromParts(int year, int month, int day, int hour, int minute, int second, double millisecond)
        {
            return new DateTime(year, month, day, hour, minute, second, (int)millisecond, DateTimeKind.Utc);
        }

        public static Utc FromTai(Tai tai)
        {
            return Tai.SubtractLeapSeconds(tai.Value);
        }

        public static Utc FromJd(Jd jd)
        {
            var tai = Tai.FromJd(jd);
            return Utc.FromTai(tai);
        }

        public static Utc FromMjd(Mjd mjd)
        {
            var tai = Tai.FromMjd(mjd);
            return Utc.FromTai(tai);
        }
    }
}