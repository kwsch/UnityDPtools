namespace UnityDPtools.Underground.Poke
{
    public class UndergroundPokemonFile
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
        public int type1ID { get; set; }
        public int type2ID { get; set; }
        public int size { get; set; }
        public int movetype { get; set; }
        public int[] reactioncode { get; set; }
        public int[] move_rate { get; set; }
        public int[] submove_rate { get; set; }
        public int[] reaction { get; set; }
        public int[] flagrate { get; set; }
        public int rateup { get; set; }
    }

    public class UndergroundPositionFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Sheet1[] Sheet1 { get; set; }
    }

    public class Sheet1
    {
        public int ZoneID { get; set; }
        public Locator[] Locator { get; set; }
    }

    public class Locator
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public override string ToString() => $"({x},{y},{z})";
    }

    public class UndergroundRand
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Limits[] table { get; set; }
    }

    public class Limits
    {
        public int id { get; set; }
        public string FileName { get; set; }
        public int size { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public int smax { get; set; }
        public int mmax { get; set; }
        public int lmax { get; set; }
        public int llmax { get; set; }
        public int watermax { get; set; }
        public int[] typerate { get; set; }
    }
}
