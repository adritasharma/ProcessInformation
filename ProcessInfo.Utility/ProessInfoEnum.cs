﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProcessInfo.Utility
{
    public enum HostEnvironment
    {
        [Description("DEV")]
        DEV = 0,
        [Description("QA")]
        QA = 1,
        [Description("UAT")]
        UAT = 2,
        [Description("DR")]
        DR = 2,
        [Description("PROD")]
        PROD = 2,
    }

    public enum FCSortDirection
    {
        Ascending = 0,
        Descending = 1
    }
}