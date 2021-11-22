using System;

namespace UnityDPtools.Scripts
{
    public class ScriptJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Script[] Scripts { get; set; }
        public string[] StrList { get; set; }
    }

    public class Script
    {
        public string Label { get; set; }
        public Command[] Commands { get; set; }
    }

    public class Command
    {
        public Arg[] Arg { get; set; }
    }

    public class Arg
    {
        public int argType { get; set; }
        public int data { get; set; }

        public string Format(string[] strList) => argType switch
        {
            1 => $"{BitConverter.Int32BitsToSingle(data)}",
            2 => $"WORK[{data}]",
            3 => $"FLAG[{data}]",
            4 => $"SYS_FLAG[{data}]",
            5 => $"\"{strList[data]}\"",
            _ => throw new ArgumentOutOfRangeException(nameof(argType)),
        };
    }
}
