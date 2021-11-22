using System.IO;
using Newtonsoft.Json;
using UnityDPtools.Tower;

namespace UnityDPtools
{
    internal static class TowerParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<TowerTrainerJsonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Trainerdata)}.txt"), obj.TrainerData);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Trainerpoke)}.txt"), obj.TrainerPoke);
        }
    }
}
