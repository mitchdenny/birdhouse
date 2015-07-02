using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Birdhouse
{
    public enum BatteryHealth
    {
        [EnumMember(Value = "ok")]
        OK,
        [EnumMember(Value = "replace")]
        Replace
    }
}
