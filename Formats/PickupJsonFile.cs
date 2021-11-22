using System;
using System.Collections.Generic;
using System.Text;

namespace UnityDPtools.Pickup
{
    public class PickupJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Monohiroi[] MonoHiroi { get; set; }
    }

    public class Monohiroi
    {
        public int ID { get; set; }
        public int[] Ratios { get; set; }
    }
}
