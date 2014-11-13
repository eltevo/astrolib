using System;

namespace Jhu.AstroLib.Time
{
    [Serializable]
    public struct FineTime
    {
        private long value;

        public long Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public static explicit operator long(FineTime fineTime)
        {
            return fineTime.value;
        }

        public static implicit operator FineTime(long fineTime)
        {
            return new FineTime() { value = fineTime };
        }


    }
}