using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Jhu.AstroLib.Sql
{
    public partial class UserDefinedFunctions
    {
        #region Date part function

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt64 ConvertTimePartsToFineTime(SqlInt32 year, SqlInt32 month, SqlInt32 day, SqlInt32 hour, SqlInt32 minute, SqlInt32 second, SqlDouble millisecond)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimePartsToJd(SqlInt32 year, SqlInt32 month, SqlInt32 day, SqlInt32 hour, SqlInt32 minute, SqlInt32 second, SqlDouble millisecond)
        {
            return new SqlDouble(Time.Jd.FromParts(year.Value, month.Value, day.Value, hour.Value, minute.Value, second.Value, millisecond.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimePartsToMjd(SqlInt32 year, SqlInt32 month, SqlInt32 day, SqlInt32 hour, SqlInt32 minute, SqlInt32 second, SqlDouble millisecond)
        {
            return new SqlDouble(Time.Mjd.FromParts(year.Value, month.Value, day.Value, hour.Value, minute.Value, second.Value, millisecond.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimePartsToTai(SqlInt32 year, SqlInt32 month, SqlInt32 day, SqlInt32 hour, SqlInt32 minute, SqlInt32 second, SqlDouble millisecond)
        {
            return new SqlDateTime(Time.Tai.FromParts(year.Value, month.Value, day.Value, hour.Value, minute.Value, second.Value, millisecond.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimePartsToUtc(SqlInt32 year, SqlInt32 month, SqlInt32 day, SqlInt32 hour, SqlInt32 minute, SqlInt32 second, SqlDouble millisecond)
        {
            return new SqlDateTime(Time.Utc.FromParts(year.Value, month.Value, day.Value, hour.Value, minute.Value, second.Value, millisecond.Value).Value);
        }

        #endregion
        #region FineTime functions

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeFineTimeToJd(SqlInt64 fineTime)
        {
            throw new NotImplementedException();
            //return new SqlDouble(Time.Jd.FromFineTime(fineTime.Value));
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeFineTimeToMjd(SqlInt64 fineTime)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeFineTimeToTai(SqlInt64 fineTime)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeFineTimeToUtc(SqlInt64 fineTime)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region JD functions

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt64 ConvertTimeJdToFineTime(SqlDouble jd)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeJdToMjd(SqlDouble jd)
        {
            return new SqlDouble(Time.Mjd.FromJd(jd.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeJdToTai(SqlDouble jd)
        {
            return new SqlDateTime(Time.Tai.FromJd(jd.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeJdToUtc(SqlDouble jd)
        {
            return new SqlDateTime(Time.Utc.FromJd(jd.Value).Value);
        }

        #endregion
        #region MJD function

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt64 ConvertTimeMjdToFineTime(SqlDouble mjd)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeMjdToJd(SqlDouble mjd)
        {
            return new SqlDouble(Time.Jd.FromMjd(mjd.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeMjdToTai(SqlDouble mjd)
        {
            return new SqlDateTime(Time.Tai.FromMjd(mjd.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeMjdToUtc(SqlDouble mjd)
        {
            return new SqlDateTime(Time.Utc.FromMjd(mjd.Value).Value);
        }

        #endregion
        #region TAI function

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt64 ConvertTimeTaiToFineTime(SqlDateTime tai)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeTaiToJd(SqlDateTime tai)
        {
            return new SqlDouble(Time.Jd.FromTai(tai.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeTaiToMjd(SqlDateTime tai)
        {
            return new SqlDouble(Time.Mjd.FromTai(tai.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeTaiToUtc(SqlDateTime tai)
        {
            return new SqlDateTime(Time.Utc.FromTai(tai.Value).Value);
        }

        #endregion
        #region UTC function

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlInt64 ConvertTimeUtcToFineTime(SqlDateTime utc)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeUtcToJd(SqlDateTime utc)
        {
            return new SqlDouble(Time.Jd.FromUtc(utc.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertTimeUtcToMjd(SqlDateTime utc)
        {
            return new SqlDouble(Time.Mjd.FromUtc(utc.Value).Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDateTime ConvertTimeUtcToTai(SqlDateTime utc)
        {
            return new SqlDateTime(Time.Tai.FromUtc(utc.Value).Value);
        }

        #endregion
    }
}