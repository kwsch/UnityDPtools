using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PKHeX.Core;
using UnityDPtools.Encounter;

namespace UnityDPtools
{
    internal static class EncounterParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<Encounters>(text);

            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Table)}.txt"), obj.table);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Honeytree)}.txt"), obj.honeytree);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Legendpoke)}.txt"), obj.legendpoke);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Mistu)}.txt"), obj.mistu);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Mvpoke)}.txt"), obj.mvpoke);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Safari)}.txt"), obj.safari);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Urayama)}.txt"), obj.urayama);
            ParseUtil.Parse(Path.ChangeExtension(path, $"{nameof(Zui)}.txt"), obj.zui);

            var pklFile = Path.ChangeExtension(path, "pkl")
                .Replace("FieldEncountTable", "encounter")
                .Replace("encounter_d", "encounter_bd")
                .Replace("encounter_p", "encounter_sp");
            DumpPickle(pklFile, obj, "bs", path.Contains("FieldEncountTable_d"));
        }

        public static void ParseExclusives(string d, string p)
        {
            var textd = File.ReadAllText(d);
            var objd = JsonConvert.DeserializeObject<Encounters>(textd);
            var textp = File.ReadAllText(p);
            var objp = JsonConvert.DeserializeObject<Encounters>(textp);

            var ad = available(objd);
            var ap = available(objp);

            var xd = ad.Except(ap).ToArray();
            var xp = ap.Except(ad).ToArray();

            File.WriteAllText(Path.ChangeExtension(d, "exclusive.txt"), string.Join('\n', xd.Select(z => GameInfo.Strings.Species[z])));
            File.WriteAllText(Path.ChangeExtension(p, "exclusive.txt"), string.Join('\n', xp.Select(z => GameInfo.Strings.Species[z])));

            static int[] available(Encounters game) => game.legendpoke.Select(z => z.monsNo)
                .Concat(game.safari.Select(z => z.MonsNo))
                .Concat(game.urayama.Select(z => z.monsNo))
                .Concat(game.table.SelectMany(z => z.day.Select(x => x.monsNo)
                    .Concat(z.boro_mons.Select(x => x.monsNo))
                    .Concat(z.ground_mons.Select(x => x.monsNo))
                    .Concat(z.water_mons.Select(x => x.monsNo))
                    .Concat(z.swayGrass.Select(x => x.monsNo))
                    .Concat(z.night.Select(x => x.monsNo))
                    .Concat(z.gbaEme.Select(x => x.monsNo))
                    .Concat(z.gbaFire.Select(x => x.monsNo))
                    .Concat(z.gbaRuby.Select(x => x.monsNo))
                    .Concat(z.gbaLeaf.Select(x => x.monsNo))
                    .Concat(z.gbaSapp.Select(x => x.monsNo))
                    .Concat(z.sugoi_mons.Select(x => x.monsNo))
                    .Concat(z.ii_mons.Select(x => x.monsNo))
                )).Distinct().Where(z => z != 0).ToArray();
        }

        private static void DumpPickle(string path, Encounters raw, string identifier, bool diamond)
        {
            byte[][] slotTables = ReadTable(raw.table, raw.zui, diamond);

            var pack = MiniUtil.PackMini(slotTables, identifier);
            File.WriteAllBytes(path, pack);
        }

        private static byte[][] ReadTable(IReadOnlyList<Table> rawTable, IReadOnlyList<Zui> rawZui, bool diamond)
        {
            var list = new List<byte[]>();
            foreach (var t in rawTable)
            {
                if (t.zoneID == -1)
                    continue;

                var unown = t.AnnoonTable;
                if (unown[1] != 0)
                {
                    var zui = rawZui[unown[1] - 1];
                    var result = GetUnownTable(t.zoneID, t.ground_mons, zui.form); // all slots same
                    list.Add(result);
                }
                else
                {
                    var grass = t.ground_mons.Concat(t.tairyo).Concat(t.day).Concat(t.night).Concat(t.swayGrass);
                    list.Add(GetLocationTable(t.zoneID, grass, SlotType.Grass, t.FormProb));
                    list.Add(GetLocationTable(t.zoneID, t.water_mons, SlotType.Surf, t.FormProb));
                    list.Add(GetLocationTable(t.zoneID, t.boro_mons, SlotType.Old_Rod, t.FormProb));
                    list.Add(GetLocationTable(t.zoneID, t.ii_mons, SlotType.Good_Rod, t.FormProb));
                    list.Add(GetLocationTable(t.zoneID, t.sugoi_mons, SlotType.Super_Rod, t.FormProb));
                }

                AddSpecialTables(list, t, diamond);
            }

            // Some honey trees are in locations without encounter tables.
            // Since we've iterated over all the tables, some locations like Floaroma Meadow (253) still need to be emitted.
            var locationLessTrees = Array.FindAll(Honey, z => rawTable.All(t => t.zoneID != z));
            foreach (var extraTree in locationLessTrees)
                AddHoney(list, extraTree, diamond ? Mistu_D : Mistu_P);

            // Feebas is handled in a special way. Just slap in a table for the Mt Coronet zone.
            list.Add(GetFeebasTable());

            return list.OrderBy(z => BitConverter.ToInt16(z, 0)).ToArray();
        }

        private static byte[] GetFeebasTable()
        {
            var list = new List<int>
            {
                GetHeader(215, SlotType.Super_Rod),
                new EncodeSlot { Species = (int)Species.Feebas, Min = 10, Max = 20 }.Encode()
            };
            return list.SelectMany(BitConverter.GetBytes).ToArray();
        }

        private static readonly int[] Trophy = { 35, 39, 52, 113, 133, 137, 173, 174, 183, 298, 311, 312, 351, 438, 439, 440 };

        private static readonly int[] Marsh =
        {
                 453, 451, 455,                                    453, 451, 455,      55,
                 453, 451, 455,                          315, 397, 183, 298,      194, 55,
            397, 453, 451, 455, 195, 399, 400, 194, 298, 315, 397, 453, 451, 455, 315, 55,

                 453, 451, 455,                                    453, 451, 455,      55,
                 453, 451, 455,                          315, 397, 454, 452,      102, 55,
            397, 453, 451, 455, 193, 285, 046, 115, 316, 315, 397, 453, 451, 455, 315, 55,
        };

        private static readonly int[] Honey =
        {
            359, //	00 Route 205 Floaroma
            361, //	01 Route 205 Eterna
            362, //	02 Route 206
            364, //	03 Route 207
            365, //	04 Route 208
            367, //	05 Route 209
            373, //	06 Route 210 Solaceon
            375, //	07 Route 210 Celestic
            378, //	08 Route 211
            379, //	09 Route 212 Hearthome
            383, //	10 Route 212 Pastoria
            385, //	11 Route 213
            392, //	12 Route 214
            394, //	13 Route 215
            400, //	14 Route 218
            404, //	15 Route 221
            407, //	16 Route 222
            197, //	17 Valley Windworks
            199, //	18 Eterna Forest
            201, //	19 Fuego Ironworks
            253, //	20 Floaroma Meadow
        };

        private static readonly int[] Mistu_D =
        {
            265,
            266, // d
            415,
            412,
            420,
            190,
            214,
            265,
            446,
        };
        private static readonly int[] Mistu_P =
        {
            265,
            268, // p
            415,
            412,
            420,
            190,
            214,
            265,
            446,
        };

        private static void AddSpecialTables(List<byte[]> list, Table table, bool diamond)
        {
            if (table.zoneID == 0297)
                AddTrophy(list, table, Trophy);
            if (table.zoneID is (>= 219 and <= 224))
                AddMarsh(list, table, Marsh);
            if (Honey.Contains(table.zoneID))
                AddHoney(list, table.zoneID, diamond ? Mistu_D : Mistu_P);
        }

        private static void AddHoney(List<byte[]> list, int location, int[] species)
        {
            var header = GetHeader(location, SlotType.HoneyTree);
            var tt = new List<int> { header };

            foreach (var t in species.Distinct())
            {
                var slot = new EncodeSlot { Species = t, Form = 0, Min = 5, Max = 15 };
                tt.Add(slot.Encode());
            }
            list.Add(tt.SelectMany(BitConverter.GetBytes).ToArray());
        }

        private static void AddMarsh(List<byte[]> list, Table table, int[] species)
        {
            var header = GetHeader(table.zoneID, SlotType.Grass);
            var tt = new List<int> { header };

            // Slot7 level is same as slot6!
            var slot6 = table.ground_mons[6];
            foreach (var t in species.Distinct())
            {
                var s6 = new EncodeSlot { Species = t, Form = 0, Max = slot6.maxlv, Min = slot6.minlv };
                tt.Add(s6.Encode());
            }
            list.Add(tt.SelectMany(BitConverter.GetBytes).ToArray());
        }

        private static void AddTrophy(List<byte[]> list, Table table, int[] species)
        {
            var trophyHeader = GetHeader(table.zoneID, SlotType.Grass);
            var tt = new List<int> { trophyHeader };

            var slot6 = table.ground_mons[6];
            var slot7 = table.ground_mons[7];
            foreach (var t in species)
            {
                var s6 = new EncodeSlot { Species = t, Form = 0, Max = slot6.maxlv, Min = slot6.minlv };
                var s7 = new EncodeSlot { Species = t, Form = 0, Max = slot7.maxlv, Min = slot7.minlv };
                tt.Add(s6.Encode());
                tt.Add(s7.Encode());
            }
            list.Add(tt.SelectMany(BitConverter.GetBytes).ToArray());
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

        private static byte[] GetUnownTable(int location, IEnumerable<MonsLv> slots, int[] zui)
        {
            var header = GetHeader(location, SlotType.Grass);
            var list = new List<int>();
            foreach (var t in slots)
            {
                if (t.monsNo == 0)
                    continue;
                for (int form = 0; form < zui.Length; form++)
                {
                    var flag = zui[form];
                    if (flag == 0)
                        continue; // no form
                    var slot = new EncodeSlot { Species = t.monsNo, Form = form, Max = t.maxlv, Min = t.minlv };
                    list.Add(slot.Encode());
                }
            }
            var unique = new List<int>(list.Distinct());
            unique.Insert(0, header);
            return unique.SelectMany(BitConverter.GetBytes).ToArray();
        }

        private static byte[] GetLocationTable(int location, IEnumerable<MonsLv> slots, SlotType type, int[] formProb)
        {
            var list = new List<int>();
            var header = GetHeader(location, type);
            foreach (var t in slots)
            {
                if (t.monsNo == 0)
                    continue;
                var slot = new EncodeSlot
                {
                    Species = t.monsNo,
                    Form = (t.monsNo is ((int)Species.Gastrodon or (int)Species.Shellos) && formProb[0] != 0) ? 1 : 0,
                    Min = t.minlv,
                    Max = t.maxlv,
                };
                list.Add(slot.Encode());
            }
            var unique = new List<int>(list.Distinct());
            unique.Insert(0, header);
            return unique.SelectMany(BitConverter.GetBytes).ToArray();
        }
    }
}
