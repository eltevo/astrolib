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
        public static double FromDateTime(DateTime dateTime)
        {
            int a = (14 - dateTime.Month) / 12;      // Floor is taken!
            int y = dateTime.Year + 4800 - a;
            int m = dateTime.Month + 12 * a - 3;

            int jdn = dateTime.Day + (153 * m + 2) / 5 + 365 * y + y / 4 - y / 100 + y / 400 - 32045;
            double jd = jdn + (dateTime.Hour - 12) / 24.0 + dateTime.Minute / 1440.0 + dateTime.Second / 86400.0 + dateTime.Millisecond / 86400000.0;

            return jd;
        }

        public static DateTime ToDateTime(double jd)
        {
            const int y = 4716;
            const int v = 3; 
            const int j = 1401;
            const int u = 5 ;
            const int m = 2;
            const int s = 153;
            const int n = 12;
            const int w = 2;
            const int r = 4;
            const int B = 274277;
            const int p = 1461;
            const int C = -38;

            int J = (int)Math.Floor(jd);

            int f = J + j + (((4 * J + B) / 146097) * 3) / 4 + C;
            int e = r * f + v;
            int g = (e % p) / r;
            int h = u * g + w;
            int D = ((h % s)) / u + 1;
            int M = ((h / s + m) % n) + 1;
            int Y = (e / p) - y + (n + m - M) / n;

            return new DateTime(Y, M, D);
        }
    }
}
