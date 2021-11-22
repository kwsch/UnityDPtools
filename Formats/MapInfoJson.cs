namespace UnityDPtools.MapInfo
{
    public class MapInfoJson
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Zonedata[] ZoneData { get; set; }
        public Camera[] Camera { get; set; }
    }

    public class Zonedata
    {
        public string Caption { get; set; }
        public string MSLabel { get; set; }
        public string PokePlaceName { get; set; }
        public string FlyingPlaceName { get; set; }
        public int MapType { get; set; }
        public int IsField { get; set; }
        public int LandmarkType { get; set; }
        public Minimapoffset MiniMapOffset { get; set; }
        public int Bicycle { get; set; }
        public int Escape { get; set; }
        public int Fly { get; set; }
        public int BattleSearcher { get; set; }
        public int TureAruki { get; set; }
        public int KuruKuru { get; set; }
        public int Fall { get; set; }
        public int[] BattleBg { get; set; }
        public int ZoneID { get; set; }
        public int AreaID { get; set; }
        public UnityJsonMetadata ZoneGrid { get; set; }
        public UnityJsonMetadata Attribute { get; set; }
        public UnityJsonMetadata AttributeEx { get; set; }
        public UnityJsonMetadata SubAttribute { get; set; }
        public UnityJsonMetadata SubAttributeEx { get; set; }
        public string[] BGM { get; set; }
        public string EnvironmentalSound { get; set; }
        public int Weather { get; set; }
        public UnityJsonMetadata RenderSettings { get; set; }
        public int ReflectionCamera { get; set; }
        public int FixedTime { get; set; }
        public string AssetBundleName { get; set; }
        public int RoomPanCamera { get; set; }
        public Locator[] Locators { get; set; }
        public int Reload { get; set; }
    }

    public class Minimapoffset
    {
        public float x { get; set; }
        public float y { get; set; }
        public override string ToString() => $"({x},{y})";
    }

    public class Locator
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }

        public override string ToString() => $"({x},{y},{z},{w})";
    }

    public record Camera
    {
        public int ariaID { get; set; }
        public float pitch { get; set; }
        public float fov { get; set; }
        public float targetRange { get; set; }
        public float panDistance { get; set; }
        public float panPitch { get; set; }
        public float panFov { get; set; }
        public int panpos_useflag { get; set; }
        public float panMinposY { get; set; }
        public float panMaxposY { get; set; }
        public float panMinposZ { get; set; }
        public float panMaxposZ { get; set; }
        public float defocusStart { get; set; }
        public float defocusEnd { get; set; }
        public float distance { get; set; }
    }
}
