using System;

namespace Jhu.AstroLib.Time
{
    [Serializable]
    public struct Tai
    {
        #region TAI constants

        private static readonly DateTime UtcEpoch = new DateTime(1972, 1, 1);
        private static readonly int LeapSeconds1972 = 10;
        private static readonly DateTime[] LeapSeconds = new DateTime[]
        {
            new DateTime(1972, 6, 30),
            new DateTime(1972, 12, 31),
            new DateTime(1973, 12, 31),
            new DateTime(1974, 12, 31),
            new DateTime(1975, 12, 31),
            new DateTime(1976, 12, 31),
            new DateTime(1977, 12, 31),
            new DateTime(1978, 12, 31),
            new DateTime(1979, 12, 31),
            new DateTime(1981, 6, 30),
            new DateTime(1982, 6, 30),
            new DateTime(1983, 6, 30),
            new DateTime(1985, 6, 30),
            new DateTime(1987, 12, 31),
            new DateTime(1989, 12, 31),
            new DateTime(1990, 12, 31),
            new DateTime(1992, 6, 30),
            new DateTime(1993, 6, 30),
            new DateTime(1994, 6, 30),
            new DateTime(1995, 12, 31),
            new DateTime(1997, 6, 30),
            new DateTime(1998, 12, 31),
            new DateTime(2005, 12, 31),
            new DateTime(2008, 12, 31),
            new DateTime(2012, 6, 30),
        };

        #endregion

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
            return new Tai() { value = dateTime };
        }

        internal static DateTime AddLeapSeconds(DateTime utc)
        {
            if (utc < UtcEpoch)
            {
                return utc;
            }
            else
            {
                int i = 0;

                while (i < LeapSeconds.Length && utc > LeapSeconds[i])
                {
                    i++;
                }

                i += LeapSeconds1972;

                return utc.AddSeconds(i);
            }
        }

        internal static DateTime SubtractLeapSeconds(DateTime tai)
        {
            if (tai < UtcEpoch)
            {
                return tai;
            }
            else
            {
                int i = LeapSeconds.Length;

                while (i > 0 && tai < LeapSeconds[i - 1])
                {
                    i--;
                }

                i += LeapSeconds1972;

                return tai.AddSeconds(-i);
            }
        }

        public static Tai FromParts(int year, int month, int day, int hour, int minute, int second, double millisecond)
        {
            return new DateTime(year, month, day, hour, minute, second, (int)millisecond, DateTimeKind.Utc);
        }

        public static Tai FromUtc(Utc utc)
        {
            return Tai.AddLeapSeconds(utc.Value);
        }

        public static Tai FromJd(Jd jd)
        {
            return Jd.ToDateTime(jd.Value);
        }

        public static Tai FromMjd(Mjd mjd)
        {
            var jd = Jd.FromMjd(mjd);
            return Jd.ToDateTime(jd.Value);
        }
    }
}