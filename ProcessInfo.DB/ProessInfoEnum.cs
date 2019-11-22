using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProcessInfo.DB
{
    public enum Environment
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
}
