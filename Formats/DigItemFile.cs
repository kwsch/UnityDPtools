namespace UnityDPtools.TV
{

    public class DigItemFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Deposit[] Deposit { get; set; }
    }

    public class Deposit
    {
        public int itemId { get; set; }
        public int MSLabelId { get; set; }
        public string shape { get; set; }
        public int turn { get; set; }
        public int offsetSize { get; set; }
        public int offsetX { get; set; }
        public int offsetY { get; set; }
        public int bIsOnly { get; set; }
        public int bIsRare { get; set; }
        public int ratio1 { get; set; }
        public int ratio2 { get; set; }
        public int ratio3 { get; set; }
        public int ratio4 { get; set; }
        public int ratio5 { get; set; }
        public int ratio6 { get; set; }
    }
}
