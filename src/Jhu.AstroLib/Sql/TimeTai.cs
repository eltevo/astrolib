using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Jhu.AstroLib.Sql
{
    [Serializable]
    [Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
    public struct TimeTai : INullable
    {
        #region Implementations required by SQL

        private bool isNull;

        public bool IsNull
        {
            get { return isNull; }
            set { isNull = value; }
        }

        public static TimeTai Null
        {
            get { return new TimeTai() { isNull = true }; }
        }

        public static TimeTai Parse(SqlString s)
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

        public static SqlDateTime FromUtc(SqlDateTime utc)
        {
            return new SqlDateTime(Time.Tai.FromUtc(utc.Value).Value);
        }

        public static SqlDateTime FromJd(SqlDouble jd)
        {
            return new SqlDateTime(Time.Tai.FromJd(jd.Value).Value);
        }

        public static SqlDateTime FromMjd(SqlDouble mjd)
        {
            return new SqlDateTime(Time.Tai.FromMjd(mjd.Value).Value);
        }
    }
}