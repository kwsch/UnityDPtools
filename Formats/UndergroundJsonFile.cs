namespace UnityDPtools.Underground
{
    public class UndergroundJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Sheet1[] Sheet1 { get; set; }
    }

    public class Sheet1
    {
        public int id { get; set; }
        public int monsno { get; set; }
        public int version { get; set; }
        public int Dspecialrate { get; set; }
        public int Pspecialrate { get; set; }
    }
}
