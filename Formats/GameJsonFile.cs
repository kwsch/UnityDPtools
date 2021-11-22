namespace UnityDPtools.GameText
{
    public class GameJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public byte m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public int hash { get; set; }
        public int langID { get; set; }
        public byte isResident { get; set; }
        public byte isKanji { get; set; }
        public Labeldataarray[] labelDataArray { get; set; }
    }

    public class Labeldataarray
    {
        public int labelIndex { get; set; }
        public int arrayIndex { get; set; }
        public string labelName { get; set; }
        public Styleinfo styleInfo { get; set; }
        public int[] attributeValueArray { get; set; }
        public object[] tagDataArray { get; set; }
        public Worddataarray[] wordDataArray { get; set; }
    }

    public class Styleinfo
    {
        public int styleIndex { get; set; }
        public int colorIndex { get; set; }
        public int fontSize { get; set; }
        public int maxWidth { get; set; }
        public int controlID { get; set; }
    }

    public class Worddataarray
    {
        public int patternID { get; set; }
        public int eventID { get; set; }
        public int tagIndex { get; set; }
        public float tagValue { get; set; }
        public string str { get; set; }
        public float strWidth { get; set; }
    }
}
