using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityDPtools.Waza;

namespace UnityDPtools
{
    internal static class WazaParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<WazaJsonFile>(text);
            Parse(Path.ChangeExtension(path, ".txt"), obj.Waza);

            ParseStubbed(Path.ChangeExtension(path, "stub"), obj.Yubiwohuru);
        }

        private static void ParseStubbed(string path, Yubiwohuru[] objYubiwohuru)
        {
            var x = objYubiwohuru[0];
            var max = x.wazaNos.Max();
            var stubbed = Enumerable.Range(1, max).Where(z => !x.wazaNos.Contains(z));
            var text = string.Join(", ", stubbed.Select(z => $"{z:000}"));
            File.WriteAllText(path, text);
        }

        private static void Parse(string path, Waza.Waza[] table)
        {
            var lines = ParseUtil.GetPropertyTable(table);
            File.WriteAllLines(path, lines);
        }
    }
}
