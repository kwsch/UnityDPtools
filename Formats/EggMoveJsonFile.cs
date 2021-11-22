namespace UnityDPtools.EggMove
{
    public class EggMoveJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Datum[] Data { get; set; }
    }

    public class Datum
    {
        public int no { get; set; }
        public int formNo { get; set; }
        public int[] wazaNo { get; set; }
    }
}
