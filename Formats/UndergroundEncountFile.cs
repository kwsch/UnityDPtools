namespace UnityDPtools.Underground
{
    public class UndergroundEncountFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Table[] table { get; set; }
    }

    public class Table
    {
        public int monsno { get; set; }
        public int version { get; set; }
        public int zukanflag { get; set; }
    }

    public class UndergroundLevelFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        public int MinLv { get; set; }
        public int MaxLv { get; set; }
    }

    public class UndergroundField
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public int d_stationIndex { get; set; }
        public int d_digGroupID { get; set; }
        public int isUgExiting { get; set; }
        public int isErrorDialogVisible { get; set; }
        public int isLoadedOrVisit { get; set; }
        public float KousekiBonusTime { get; set; }
        public int KousekiCount { get; set; }
        public int BonusCount { get; set; }
        public Ugstatueeffectdata ugStatueEffectData { get; set; }
        public Minimap miniMap { get; set; }
        public Npcentity NpcEntity { get; set; }
        public Statuebuff statueBuff { get; set; }
        public Nowbasemodel nowBaseModel { get; set; }
        public Effectivebase EffectiveBase { get; set; }
        public object[] SecretBases { get; set; }
        public Ugdiggrouplist ugDigGroupList { get; set; }
        public float duration { get; set; }
        public float searchSize { get; set; }
        public float searchDist { get; set; }
        public float TalkDistance { get; set; }
        public int Button02 { get; set; }
        public int Button04 { get; set; }
        public int Button03 { get; set; }
        public int Button01 { get; set; }
        public int Button05 { get; set; }
        public int Button06 { get; set; }
        public int button111 { get; set; }
        public int Button001 { get; set; }
        public int button01 { get; set; }
        public int button02 { get; set; }
        public int button03 { get; set; }
        public int Button010 { get; set; }
    }

    public class Ugstatueeffectdata
    {
        public int m_FileID { get; set; }
        public long m_PathID { get; set; }
    }

    public class Minimap
    {
        public int m_FileID { get; set; }
        public int m_PathID { get; set; }
    }

    public class Npcentity
    {
        public int m_FileID { get; set; }
        public int m_PathID { get; set; }
    }

    public class Statuebuff
    {
        public int m_FileID { get; set; }
        public int m_PathID { get; set; }
    }

    public class Nowbasemodel
    {
        public int zoneID { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int direction { get; set; }
        public int expansionStatus { get; set; }
        public int goodCount { get; set; }
        public object[] ugStoneStatue { get; set; }
        public int isEnable { get; set; }
    }

    public class Effectivebase
    {
        public int zoneID { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public int direction { get; set; }
        public int expansionStatus { get; set; }
        public int goodCount { get; set; }
        public object[] ugStoneStatue { get; set; }
        public int isEnable { get; set; }
    }

    public class Ugdiggrouplist
    {
        public object[] DigFossilIDs { get; set; }
    }
}