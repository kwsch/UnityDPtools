using UnityDPtools.MapInfo;

namespace UnityDPtools.Formats
{
    public class UgItemTableJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Table[] table { get; set; }
    }

    public class Table
    {
        public int UgItemID { get; set; }
        public int ItemTableID { get; set; }
        public int TamatableID { get; set; }
        public int PedestaltableID { get; set; }
        public int StonestatueeffectID { get; set; }
    }
}
