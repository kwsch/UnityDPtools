using System;
using System.Collections.Generic;
using System.Text;

namespace UnityDPtools.TV
{
    public class TVJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Timetable[] TimeTable { get; set; }
    }

    public class Timetable
    {
        public int hour { get; set; }
        public int minute { get; set; }
        public int mon { get; set; }
        public int tue { get; set; }
        public int wed { get; set; }
        public int thu { get; set; }
        public int fri { get; set; }
        public int sat { get; set; }
        public int sun { get; set; }
    }
}
