using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using UnityDPtools.Evolution;

namespace UnityDPtools
{
    internal static class EvolutionParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<EvolutionJsonFile>(text);
            Parse(Path.ChangeExtension(path, ".txt"), obj.Evolve);
            Dump(Path.ChangeExtension(path, ".pkl"), obj.Evolve);
        }

        private static void Dump(string path, Evolve[] objEvolve)
        {
            var data = objEvolve.Select((z, i) => z.Convert(i)).ToArray();
            var pickle = MiniUtil.PackMini(data, "bs");
            File.WriteAllBytes(path, pickle);
        }

        private static void Parse(string path, Evolve[] entries)
        {
            var lines = new List<string>(entries.Length);
            foreach (var e in entries)
                lines.Add(GetText(e));
            File.WriteAllLines(path, lines);
        }

        private static string GetText(Evolve datum)
        {
            var sb = new StringBuilder();
            sb.Append(datum.id).Append('\t');
            var ar = datum.ar;
            return GetEvolutionString(ar, sb);
        }

        public static string GetEvolutionString(int[] ar, StringBuilder sb)
        {
            for (int i = 0; i < ar.Length; i += 5)
            {
                var slice = ar[i..(i + 5)];
                var text = string.Join(',', slice);
                sb.Append(text).Append('\t');
            }

            return sb.ToString().TrimEnd('\t');
        }
    }
}
