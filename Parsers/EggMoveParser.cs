using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PKHeX.Core;
using UnityDPtools.EggMove;

namespace UnityDPtools
{
    internal static class EggMoveParser
    {
        public static void Parse(string path)
        {
            var text = File.ReadAllText(path);
            var obj = JsonConvert.DeserializeObject<EggMoveJsonFile>(text);
            Parse(Path.ChangeExtension(path, ".txt"), obj.Data);
            DumpPickle(Path.ChangeExtension(path, "pkl"), obj.Data);
        }

        private static void Parse(string path, Datum[] entries)
        {
            var lines = new List<string>(entries.Length);
            foreach (var e in entries)
                lines.Add(GetText(e));
            File.WriteAllLines(path, lines);
        }

        private static string GetText(Datum datum)
        {
            return $"{datum.no}\t{datum.formNo}\t{string.Join(',', datum.wazaNo)}";
        }

        private static void DumpPickle(string path, Datum[] table)
        {
            var learnsets = table.Select(GetPack).ToArray();
            var pickle = MiniUtil.PackMini(learnsets, "bs");
            File.WriteAllBytes(path, pickle);
        }

        private static byte[] GetPack(Datum egg)
        {
            var moves = egg.wazaNo.Select(z => (ushort)z).ToArray();

            moves = (Species)egg.no switch
            {
                // Not available until HOME is out.
                Species.Snorlax   => moves.Where(z => z is not (ushort)Move.PowerUpPunch).ToArray(),
                Species.Taillow   => moves.Where(z => z is not (ushort)Move.Boomburst).ToArray(),
                Species.Plusle    => moves.Where(z => z is not (ushort)Move.TearfulLook).ToArray(),
                Species.Minun     => moves.Where(z => z is not (ushort)Move.TearfulLook).ToArray(),
                Species.Luvdisc   => moves.Where(z => z is not (ushort)Move.HealPulse).ToArray(),
                Species.Starly    => moves.Where(z => z is not (ushort)Move.Detect).ToArray(),
                Species.Chatot    => moves.Where(z => z is not (ushort)Move.Boomburst and not (ushort)Move.Encore).ToArray(),
                Species.Spiritomb => moves.Where(z => z is not (ushort)Move.FoulPlay).ToArray(),
                _ => moves,
            };

            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);
            bw.Write((short)egg.formNo);
            bw.Write((short)moves.Length);
            foreach (var move in moves)
                bw.Write(move);

            return ms.ToArray();
        }
    }
}
