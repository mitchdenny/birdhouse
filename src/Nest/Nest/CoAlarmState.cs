using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public enum CoAlarmState
    {
        [EnumMember(Value = "ok")]
        OK,
        [EnumMember(Value = "warning")]
        Warning,
        [EnumMember(Value = "emergency")]
        Emergency
    }
}
