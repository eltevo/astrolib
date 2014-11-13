using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Jhu.AstroLib.Sql
{
    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
    public struct TimeUtc : INullable
    {
        #region Implementations required by SQL

        private bool isNull;

        public bool IsNull
        {
            get { return isNull; }
            set { isNull = value; }
        }

        public static TimeUtc Null
        {
            get { return new TimeUtc() { isNull = true }; }
        }

        public static TimeUtc Parse(SqlString s)
        {
            return Null;
        }

        public override string ToString()
        {
            return string.Empty;
        }

        #endregion

        public static SqlDateTime FromParts(SqlInt32 year, SqlInt32 month, SqlInt32 day, SqlInt32 hour, SqlInt32 minute, SqlInt32 second, SqlDouble millisecond)
        {
            return new SqlDateTime(year.Value, month.Value, day.Value, hour.Value, minute.Value, second.Value, millisecond.Value);
        }

        public static SqlDateTime FromTai(SqlDateTime tai)
        {
            return new SqlDateTime(Time.Utc.FromTai(tai.Value).Value);
        }

        public static SqlDateTime FromJd(SqlDouble jd)
        {
            return new SqlDateTime(Time.Utc.FromJd(jd.Value).Value);
        }

        public static SqlDateTime FromMjd(SqlDouble mjd)
        {
            return new SqlDateTime(Time.Utc.FromMjd(mjd.Value).Value);
        }
    }
}