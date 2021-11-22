namespace UnityDPtools.Underground.Poke
{
    public class UndergroundEggIgnore
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public IgnoreInfo[] Sheet1 { get; set; }
    }

    public class IgnoreInfo
    {
        public int MonsNo { get; set; }
        public int[] Waza { get; set; }
    }
}
