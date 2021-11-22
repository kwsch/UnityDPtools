using System;
using System.Collections.Generic;
using System.Text;

namespace UnityDPtools.Underground.Map
{
    public class UndergroundMapJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Map[] Map { get; set; }
        public Icon[] Icon { get; set; }
        public MapGroup[] MapGroup { get; set; }
    }

    public class Map
    {
        public int mapGroupID { get; set; }
        public int zoneid { get; set; }
        public Mapoffset MapOffset { get; set; }
        public int IsPlayerPos { get; set; }
    }

    public class Mapoffset
    {
        public float x { get; set; }
        public float y { get; set; }

        public override string ToString() => $"({x},{y})";
    }

    public class Icon
    {
        public int mapGroupID { get; set; }
        public int zoneid { get; set; }
        public int IsEast { get; set; }
        public Imagepos ImagePos { get; set; }
        public int Default { get; set; }
        public int Open { get; set; }
    }

    public class Imagepos
    {
        public float x { get; set; }
        public float y { get; set; }
        public override string ToString() => $"({x},{y})";
    }

    public class MapGroup
    {
        public int ID { get; set; }
        public int[] zoneid { get; set; }
    }
}
