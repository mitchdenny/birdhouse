using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public enum BatteryHealth
    {
        [EnumMember(Value = "ok")]
        OK,
        [EnumMember(Value = "replace")]
        Replace
    }
}
