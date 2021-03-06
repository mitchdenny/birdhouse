﻿using System.Runtime.Serialization;

namespace Birdhouse
{
    public enum Away
    {
        [EnumMember(Value = "home")]
        Home,
        [EnumMember(Value = "away")]
        Away,
        [EnumMember(Value = "auto-away")]
        AutoAway,
        [EnumMember(Value = "unknown")]
        Unknown
    }
}