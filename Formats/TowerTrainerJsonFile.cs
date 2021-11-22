using System;
using System.Collections.Generic;
using System.Text;

namespace UnityDPtools.Tower
{
    public class TowerTrainerJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Trainerdata[] TrainerData { get; set; }
        public Trainerpoke[] TrainerPoke { get; set; }
    }

    public class Trainerdata
    {
        public int TrainerType { get; set; }
        public string NameLabel { get; set; }
        public string MsgFieldBefore { get; set; }
        public string[] MsgBattle { get; set; }
        public string[] SeqBattle { get; set; }
        public int ColorID { get; set; }
    }

    public class Trainerpoke
    {
        public int ID { get; set; }
        public int MonsNo { get; set; }
        public int FormNo { get; set; }
        public int IsRare { get; set; }
        public int Level { get; set; }
        public int Sex { get; set; }
        public int Seikaku { get; set; }
        public int Tokusei { get; set; }
        public int Waza1 { get; set; }
        public int Waza2 { get; set; }
        public int Waza3 { get; set; }
        public int Waza4 { get; set; }
        public int Item { get; set; }
        public int Ball { get; set; }
        public int Seal { get; set; }
        public int TalentHp { get; set; }
        public int TalentAtk { get; set; }
        public int TalentDef { get; set; }
        public int TalentSpAtk { get; set; }
        public int TalentSpDef { get; set; }
        public int TalentAgi { get; set; }
        public int EffortHp { get; set; }
        public int EffortAtk { get; set; }
        public int EffortDef { get; set; }
        public int EffortSpAtk { get; set; }
        public int EffortSpDef { get; set; }
        public int EffortAgi { get; set; }
    }
}
