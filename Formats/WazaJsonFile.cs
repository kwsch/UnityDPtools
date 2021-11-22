namespace UnityDPtools.Waza
{
    public class WazaJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Waza[] Waza { get; set; }
        public Yubiwohuru[] Yubiwohuru { get; set; } // is active array
    }

    public class Waza
    {
        public int wazaNo { get; set; }
        public byte isValid { get; set; }
        public byte type { get; set; }
        public byte category { get; set; }
        public byte damageType { get; set; }
        public byte power { get; set; }
        public byte hitPer { get; set; }
        public byte basePP { get; set; }
        public sbyte priority { get; set; }
        public byte hitCountMax { get; set; }
        public byte hitCountMin { get; set; }
        public ushort sickID { get; set; }
        public byte sickPer { get; set; }
        public byte sickCont { get; set; }
        public byte sickTurnMin { get; set; }
        public byte sickTurnMax { get; set; }
        public byte criticalRank { get; set; }
        public byte shrinkPer { get; set; }
        public ushort aiSeqNo { get; set; }
        public sbyte damageRecoverRatio { get; set; }
        public sbyte hpRecoverRatio { get; set; }
        public byte target { get; set; }
        public byte rankEffType1 { get; set; }
        public byte rankEffType2 { get; set; }
        public byte rankEffType3 { get; set; }
        public sbyte rankEffValue1 { get; set; }
        public sbyte rankEffValue2 { get; set; }
        public sbyte rankEffValue3 { get; set; }
        public byte rankEffPer1 { get; set; }
        public byte rankEffPer2 { get; set; }
        public byte rankEffPer3 { get; set; }
        public uint flags { get; set; }
        public uint contestWazaNo { get; set; }
    }

    public class Yubiwohuru
    {
        public int[] wazaNos { get; set; }
    }
}
