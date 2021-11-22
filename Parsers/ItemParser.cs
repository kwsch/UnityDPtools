using System.IO;
using Newtonsoft.Json;
using UnityDPtools.Item;

namespace UnityDPtools
{
    internal static class ItemParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<ItemJsonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, ".txt"), obj.Item);
            ParseUtil.Parse(Path.ChangeExtension(path, "tm.txt"), obj.WazaMachine);
        }
    }
}
