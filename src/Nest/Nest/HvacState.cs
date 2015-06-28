﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public enum HvacState
    {
        [EnumMember(Value = "heating")]
        Heating,
        [EnumMember(Value = "cooling")]
        Cooling,
        [EnumMember(Value = "off")]
        Off
    }
}
