namespace UnityDPtools.Encounter
{
    public class Encounters
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Table[] table { get; set; }
        public Urayama[] urayama { get; set; }
        public Mistu[] mistu { get; set; }
        public Honeytree[] honeytree { get; set; }
        public Safari[] safari { get; set; }
        public Mvpoke[] mvpoke { get; set; }
        public Legendpoke[] legendpoke { get; set; }
        public Zui[] zui { get; set; }
    }

    public class Table
    {
        public int zoneID { get; set; }
        public int encRate_gr { get; set; }
        public MonsLv[] ground_mons { get; set; }
        public MonsLv[] tairyo { get; set; } // swarm
        public MonsLv[] day { get; set; }
        public MonsLv[] night { get; set; }
        public MonsLv[] swayGrass { get; set; }
        public int[] FormProb { get; set; } // shellos|gastrodon east/west
        public int[] Nazo { get; set; } // unuzed
        public int[] AnnoonTable { get; set; } // unown form table to use
        public MonsLv[] gbaRuby { get; set; } // unused
        public MonsLv[] gbaSapp { get; set; } // unused
        public MonsLv[] gbaEme { get; set; } // unused
        public MonsLv[] gbaFire { get; set; } // unused
        public MonsLv[] gbaLeaf { get; set; } // unused
        public int encRate_wat { get; set; }
        public MonsLv[] water_mons { get; set; } // surf
        public int encRate_turi_boro { get; set; }
        public MonsLv[] boro_mons { get; set; } // old rod
        public int encRate_turi_ii { get; set; }
        public MonsLv[] ii_mons { get; set; } // good rod
        public int encRate_sugoi { get; set; }
        public MonsLv[] sugoi_mons { get; set; } // super rod
    }

    public class MonsLv
    {
        public int maxlv { get; set; }
        public int minlv { get; set; }
        public int monsNo { get; set; }
        public override string ToString() => $"{PKHeX.Core.GameInfo.Strings.Species[monsNo]}-{(minlv==maxlv ? minlv : $"[{minlv},{maxlv}]")}";
    }

    public class Urayama
    {
        public int monsNo { get; set; }
        public override string ToString() => $"{PKHeX.Core.GameInfo.Strings.Species[monsNo]}";
    }

    public class Mistu
    {
        public int Rate { get; set; }
        public int Normal { get; set; }
        public int Rare { get; set; }
        public int SuperRare { get; set; }

        public override string ToString()
        {
            var s1 = PKHeX.Core.GameInfo.Strings.Species[Normal];
            var s2 = PKHeX.Core.GameInfo.Strings.Species[Rare];
            var s3 = PKHeX.Core.GameInfo.Strings.Species[SuperRare];
            return $"{Rate}-({s1}, {s2}, {s3})";
        }
    }

    public class Honeytree
    {
        public int Normal { get; set; }
        public int Rare { get; set; }
    }

    public class Safari
    {
        public int MonsNo { get; set; }
    }

    public class Mvpoke
    {
        public int zoneID { get; set; }
        public int nextCount { get; set; }
        public int[] nextZoneID { get; set; }
    }

    public class Legendpoke
    {
        public int monsNo { get; set; }
        public int formNo { get; set; }
        public int isFixedEncSeq { get; set; }
        public string encSeq { get; set; }
        public int isFixedBGM { get; set; }
        public string bgmEvent { get; set; }
        public int isFixedBtlBg { get; set; }
        public int btlBg { get; set; }
        public int isFixedSetupEffect { get; set; }
        public int setupEffect { get; set; }
    }

    public class Zui
    {
        public int zoneID { get; set; }
        public int[] form { get; set; }
    }
}
