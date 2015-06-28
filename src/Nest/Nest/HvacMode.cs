using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nest
{
    public enum HvacMode
    {
        [EnumMember(Value = "heat")]
        Heat,
        [EnumMember(Value = "cool")]
        Cool,
        [EnumMember(Value = "heat-cool")]
        HeatCool,
        [EnumMember(Value = "off")]
        Off
    }
}
