using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityDPtools.DprPlaceName;
using UnityDPtools.GameText;
using UnityDPtools.MapInfo;

namespace UnityDPtools.Parsers
{
    public static class PKHeXGameTextParser
    {
        public static void Dump(string dir)
        {
            T Get<T>(string file) => JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(dir, file)));

            var dprPlaceName = Get<DprPlaceNameJsonFile>("PlaceNameTable.json");
            var mapZone = Get<MapInfoJson>("MapInfo.json").ZoneData;
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
                var subFileName = Path.Combine("message", $"{dpLang}_dp_fld_areaname_display.json");
                var subText = Get<GameJsonFile>(subFileName);

                foreach (var dprPlace in dprPlaceName.DprPlaceName)
                {
                    if (string.IsNullOrEmpty(dprPlace.MessageFile))
                        continue; // 40004 is empty.

                    var fileName = $"{dpLang}_{dprPlace.MessageFile}.json";
                    var path = Path.Combine("message", fileName);
                    var gameText = Get<GameJsonFile>(path);
                    var locName = GameTextParser.GetMessage(gameText, dprPlace.MessageLabel);

                    AddLocationName(dprPlace.Index, locName);
                }

                // Locations 648-657 are not present in the DprPlaceName.json, but they are in the MapInfo. Add them manually.
                for (int l = 648; l < 658; l++)
                    AddLocationName(l, p0[250]);

                var baseDir = Path.Combine(dir, "pkhex");
                Directory.CreateDirectory(baseDir);
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_00000_{pkLang}.txt"), GetLines(p0));
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_30000_{pkLang}.txt"), GetLines(p3));
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_40000_{pkLang}.txt"), GetLines(p4));
                File.WriteAllLines(Path.Combine(baseDir, $"text_bdsp_60000_{pkLang}.txt"), GetLines(p6));

                void AddLocationName(int index, string locName)
                {
                    if (index < 1000)
                    {
                        var subLocation = mapZone[index].MSLabel;
                        if (!string.IsNullOrWhiteSpace(subLocation))
                        {
                            var subLocationName = GameTextParser.GetMessage(subText, subLocation);
                            if (subLocationName != locName)
                                locName = $"{locName} ({subLocationName})";
                        }
                    }

                    var table = (index / 10_000) switch
                    {
                        0 => p0,
                        3 => p3,
                        4 => p4,
                        6 => p6,
                        _ => throw new ArgumentException(),
                    };
                    table.Add(index % 10_000, locName);
                }
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
