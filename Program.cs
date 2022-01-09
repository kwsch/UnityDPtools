using System.IO;
using UnityDPtools.Parsers;
using UnityDPtools.Scripts;

namespace UnityDPtools
{
    internal static class Program
    {
        // modify me to fit your needs
        private const string root = @"D:\bdsp\v111\MonoBehaviour";

        private static string Get(string path) => Path.Combine(root, path);

        private static void Main(string[] args)
        {
            string dig = Get("DepositItemRawData.json");
            DigItemParser.Parse(dig);

            string mapInfo = Get("MapInfo.json");
            MapInfoParser.Parse(mapInfo);

            string personal = Get("PersonalTable.json");
            PersonalTextParser.Parse(personal);

            string personalExtra = Get("AddPersonalTable.json");
            PersonalTextParser.ParseExtra(personalExtra);

            string map = Get("UgMiniMap.json");
            UndergroundParser.ParseMiniMap(map);
            string statue = Get("StatueEffectRawData.json");
            UndergroundParser.ParseStatue(statue);

            ExportUndergroundTables(mapInfo);

            TVParser.Parse(Get("TvSchedule.json"));

            TrainerParser.Parse(Get("TrainerTable.json"));
            TowerParser.Parse(Get("TowerTrainerTable.json"));

            string enc_d = Get("FieldEncountTable_d.json");
            EncounterParser.Parse(enc_d);
            string enc_p = Get("FieldEncountTable_p.json");
            EncounterParser.Parse(enc_p);

            string trade = Get("LocalKoukanData.json");
            TradeParser.Parse(trade);

            string item = Get("ItemTable.json");
            ItemParser.Parse(item);

            string wo = Get("WazaOboeTable.json");
            LearnsetParser.Parse(wo);

            string waza = Get("WazaTable.json");
            WazaParser.Parse(waza);

            string ev = Get("EvolveTable.json");
            EvolutionParser.Parse(ev);

            string em = Get("TamagoWazaTable.json");
            EggMoveParser.Parse(em);

            EncounterParser.ParseExclusives(enc_d, enc_p);
            ExportLarge();
        }

        private static void ExportLarge()
        {
            PKHeXGameTextParser.Dump(root);
            MultiParser.Dump(root);
            ScriptPrinter.Dump<ScriptCommand_1_1>(Get("scr"));

            string path = Get("message");
            GameTextParser.ParseFolder(path);
        }

        private static void ExportUndergroundTables(string mapInfo)
        {
            var items = Get("UgItemTable.json");
            UndergroundParser.ParseItemList(items);

            var randMark = Get("UgRandMark.json");
            var noEgg = Get("UgTamagoWazaIgnoreTable.json");
            var special = Get("UgSpecialPokemon.json");

            UndergroundParser.ParseEggIgnore(noEgg);
            UndergroundParser.ParseRandMark(randMark);
            UndergroundParser.ParsePos(Get("UgPokemonPos.json"));
            UndergroundParser.ParsePoke(Get("UgPokemonData.json"));

            for (int i = 2; i <= 20; i++)
                UndergroundParser.ParseEncount(Get($"UgEncount_{i:00}.json"));
            UndergroundParser.ParseLevel(Get("UgEncountLevel.json"));
            UndergroundParser.ParseManager(Get("UgFieldManager.json"));
            UndergroundParser.ParseSpecial(special);
            PickupParser.Parse(Get("MonohiroiTable.json"));

            UndergroundParser.MakePickle(mapInfo, special, noEgg, randMark, root, "bd");
            UndergroundParser.MakePickle(mapInfo, special, noEgg, randMark, root, "sp");
        }
    }
}
