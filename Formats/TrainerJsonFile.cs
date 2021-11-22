namespace UnityDPtools.Formats
{
    public class TrainerJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Trainertype[] TrainerType { get; set; }
        public Trainerdata[] TrainerData { get; set; }
        public Trainerpoke[] TrainerPoke { get; set; }
        public Trainerrematch[] TrainerRematch { get; set; }
        public Sealtemplate[] SealTemplate { get; set; }
        public Skirtgraphicschara[] SkirtGraphicsChara { get; set; }
    }

    public class Trainertype
    {
        public int TrainerID { get; set; }
        public string LabelTrType { get; set; }
        public int Sex { get; set; }
        public int Group { get; set; }
        public int BallId { get; set; }
        public string[] FieldEncount { get; set; }
        public int[] BtlEffId { get; set; }
        public string EyeBgm { get; set; }
        public string ModelID { get; set; }
        public int Hand { get; set; }
        public int HoldBallHand { get; set; }
        public int HelpHand { get; set; }
        public int HelpHoldBallHand { get; set; }
        public float ThrowTime { get; set; }
        public float CaptureThrowTime { get; set; }
        public float LoseLoopTime { get; set; }
        public string TrainerEffect { get; set; }
        public int Age { get; set; }
    }

    public class Trainerdata
    {
        public int TypeID { get; set; }
        public int ColorID { get; set; }
        public int FightType { get; set; }
        public int ArenaID { get; set; }
        public int EffectID { get; set; }
        public int Gold { get; set; }
        public int UseItem1 { get; set; }
        public int UseItem2 { get; set; }
        public int UseItem3 { get; set; }
        public int UseItem4 { get; set; }
        public int HpRecoverFlag { get; set; }
        public int GiftItem { get; set; }
        public string NameLabel { get; set; }
        public string MsgFieldPokeOne { get; set; }
        public string MsgFieldBefore { get; set; }
        public string MsgFieldRevenge { get; set; }
        public string MsgFieldAfter { get; set; }
        public string[] MsgBattle { get; set; }
        public string[] SeqBattle { get; set; }
        public int AIBit { get; set; }
    }

    public class Trainerpoke
    {
        public int ID { get; set; }
        public int P1MonsNo { get; set; }
        public int P1FormNo { get; set; }
        public int P1IsRare { get; set; }
        public int P1Level { get; set; }
        public int P1Sex { get; set; }
        public int P1Seikaku { get; set; }
        public int P1Tokusei { get; set; }
        public int P1Waza1 { get; set; }
        public int P1Waza2 { get; set; }
        public int P1Waza3 { get; set; }
        public int P1Waza4 { get; set; }
        public int P1Item { get; set; }
        public int P1Ball { get; set; }
        public int P1Seal { get; set; }
        public int P1TalentHp { get; set; }
        public int P1TalentAtk { get; set; }
        public int P1TalentDef { get; set; }
        public int P1TalentSpAtk { get; set; }
        public int P1TalentSpDef { get; set; }
        public int P1TalentAgi { get; set; }
        public int P1EffortHp { get; set; }
        public int P1EffortAtk { get; set; }
        public int P1EffortDef { get; set; }
        public int P1EffortSpAtk { get; set; }
        public int P1EffortSpDef { get; set; }
        public int P1EffortAgi { get; set; }
        public int P2MonsNo { get; set; }
        public int P2FormNo { get; set; }
        public int P2IsRare { get; set; }
        public int P2Level { get; set; }
        public int P2Sex { get; set; }
        public int P2Seikaku { get; set; }
        public int P2Tokusei { get; set; }
        public int P2Waza1 { get; set; }
        public int P2Waza2 { get; set; }
        public int P2Waza3 { get; set; }
        public int P2Waza4 { get; set; }
        public int P2Item { get; set; }
        public int P2Ball { get; set; }
        public int P2Seal { get; set; }
        public int P2TalentHp { get; set; }
        public int P2TalentAtk { get; set; }
        public int P2TalentDef { get; set; }
        public int P2TalentSpAtk { get; set; }
        public int P2TalentSpDef { get; set; }
        public int P2TalentAgi { get; set; }
        public int P2EffortHp { get; set; }
        public int P2EffortAtk { get; set; }
        public int P2EffortDef { get; set; }
        public int P2EffortSpAtk { get; set; }
        public int P2EffortSpDef { get; set; }
        public int P2EffortAgi { get; set; }
        public int P3MonsNo { get; set; }
        public int P3FormNo { get; set; }
        public int P3IsRare { get; set; }
        public int P3Level { get; set; }
        public int P3Sex { get; set; }
        public int P3Seikaku { get; set; }
        public int P3Tokusei { get; set; }
        public int P3Waza1 { get; set; }
        public int P3Waza2 { get; set; }
        public int P3Waza3 { get; set; }
        public int P3Waza4 { get; set; }
        public int P3Item { get; set; }
        public int P3Ball { get; set; }
        public int P3Seal { get; set; }
        public int P3TalentHp { get; set; }
        public int P3TalentAtk { get; set; }
        public int P3TalentDef { get; set; }
        public int P3TalentSpAtk { get; set; }
        public int P3TalentSpDef { get; set; }
        public int P3TalentAgi { get; set; }
        public int P3EffortHp { get; set; }
        public int P3EffortAtk { get; set; }
        public int P3EffortDef { get; set; }
        public int P3EffortSpAtk { get; set; }
        public int P3EffortSpDef { get; set; }
        public int P3EffortAgi { get; set; }
        public int P4MonsNo { get; set; }
        public int P4FormNo { get; set; }
        public int P4IsRare { get; set; }
        public int P4Level { get; set; }
        public int P4Sex { get; set; }
        public int P4Seikaku { get; set; }
        public int P4Tokusei { get; set; }
        public int P4Waza1 { get; set; }
        public int P4Waza2 { get; set; }
        public int P4Waza3 { get; set; }
        public int P4Waza4 { get; set; }
        public int P4Item { get; set; }
        public int P4Ball { get; set; }
        public int P4Seal { get; set; }
        public int P4TalentHp { get; set; }
        public int P4TalentAtk { get; set; }
        public int P4TalentDef { get; set; }
        public int P4TalentSpAtk { get; set; }
        public int P4TalentSpDef { get; set; }
        public int P4TalentAgi { get; set; }
        public int P4EffortHp { get; set; }
        public int P4EffortAtk { get; set; }
        public int P4EffortDef { get; set; }
        public int P4EffortSpAtk { get; set; }
        public int P4EffortSpDef { get; set; }
        public int P4EffortAgi { get; set; }
        public int P5MonsNo { get; set; }
        public int P5FormNo { get; set; }
        public int P5IsRare { get; set; }
        public int P5Level { get; set; }
        public int P5Sex { get; set; }
        public int P5Seikaku { get; set; }
        public int P5Tokusei { get; set; }
        public int P5Waza1 { get; set; }
        public int P5Waza2 { get; set; }
        public int P5Waza3 { get; set; }
        public int P5Waza4 { get; set; }
        public int P5Item { get; set; }
        public int P5Ball { get; set; }
        public int P5Seal { get; set; }
        public int P5TalentHp { get; set; }
        public int P5TalentAtk { get; set; }
        public int P5TalentDef { get; set; }
        public int P5TalentSpAtk { get; set; }
        public int P5TalentSpDef { get; set; }
        public int P5TalentAgi { get; set; }
        public int P5EffortHp { get; set; }
        public int P5EffortAtk { get; set; }
        public int P5EffortDef { get; set; }
        public int P5EffortSpAtk { get; set; }
        public int P5EffortSpDef { get; set; }
        public int P5EffortAgi { get; set; }
        public int P6MonsNo { get; set; }
        public int P6FormNo { get; set; }
        public int P6IsRare { get; set; }
        public int P6Level { get; set; }
        public int P6Sex { get; set; }
        public int P6Seikaku { get; set; }
        public int P6Tokusei { get; set; }
        public int P6Waza1 { get; set; }
        public int P6Waza2 { get; set; }
        public int P6Waza3 { get; set; }
        public int P6Waza4 { get; set; }
        public int P6Item { get; set; }
        public int P6Ball { get; set; }
        public int P6Seal { get; set; }
        public int P6TalentHp { get; set; }
        public int P6TalentAtk { get; set; }
        public int P6TalentDef { get; set; }
        public int P6TalentSpAtk { get; set; }
        public int P6TalentSpDef { get; set; }
        public int P6TalentAgi { get; set; }
        public int P6EffortHp { get; set; }
        public int P6EffortAtk { get; set; }
        public int P6EffortDef { get; set; }
        public int P6EffortSpAtk { get; set; }
        public int P6EffortSpDef { get; set; }
        public int P6EffortAgi { get; set; }
    }

    public class Trainerrematch
    {
        public int BaseTrainerID { get; set; }
        public int Rematch_01 { get; set; }
        public int Rematch_02 { get; set; }
        public int Rematch_03 { get; set; }
        public int Rematch_04 { get; set; }
        public int Rematch_05 { get; set; }
    }

    public class Sealtemplate
    {
        public int SealID1 { get; set; }
        public Pos Pos1 { get; set; }
        public int SealID2 { get; set; }
        public Pos Pos2 { get; set; }
        public int SealID3 { get; set; }
        public Pos Pos3 { get; set; }
        public int SealID4 { get; set; }
        public Pos Pos4 { get; set; }
        public int SealID5 { get; set; }
        public Pos Pos5 { get; set; }
        public int SealID6 { get; set; }
        public Pos Pos6 { get; set; }
        public int SealID7 { get; set; }
        public Pos Pos7 { get; set; }
        public int SealID8 { get; set; }
        public Pos Pos8 { get; set; }
        public int SealID9 { get; set; }
        public Pos Pos9 { get; set; }
        public int SealID10 { get; set; }
        public Pos Pos10 { get; set; }
        public int SealID11 { get; set; }
        public Pos Pos11 { get; set; }
        public int SealID12 { get; set; }
        public Pos Pos12 { get; set; }
        public int SealID13 { get; set; }
        public Pos Pos13 { get; set; }
        public int SealID14 { get; set; }
        public Pos Pos14 { get; set; }
        public int SealID15 { get; set; }
        public Pos Pos15 { get; set; }
        public int SealID16 { get; set; }
        public Pos Pos16 { get; set; }
        public int SealID17 { get; set; }
        public Pos Pos17 { get; set; }
        public int SealID18 { get; set; }
        public Pos Pos18 { get; set; }
        public int SealID19 { get; set; }
        public Pos Pos19 { get; set; }
        public int SealID20 { get; set; }
        public Pos Pos20 { get; set; }
    }

    public class Pos
    {
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public override string ToString() => $"({x},{y},{z})";
    }

    public class Skirtgraphicschara
    {
        public string SkirtGraphicsID { get; set; }
    }
}
