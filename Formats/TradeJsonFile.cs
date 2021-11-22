namespace UnityDPtools.Trade
{
    public class TradeJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int target { get; set; }
        public string name_label { get; set; }
        public int trainerid { get; set; }
        public int monsno { get; set; }
        public string nickname_label { get; set; }
        public int level { get; set; }
        public int seikaku { get; set; }
        public int tokusei { get; set; }
        public int itemno { get; set; }
        public int rand { get; set; }
        public int sex { get; set; }
        public int language { get; set; }
        public int[] waza { get; set; }
    }
}