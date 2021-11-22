using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityDPtools.DprPlaceName;
using UnityDPtools.GameText;

namespace UnityDPtools.Parsers
{
    public static class PKHeXGameTextParser
    {
        public static void Dump(string dir)
        {
            T Get<T>(string file) => JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(dir, file)));

            var dprPlaceName = Get<DprPlaceNameJsonFile>("PlaceNameTable.json");
            var export = ParseUtil.GetPropertyTable(dprPlaceName.DprPlaceName);
            File.WriteAllLines(Path.Combine(dir, "placeNameTable.txt"), export);

            for (var i = 0; i < DPLanguages.Length; ++i)
            {
                var dpLang = DPLanguages[i];
                var pkLang = PKHexLanguages[i];

                var p0 = new Dictionary<int, string>();
                var p3 = new Dictionary<int, string>();
                var p4 = new Dictionary<int, string>();
                var p6 = new Dictionary<int, string>();

                foreach (var dprPlace in dprPlaceName.DprPlaceName)
                {
                    if (string.IsNullOrEmpty(dprPlace.MessageFile))
                        continue; // 40004 is empty.

                    var fileName = $"{dpLang}_{dprPlace.MessageFile}.json";
                    var path = Path.Combine("message", fileName);
                    var gameText = Get<GameJsonFile>(path);
                    var locName = GameTextParser.GetMessage(gameText, dprPlace.MessageLabel);

                    switch (dprPlace.Index / 10000)
                    {
                        case 0:
                            p0.Add(dprPlace.Index % 10000, locName);
                            break;
                        case 3:
                            p3.Add(dprPlace.Index % 10000, locName);
                            break;
                        case 4:
                            p4.Add(dprPlace.Index % 10000, locName);
                            break;
                        case 6:
                            p6.Add(dprPlace.Index % 10000, locName);
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }

                var baseDir = Path.Combine(dir, "pkhex");
                Directory.CreateDirectory(baseDir);
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_00000_{pkLang}.txt"), GetLines(p0));
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_30000_{pkLang}.txt"), GetLines(p3));
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_40000_{pkLang}.txt"), GetLines(p4));
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_60000_{pkLang}.txt"), GetLines(p6));
            }
        }

        private static List<string> GetLines(Dictionary<int, string> d)
        {
            var l = new List<string>();
            for (var i = 0; i <= d.Keys.Max(); ++i)
            {
                l.Add(d.ContainsKey(i) ? d[i] : string.Empty);
            }

            return l;
        }

        private static readonly string[] DPLanguages =
        {
            "english",
            "jpn",
            "german",
            "spanish",
            "french",
            "italian",
            "korean",
            "simp_chinese",
        };

        private static readonly string[] PKHexLanguages =
        {
            "en",
            "ja",
            "de",
            "es",
            "fr",
            "it",
            "ko",
            "zh",
        };
    }
}
