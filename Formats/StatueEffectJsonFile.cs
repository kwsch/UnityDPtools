namespace UnityDPtools.Underground.Statue
{
    public class StatueJson
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Table[] table { get; set; }
    }

    public class Table
    {
        public int statueId { get; set; }
        public int UgItemID { get; set; }
        public int monsId { get; set; }
        public int rarity { get; set; }
        public int shader { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int resultCameraNo { get; set; }
        public int type1Id { get; set; }
        public int type2Id { get; set; }
        public int[] pokeTypeEffect { get; set; }
        public int MSLabelId { get; set; }
        public string motion { get; set; }
        public int frame { get; set; }
        public Offset offset { get; set; }
        public float cameraDistance { get; set; }
        public int FormNo { get; set; }
        public int Sex { get; set; }
        public int Rare { get; set; }
        public int ratio1 { get; set; }
        public int ratio2 { get; set; }
        public int ratio3 { get; set; }
        public int ratio4 { get; set; }
        public int ratio5 { get; set; }
        public int ratio6 { get; set; }
        public float fieldScale { get; set; }
    }

    public class Offset
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public override string ToString()
        {
            return $"({x},{y},{z})";
        }
    }
}
