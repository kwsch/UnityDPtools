using System.IO;
using Newtonsoft.Json;
using UnityDPtools.TV;

namespace UnityDPtools
{
    internal static class TVParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<TVJsonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, ".txt"), obj.TimeTable);
        }
    }
}
