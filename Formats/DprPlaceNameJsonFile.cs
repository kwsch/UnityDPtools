namespace UnityDPtools.DprPlaceName
{
    public class DprPlaceNameJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public DprPlaceName[] DprPlaceName { get; set; }
    }

    public class DprPlaceName
    {
        public int Index { get; set; }
        public string MessageFile { get; set; }
        public string MessageLabel { get; set; }
    }
}
