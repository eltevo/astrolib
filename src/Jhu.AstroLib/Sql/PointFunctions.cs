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
        public static Coord.Point ConvertPointEqToGal(Coord.Point eq)
        {
            throw new NotImplementedException();
        }

        [Microsoft.SqlServer.Server.SqlFunction]
        public static Coord.Point ConvertPointGalToEq(Coord.Point gal)
        {
            throw new NotImplementedException();
        }
    }
}
