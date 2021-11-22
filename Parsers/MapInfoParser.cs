using System.IO;
using Newtonsoft.Json;
using UnityDPtools.MapInfo;

namespace UnityDPtools.Parsers
{
    public static class MapInfoParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<MapInfoJson>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Zonedata)}.txt"), obj.ZoneData);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Camera)}.txt"), obj.Camera);
        }
    }
}
