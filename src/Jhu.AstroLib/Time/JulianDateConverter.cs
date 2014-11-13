//------------------------------------------------------------------------------
// <copyright file="CSSqlClassFile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Jhu.AstroLib
{
    static class JulianDateConverter
    {
        private static readonly DateTime JulianDateEpoch = new DateTime(2000, 1, 1, 12, 0, 0);
        private static readonly double JulianDateOrigin = 2451545.0;

        public static double FromDateTime(DateTime dateTime)
        {
            return JulianDateOrigin + (dateTime - JulianDateEpoch).TotalDays;
        }

        public static DateTime ToDateTime(double jd)
        {
            return JulianDateEpoch.AddDays(jd - JulianDateOrigin);
        }
    }
}
