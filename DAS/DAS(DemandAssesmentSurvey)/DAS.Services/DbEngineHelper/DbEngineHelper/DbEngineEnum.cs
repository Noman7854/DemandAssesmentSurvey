using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.DbEngineHelper
{
    public enum DatabaseType
    {
        Access = 1,
        MSSqlServer = 2,
        Oracle = 3,
        MySql = 4,
        SqAnywhere = 5
    }

    public enum ParameterType
    {
        Integer,
        Char,
        VarChar
    }
}