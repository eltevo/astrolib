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
    static class FineTimeConverter
    {
        private static readonly DateTime FineTimeEpoch = new DateTime(1958, 1, 1);

        public static long FromDateTime(DateTime dateTime)
        {
            return (long)(dateTime - FineTimeEpoch).TotalMilliseconds;
        }

        public static DateTime ToDateTime(long fineTime)
        {
            return FineTimeEpoch.AddMilliseconds(fineTime);
        }
    }
}
