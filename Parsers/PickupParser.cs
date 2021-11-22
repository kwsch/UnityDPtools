using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityDPtools.Pickup;

namespace UnityDPtools
{
    internal static class PickupParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<PickupJsonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, ".txt"), obj.MonoHiroi);
            Parse2(Path.ChangeExtension(path, "csv"), obj.MonoHiroi);
        }

        private static void Parse2(string changeExtension, Monohiroi[] arr)
        {
            var lines = arr.Select(z => $"{PKHeX.Core.GameInfo.Strings.Item[z.ID]},{string.Join(',', z.Ratios)}");
            File.WriteAllLines(changeExtension, lines);
        }
    }
}
