using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PKHeX.Core;
using UnityDPtools.Formats;
using UnityDPtools.MapInfo;
using UnityDPtools.Underground.Map;
using UnityDPtools.Underground;
using UnityDPtools.Underground.Poke;
using UnityDPtools.Underground.Statue;
using Sheet1 = UnityDPtools.Underground.Sheet1;
using Table = UnityDPtools.Underground.Table;

namespace UnityDPtools
{
    internal static class UndergroundParser
    {
        public static void ParseItemList(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UgItemTableJsonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.table);
        }

        public static void ParseSpecial(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundJsonFile>(text);
            Parse2(Path.ChangeExtension(path, "named.csv"), obj.Sheet1);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.Sheet1);
        }

        public static void ParseMiniMap(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundMapJsonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "map.csv"), obj.Map);
            ParseUtil.Parse(Path.ChangeExtension(path, "icon.csv"), obj.Icon);
            ParseUtil.Parse(Path.ChangeExtension(path, "group.csv"), obj.MapGroup);
        }

        public static void ParseStatue(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<StatueJson>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.table);
        }

        private static void Parse2(string changeExtension, Sheet1[] arr)
        {
            var lines = arr.Select(z => $"{z.id},{z.version},{GameInfo.Strings.Species[z.monsno]},{z.Dspecialrate},{z.Pspecialrate}");
            File.WriteAllLines(changeExtension, lines);
        }

        public static void ParseEncount(string path)
        {
            if (!File.Exists(path))
                return;
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundEncountFile>(text);
            Parse2(Path.ChangeExtension(path, "named.csv"), obj.table);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.table);
        }

        private static void Parse2(string changeExtension, Table[] arr)
        {
            var lines = arr.Select(z => $"{z.zukanflag},{z.version},{GameInfo.Strings.Species[z.monsno]}");
            File.WriteAllLines(changeExtension, lines);
        }

        public static void ParseLevel(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundLevelFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.Data);
        }

        public static void ParseManager(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundField>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), new[] {obj});
        }

        public static void ParseRandMark(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundRand>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.table);
        }

        public static void ParsePos(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundPositionFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.Sheet1);
        }

        public static void ParsePoke(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundPokemonFile>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.table);
        }

        public static void ParseEggIgnore(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<UndergroundEggIgnore>(text);
            ParseUtil.Parse(Path.ChangeExtension(path, "csv"), obj.Sheet1);
            Parse2(Path.ChangeExtension(path, "named.csv"), obj.Sheet1);
        }

        private static void Parse2(string changeExtension, IgnoreInfo[] arr)
        {
            var lines = arr.Select(z => $"{GameInfo.Strings.Species[z.MonsNo]},{string.Join(',', z.Waza.Where(w => w != 0).Select(m => GameInfo.Strings.Move[m]))}");
            File.WriteAllLines(changeExtension, lines);
        }

        public static void MakePickle(string mapInfoPath, string specialPath, string randPath, string noEggPath, string rootPath, string game)
        {
            var tm = File.ReadAllText(mapInfoPath);
            var ts = File.ReadAllText(specialPath);
            var te = File.ReadAllText(randPath);
            var tn = File.ReadAllText(noEggPath);

            var om = JsonConvert.DeserializeObject<MapInfoJson>(tm);
            var os = JsonConvert.DeserializeObject<UndergroundJsonFile>(ts);
            var oe = JsonConvert.DeserializeObject<UndergroundEggIgnore>(te);
            var on = JsonConvert.DeserializeObject<UndergroundRand>(tn);

            var exclude = game == "bd" ? 3 : 2;

            var result = new List<byte[]>();
            foreach (var z in om.ZoneData)
            {
                if (z.LandmarkType == -1)
                    continue;

                var bytes = GetTableForLocation(rootPath, on.table, z.ZoneID, z.LandmarkType, os.Sheet1, exclude);
                result.Add(bytes);
            }

            var pack = MiniUtil.PackMini(result.ToArray(), "bs");
            File.WriteAllBytes(Path.Combine(rootPath, $"encounter_{game}_underground.pkl"), pack);

            var ignore = oe.Sheet1.Select(GetDictionaryEntry);
            File.WriteAllLines(Path.Combine(rootPath, "ignoreEggMoves.txt"), ignore);

            static string GetDictionaryEntry(IgnoreInfo z)
            {
                var moves = string.Join(',', z.Waza.Where(x => x != 0).Select(x => x.ToString("000")));
                return $"{{{z.MonsNo:000}, new[] {{{moves}}}}}, // {GameInfo.Strings.Species[z.MonsNo]}";
            }
        }

        private static readonly int[] EastZonesUG =
        {
            554, 556, 557, 558, 559, 560, 561, 562, 563, 564, 565, 566, 579, 591, 592, 593, 594, 595, 596, 597, 598,
            599, 600, 601, 602, 603, 604, 605, 606, 607, 608, 609, 610, 612, 616, 617,
        };

        private static readonly int[][] AreaZones =
        {
            new[] { 526, 527, 528, 529, 530, 580, 581, 582, 583, 584, 585, 586, 587, 588, 589, 615 },
            new[] { 536, 537, 538, 539, 540, 541, 542, 600, 601, 602, 603, 604, 605, 606, 607, 608, 609, 610, 617 },
            new[] { 508, 509, 510, 511, 512, 513, 514, 515, 516, 517, 543, 544, 545, 546, 547, 548, 549, 550, 551, 552, 553, 554, 555, 556, 557, 558, 559, 560, 561, 562, 563, 564, 565, 566, 611, 612 },
            new[] { 525, 578, 579, 614 },
            new[] { 518, 519, 520, 521, 522, 523, 524, 567, 568, 569, 570, 571, 572, 573, 574, 575, 576, 577, 613 },
            new[] { 531, 532, 533, 534, 535, 590, 591, 592, 593, 594, 595, 596, 597, 598, 599, 616 },
        };

        private static readonly int[] WaterSpawns =
        {
            (int)Species.Tentacool,
            (int)Species.Tentacruel,
            (int)Species.Horsea,
            (int)Species.Chinchou,
            (int)Species.Lanturn,
            (int)Species.Qwilfish,
            (int)Species.Surskit,
            (int)Species.Carvanha,
            (int)Species.Barboach,
            (int)Species.Whiscash,
            (int)Species.Mantyke,
        };

        private static int GetArea(int zone)
        {
            int ctr = 1;
            foreach (var table in AreaZones)
            {
                if (table.Contains(zone))
                    return ctr;
                ctr++;
            }
            throw new ArgumentOutOfRangeException(nameof(zone));
        }

        private static byte[] GetTableForLocation(string rootPath, Limits[] meta, int location, int landmark, Sheet1[] allSpecial, int exclude)
        {
            var ugf = meta.First(x => x.id == landmark);
            var regularName = ugf.FileName;
            var path = Path.Combine(rootPath, $"{regularName}.json");

            var tr = File.ReadAllText(path);
            var or = JsonConvert.DeserializeObject<UndergroundEncountFile>(tr);

            var header = GetHeader(location, SlotType.Grass);
            var list = new List<int>();
            bool isEast = EastZonesUG.Contains(location);
            var sgForm = isEast ? 1 : 0;
            var area = GetArea(location);
            foreach (var t in or.table.Where(z => z.version != exclude))
            {
                if (t.monsno == 0)
                    continue;

                var form = GetForm(t.monsno, sgForm);
                // If you obtain the national dex, the logic short circuits and satisfies the progress requirement.
                var minThresh = GetMinThreshold(area, 1);
                // Surf spawns still require a level threshold of 5 to access surf.
                if (WaterSpawns.Contains(t.monsno))
                    minThresh = Math.Max(minThresh, 5);
                for (int i = minThresh; i <= 9; i++)
                {
                    var (min, max) = GetRange(i);
                    var slot = new EncodeSlot { Species = t.monsno, Form = form, Min = min, Max = max };
                    list.Add(slot.Encode());
                }
            }

            foreach (var t in allSpecial.Where(z => z.id == landmark && z.version != exclude))
            {
                if (t.monsno == 0)
                    continue;

                var form = GetForm(t.monsno, sgForm);
                var minThresh = GetMinThreshold(area, 1);
                for (int i = minThresh; i <= 9; i++)
                {
                    var (min, max) = GetRange(i);
                    var slot = new EncodeSlot { Species = t.monsno, Form = form, Min = min, Max = max };
                    list.Add(slot.Encode());
                }
            }

            var unique = new List<int>(list.Distinct());
            unique.Insert(0, header);
            return unique.SelectMany(BitConverter.GetBytes).ToArray();
        }

        private static int GetForm(int species, int sgForm)
        {
            return species is (int)Species.Shellos or (int)Species.Gastrodon ? sgForm : 0;
        }

        private class EncodeSlot
        {
            public int Species;
            public int Form;
            public int Min;
            public int Max;

            public int Encode() => Species | (Form << 11) | (Min << 16) | (Max << 24);
        }

        private static int GetHeader(int location, SlotType type) => location | (((int)type) << 16);

        private static int GetMinThreshold(int area, int progressRequired)
        {
            var ma = GetMinThresholdArea(area);
            var mp = GetMinThresholdProgress(progressRequired);
            return Math.Max(ma, mp);
        }

        private static (int Min, int Max) GetRange(int threshold) => Thresholds[threshold - 1];

        private static readonly (int Min, int Max)[] Thresholds =
        {
            (16, 20),
            (25, 29),
            (29, 33),
            (33, 37),
            (36, 40),
            (39, 43),
            (42, 46),
            (50, 55),
            (58, 63),
        };

        private static int GetMinThresholdArea(int area) => area switch
        {
            1 => 6, // NW Top Left Area
            2 => 8, // NE Top Right Area
            3 => 1, // Middle Area (not Center)
            4 => 4, // Center Area
            5 => 1, // SW Bottom Left Area
            6 => 3, // SE Bottom Right Area
            _ => throw new ArgumentOutOfRangeException(nameof(area)),
        };

        private static int GetMinThresholdProgress(int progressRequired) => progressRequired switch
        {
            1 => 1, // No requirement
            2 => 2, // Strength - minimum 2 badges
            3 => 2, // Defog - minimum 2 badges
            4 => 7, // Icicle Badge -badge #7
            5 => 8, // Waterfall - minimum 8 badges
            6 => 1, // National Dex - available without requirement if you complete Sinnoh Dex early + reach Eterna City
            _ => throw new ArgumentOutOfRangeException(nameof(progressRequired)),
        };
    }
}
