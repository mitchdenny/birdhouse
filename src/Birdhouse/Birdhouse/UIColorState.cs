﻿using System.Runtime.Serialization;

namespace Birdhouse
{
    public enum UIColorState
    {
        [EnumMember(Value = "gray")]
        Gray,
        [EnumMember(Value = "green")]
        Green,
        [EnumMember(Value = "yellow")]
        Yellow,
        [EnumMember(Value = "red")]
        Red
    }
}