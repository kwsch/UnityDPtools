using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace UnityDPtools.Scripts
{
    public static class ScriptPrinter
    {
        public static void Dump<T>(string dir) where T : Enum
        {
            var files = Directory.GetFiles(dir, "*.json", 0);
            foreach (var f in files)
                PrintScript<T>(f);
        }

        public static void PrintScript<T>(string path) where T : Enum
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<ScriptJsonFile>(text);
            if (obj.Scripts is null)
            {
                Debug.WriteLine($"Not a script: {obj.m_Name}");
                return;
            }

            Debug.WriteLine($"Dumping {obj.m_Name}");
            var lines = GetScriptPrintout<T>(obj);

            File.WriteAllLines(Path.ChangeExtension(path, "txt"), lines);
        }

        private static List<string> GetScriptPrintout<T>(ScriptJsonFile obj) where T : Enum
        {
            var lines = new List<string>();
            foreach (var block in obj.Scripts)
            {
                lines.Add($"\t{block.Label}:");
                foreach (var cmd in block.Commands)
                    AddFormattedCommand<T>(lines, cmd, obj.StrList);
            }
            return lines;
        }

        private static void AddFormattedCommand<T>(List<string> lines, Command cmd, string[] strList) where T : Enum
        {
            var args = cmd.Arg;
            if (args.Length == 0)
                return; // jump label with no commands

            var cmdIndex = args[0];
            Debug.Assert(cmdIndex.argType == 0);

            var commandArgumentFormatted = string.Join(", ", args[1..].Select(z => z.Format(strList)));
            var line = $"\t\t{(T)(object)cmdIndex.data}({commandArgumentFormatted});";
            lines.Add(line);
        }
    }
}