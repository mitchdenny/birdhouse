using System.Runtime.Serialization;

namespace Nest
{
    public enum SmokeAlarmState
    {
        [EnumMember(Value = "ok")]
        OK,
        [EnumMember(Value = "warning")]
        Warning,
        [EnumMember(Value = "emergency")]
        Emergency
    }
}