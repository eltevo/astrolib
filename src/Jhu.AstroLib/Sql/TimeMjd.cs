using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Jhu.AstroLib.Sql
{
    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
    public struct TimeMjd : INullable
    {
        #region Implementations required by SQL

        private bool isNull;

        public bool IsNull
        {
            get { return isNull; }
            set { isNull = value; }
        }

        public static TimeMjd Null
        {
            get { return new TimeMjd() { isNull = true }; }
        }

        public static TimeMjd Parse(SqlString s)
        {
            return Null;
        }

        public override string ToString()
        {
            return string.Empty;
        }

        #endregion

        public static SqlDouble FromParts(SqlInt32 year, SqlInt32 month, SqlInt32 day, SqlInt32 hour, SqlInt32 minute, SqlInt32 second, SqlDouble millisecond)
        {
            return new SqlDouble(Time.Mjd.FromParts(year.Value, month.Value, day.Value, hour.Value, minute.Value, second.Value, millisecond.Value).Value);
        }

        public static SqlDouble FromUtc(SqlDateTime utc)
        {
            return new SqlDouble(Time.Mjd.FromUtc(utc.Value).Value);
        }

        public static SqlDouble FromTai(SqlDateTime tai)
        {
            return new SqlDouble(Time.Mjd.FromTai(tai.Value).Value);
        }

        public static SqlDouble FromHd(SqlDouble jd)
        {
            return new SqlDouble(Time.Mjd.FromJd(jd.Value).Value);
        }
    }
}