using System.IO;
using Newtonsoft.Json;
using UnityDPtools.Formats;

namespace UnityDPtools
{
    internal static class TrainerParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<TrainerJsonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Trainerdata)}.txt"), obj.TrainerData);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Trainerpoke)}.txt"), obj.TrainerPoke);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Trainertype)}.txt"), obj.TrainerType);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Trainerrematch)}.txt"), obj.TrainerRematch);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Sealtemplate)}.txt"), obj.SealTemplate);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Skirtgraphicschara)}.txt"), obj.SkirtGraphicsChara);
        }
    }
}
