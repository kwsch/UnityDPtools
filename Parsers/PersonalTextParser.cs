using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityDPtools.Personal;

namespace UnityDPtools
{
    internal static class PersonalTextParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<PersonalJsonFile>(text);
            var table = obj.Personal;
            ParseUtil.Parse(Path.ChangeExtension(path, ".txt"), table);

            CreatePersonalBinary(Path.ChangeExtension(path, null), table);
        }

        private static void CreatePersonalBinary(string path, Personal.Personal[] table)
        {
            var data = table.Select(z => z.CreatePersonal()).Select(z => z.Write()).SelectMany(z => z).ToArray();
            File.WriteAllBytes(path, data);
        }
    }
}
