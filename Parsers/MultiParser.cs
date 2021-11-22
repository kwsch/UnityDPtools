using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PKHeX.Core;
using UnityDPtools.EggMove;
using UnityDPtools.Evolution;
using UnityDPtools.Learnset;
using UnityDPtools.Personal;

namespace UnityDPtools.Parsers
{
    public static class MultiParser
    {
        public static void Dump(string dir)
        {
            T Get<T>(string file) => JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(dir, file)));
            var pe = new ParseEnv
            {
                Personal = Get<PersonalJsonFile>("PersonalTable.json").Personal,
                Egg = Get<EggMoveJsonFile>("TamagoWazaTable.json").Data,
                Learn = Get<LevelUpJsonFile>("WazaOboeTable.json").WazaOboe,
                Evolve = Get<EvolutionJsonFile>("EvolveTable.json").Evolve,
            };

            var movenames = GameInfo.Strings.Move;
            var list = new List<string>();
            for (int i = 0; i < pe.Personal.Length; i++)
            {
                var p = pe.Personal[i];
                var spec = p.monsno;
                var form = p.form_index;

                var stats = $"{p.basic_hp}/{p.basic_atk}/{p.basic_def}/{p.basic_spatk}/{p.basic_spdef}/{p.basic_agi}";

                var line = $"{(Species)spec}{(form == 0 ? "" : $"-{form}")} - {stats} {(MoveType)p.type1}/{(MoveType)p.type2}";
                list.Add(line);

                var index = p.id;
                var evo = pe.Evolve[index];
                if (evo.ar.Length != 0)
                {
                    var x = new StringBuilder();
                    x.Append("Evolution(s): ");
                    list.Add(EvolutionParser.GetEvolutionString(evo.ar, x));
                }

                var egg = pe.Egg[index];
                if (egg.wazaNo.Length != 0)
                    list.Add($"Egg Moves: {string.Join(", ", egg.wazaNo.Select(z => movenames[z]))}");

                var ttIndex = new List<int>();
                for (int x = 0; x <4; x++)
                    if ((p.hiden_machine & (1 << x)) != 0)
                        ttIndex.Add(SpecialTutors_4[x]);
                if (ttIndex.Count != 0)
                    list.Add($"Special Tutor Moves: {string.Join(", ", ttIndex.Select(z => movenames[z]))}");

                var indexes = new List<int>();
                for (int m = 0; m < 100; m++)
                {
                    bool learnsTM = m switch
                    {
                        < 32 => (p.machine1 & (1 << (m - 0))) != 0,
                        < 64 => (p.machine2 & (1 << (m - 32))) != 0,
                        < 96 => (p.machine3 & (1 << (m - 64))) != 0,
                        _ => (p.machine4 & (1 << (m - 96))) != 0,
                    };
                    if (learnsTM)
                        indexes.Add(m);
                }
                if (indexes.Count != 0)
                    list.Add($"TM Moves: {string.Join(", ", indexes.Select(z => $"TM{z + 1:00} {movenames[TMIndexes[z + 1]]}"))}");

                var learn = pe.Learn[index];
                if (learn.ar.Length != 0)
                {
                    list.Add("Learned Moves:");
                    for (int m = 0; m < learn.ar.Length; m += 2)
                        list.Add($"\t{movenames[learn.ar[m + 1]]} @ {learn.ar[m]}");
                }

                list.Add("");
            }

            File.WriteAllLines(Path.Combine(dir, "dump.txt"), list);
        }

        private static readonly int[] TMIndexes =
        {
            5,
            264,
            337,
            352,
            347,
            46,
            92,
            258,
            339,
            331,
            526,
            241,
            269,
            58,
            59,
            63,
            113,
            182,
            240,
            202,
            219,
            605,
            76,
            231,
            85,
            87,
            89,
            490,
            91,
            94,
            247,
            280,
            104,
            115,
            351,
            53,
            188,
            201,
            126,
            317,
            332,
            259,
            263,
            521,
            156,
            213,
            168,
            211,
            285,
            503,
            315,
            355,
            411,
            412,
            206,
            362,
            374,
            451,
            203,
            406,
            409,
            261,
            405,
            417,
            153,
            421,
            371,
            278,
            416,
            397,
            148,
            444,
            419,
            86,
            360,
            14,
            446,
            244,
            555,
            399,
            157,
            404,
            214,
            523,
            398,
            138,
            447,
            207,
            365,
            369,
            164,
            430,
            433,
            15,
            19,
            57,
            70,
            432,
            249,
            127,
            431,
            14,
            34,
            53,
            56,
            57,
            58,
            59,
            67,
            85,
            87,
            89,
            94,
            97,
            116,
            118,
            126,
            127,
            133,
            141,
            161,
            164,
            179,
            188,
            191,
            200,
            473,
            203,
            214,
            224,
            226,
            227,
            231,
            242,
            247,
            248,
            253,
            257,
            269,
            271,
            276,
            285,
            299,
            304,
            315,
            322,
            330,
            334,
            337,
            339,
            347,
            348,
            349,
            360,
            370,
            390,
            394,
            396,
            398,
            399,
            402,
            404,
            405,
            406,
            408,
            411,
            412,
            413,
            414,
            417,
            428,
            430,
            437,
            438,
            441,
            442,
            444,
            446,
            447,
            482,
            484,
            486,
            492,
            500,
            502,
            503,
            526,
            528,
            529,
            535,
            542,
            583,
            599,
            605,
            663,
            667,
            675,
            676,
            706,
            710,
            776,
        };

        internal static readonly int[] SpecialTutors_4 =
        {
            (int)Move.FrenzyPlant,
            (int)Move.BlastBurn,
            (int)Move.HydroCannon,
            (int)Move.DracoMeteor,
        };
    }

    public class ParseEnv
    {
        public Personal.Personal[] Personal { get; set; }
        public EggMove.Datum[] Egg { get; set; }
        public Learnset.Wazaoboe[] Learn { get; set; }
        public Evolution.Evolve[] Evolve { get; set; }
    }
}
