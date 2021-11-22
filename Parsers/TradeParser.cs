using System.IO;
using Newtonsoft.Json;
using UnityDPtools.Trade;

namespace UnityDPtools
{
    internal static class TradeParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<TradeJsonFile>(text);
            Parse(Path.ChangeExtension(path, ".txt"), obj.data);
        }

        private static void Parse(string path, Datum[] table)
        {
            var lines = ParseUtil.GetPropertyTable(table);
            File.WriteAllLines(path, lines);
        }
    }
}