using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityDPtools.GameText;

namespace UnityDPtools
{
    internal static class GameTextParser
    {
        public static void ParseFolder(string path)
        {
            var files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);
            foreach (var f in files)
                DumpJson(f);
        }

        private static void DumpJson(string file)
        {
            var text = File.ReadAllText(file);
            var obj = JsonConvert.DeserializeObject<GameJsonFile>(text);

            var dest = Path.ChangeExtension(file, ".txt")!;
            DumpObject(obj, file, dest);
        }

        private static void DumpObject(GameJsonFile gameJsonFile, string file, string dest)
        {
            //var name = gameJsonFile.m_Name;
            var entries = gameJsonFile.labelDataArray;
            var list = new List<string>(entries.Length);
            foreach (var e in entries)
                list.Add(GetLine(e));
            File.WriteAllLines(dest, list);
        }

        private static string GetLine(Labeldataarray l)
        {
            var aindex = l.arrayIndex;
            var lindex = l.labelIndex;
            var name = l.labelName;
            var test = l.wordDataArray;
            return $"{aindex}\t{lindex}\t{name}\t{string.Join("\t", test.Select(z => z.str))}";
        }

        public static string GetMessage(GameJsonFile gameJsonFile, string messageLabel)
        {
            foreach (var labelData in gameJsonFile.labelDataArray)
            {
                if (labelData.labelName == messageLabel)
                    return string.Join("\t", labelData.wordDataArray.Select(z => z.str));
            }

            throw new ArgumentException();
        }
    }
}
