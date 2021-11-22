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

        private const int TYPE_VALUE = 1;
        private const int TYPE_WORK = 2;
        private const int TYPE_FLAG = 3;
        private const int TYPE_SYS = 4;
        private const int TYPE_LABEL = 5;

        public Arg() { } // json deserialize
        public Arg(string line, string[] labels) => Read(line, labels);

        public string Format(string[] strList) => argType switch
        {
            TYPE_VALUE => $"{BitConverter.Int32BitsToSingle(data)}",
            TYPE_WORK  => $"WORK[{data}]",
            TYPE_FLAG  => $"FLAG[{data}]",
            TYPE_SYS   => $"SYS_FLAG[{data}]",
            TYPE_LABEL => $"\"{strList[data]}\"",
            _ => throw new ArgumentOutOfRangeException(nameof(argType)),
        };

        public void Read(string str, string[] strList)
        {
            if (str.StartsWith("WORK["))
                ReadInt(TYPE_WORK, str);
            else if (str.StartsWith("FLAG["))
                ReadInt(TYPE_FLAG, str);
            else if (str.StartsWith("SYS_FLAG["))
                ReadInt(TYPE_FLAG, str);
            else if (str.StartsWith('"'))
                ReadLabel(TYPE_LABEL, str, strList);
            else
                ReadFloat(TYPE_VALUE, str);
        }

        private void ReadFloat(int type, string str)
        {
            var parse = float.TryParse(str.Replace("f", ""), out var value);
            if (!parse)
                throw new FormatException($"Provided float value ({str}) unable to be parsed.");

            argType = type;
            data = BitConverter.SingleToInt32Bits(value);
        }

        private void ReadLabel(int type, string str, string[] strList)
        {
            var text = str.Replace("\"", "");
            var index = Array.IndexOf(strList, text);
            if (index == -1)
                throw new FormatException($"Label \"{text}\" not found in {nameof(strList)}.");

            argType = type;
            data = index;
        }

        private void ReadInt(int type, string str)
        {
            argType = type;
            data = GetInt(str);
        }

        private static int GetInt(string str)
        {
            var start = str.IndexOf('[') + 1;
            var end = str.IndexOf('[');
            var length = end - start;
            var slice = str.AsSpan(start, length);
            var parse = int.TryParse(slice, out var value);
            if (!parse)
                throw new FormatException($"{slice.ToString()} is not a valid integer.");
            return value;
        }
    }
}
