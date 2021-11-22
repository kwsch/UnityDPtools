namespace UnityDPtools.Learnset
{
    public class LevelUpJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Wazaoboe[] WazaOboe { get; set; }
    }

    public class Wazaoboe
    {
        public int id { get; set; }

        /// <summary>
        /// Level, Move int32 pairs; all in the same array
        /// </summary>
        public int[] ar { get; set; }
    }
}
