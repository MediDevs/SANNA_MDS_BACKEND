using MDS.Utility.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Enums
{
    public enum ELogType
    {
        [EnumDescription("Unknown", 0)]
        Unknown = 0,

        [EnumDescription("New blog added", 0)]
        BlogAdded = 1,
        [EnumDescription("Blog updated", 0)]
        BlogUpdated = 2,

        // etc...
    }
}
