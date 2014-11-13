using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

namespace Jhu.AstroLib.Sql
{
    public partial class UserDefinedFunctions
    {
        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertHmsToDegree(SqlString hms)
        {
            var deg = Coord.Degree.ParseHms(hms.Value);
            return new SqlDouble(deg.Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlDouble ConvertDmsToDegree(SqlString dms)
        {
            var deg = Coord.Degree.ParseDms(dms.Value);
            return new SqlDouble(deg.Value);
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString ConvertDegreeToHms(SqlDouble value)
        {
            var deg = new Coord.Degree() { Value = value.Value };
            return new SqlString(deg.ToString(Coord.DegreeFormatInfo.DefaultHours));
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static SqlString ConvertDegreeToDms(SqlDouble value)
        {
            var deg = new Coord.Degree() { Value = value.Value };
            return new SqlString(deg.ToString(Coord.DegreeFormatInfo.DefaultDegrees));
        }
    }
}
