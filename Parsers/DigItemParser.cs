using System.IO;
using Newtonsoft.Json;
using UnityDPtools.TV;

namespace UnityDPtools
{
    internal static class DigItemParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<DigItemFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, ".txt"), obj.Deposit);
        }
    }
}
