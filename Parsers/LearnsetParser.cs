using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityDPtools.Learnset;

namespace UnityDPtools
{
    internal static class LearnsetParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<LevelUpJsonFile>(text);
            var table = obj.WazaOboe;
            Parse(Path.ChangeExtension(path, ".txt"), table);
            DumpPickle(Path.ChangeExtension(path, ".pkl"), table);
        }

        private static void Parse(string path, Wazaoboe[] table)
        {
            var lines = new List<string>(table.Length);
            foreach (var t in table)
            {
                var sb = new StringBuilder();
                sb.Append(t.id).Append('\t');
                for (int i = 0; i < t.ar.Length; i += 2)
                    sb.Append(t.ar[i + 1]).Append(" @ ").Append(t.ar[i]).Append('\t');
                lines.Add(sb.ToString().TrimEnd('\t'));
            }
            File.WriteAllLines(path, lines);
        }

        private static void DumpPickle(string path, Wazaoboe[] table)
        {
            var learnsets = table.Select(GetPack).ToArray();
            var pickle = MiniUtil.PackMini(learnsets, "bs");
            File.WriteAllBytes(path, pickle);
        }

        private static byte[] GetPack(Wazaoboe learnset)
        {
            var levels = learnset.ar.Where((_, i) => i % 2 == 0).Select(z => (ushort)z).ToArray();
            var moves = learnset.ar.Where((_, i) => i % 2 == 1).Select(z => (ushort)z).ToArray();
            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);
            for (int i = 0; i < levels.Length; i++)
            {
                bw.Write(moves[i]);
                bw.Write(levels[i]);
            }
            bw.Write(uint.MaxValue); // FF eof
            return ms.ToArray();
        }
    }
}
