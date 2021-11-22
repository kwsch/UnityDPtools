using System;

namespace UnityDPtools.Personal
{
    public class PersonalJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Personal[] Personal { get; set; }
    }

    public class Personal
    {
        public int valid_flag { get; set; }
        public int id { get; set; }
        public int monsno { get; set; }
        public int form_index { get; set; }
        public int form_max { get; set; }
        public int color { get; set; }
        public int gra_no { get; set; }
        public int basic_hp { get; set; }
        public int basic_atk { get; set; }
        public int basic_def { get; set; }
        public int basic_agi { get; set; }
        public int basic_spatk { get; set; }
        public int basic_spdef { get; set; }
        public int type1 { get; set; }
        public int type2 { get; set; }
        public int get_rate { get; set; }
        public int rank { get; set; }
        public int exp_value { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int sex { get; set; }
        public int egg_birth { get; set; }
        public int initial_friendship { get; set; }
        public int egg_group1 { get; set; }
        public int egg_group2 { get; set; }
        public int grow { get; set; }
        public int tokusei1 { get; set; }
        public int tokusei2 { get; set; }
        public int tokusei3 { get; set; }
        public int give_exp { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int chihou_zukan_no { get; set; }
        public uint machine1 { get; set; }
        public uint machine2 { get; set; }
        public uint machine3 { get; set; }
        public uint machine4 { get; set; }
        public uint hiden_machine { get; set; }
        public int egg_monsno { get; set; }
        public int egg_formno { get; set; }
        public int egg_formno_kawarazunoishi { get; set; }
        public int egg_form_inherit_kawarazunoishi { get; set; }

        public PersonalInfoBDSP CreatePersonal()
        {
            return new PersonalInfoBDSP
            {
                IsPresentInGame = valid_flag == 1,
                // id,
                Species = monsno,
                FormStatsIndex = form_index,
                FormCount = form_max,
                Color = color,
                HP = basic_hp,
                ATK = basic_atk,
                DEF = basic_def,
                SPE = basic_agi,
                SPA = basic_spatk,
                SPD = basic_spdef,
                Type1 = type1,
                Type2 = type2,
                CatchRate = get_rate,
                EvoStage = rank,
                EVYield = exp_value,
                Item1 = item1,
                Item2 = item2,
                Item3 = item3,
                Gender = sex,
                HatchCycles = egg_birth,
                BaseFriendship = initial_friendship,
                EggGroup1 = egg_group1,
                EggGroup2 = egg_group2,
                EXPGrowth = grow,
                Ability1 = tokusei1,
                Ability2 = tokusei2,
                AbilityH = tokusei3,
                BaseEXP = give_exp,
                Height = height,
                Weight = weight,
                PokeDexIndex = chihou_zukan_no,
                TM1 = machine1,
                TM2 = machine2,
                TM3 = machine3,
                TM4 = machine4,
                Tutor = hiden_machine,
                HatchSpecies = egg_monsno,
                HatchFormIndex = egg_formno,
                // egg_formno_kawarazunoishi,       // both 0 for all entries, ignore
                // egg_form_inherit_kawarazunoishi, // both 0 for all entries, ignore
            };
        }
    }

    public sealed class PersonalInfoBDSP
    {
        public const int SIZE = 0x44;

        private readonly byte[] Data;
        public byte[] Write() => Data;

        public PersonalInfoBDSP() : this(new byte[SIZE]) { }

        public PersonalInfoBDSP(byte[] data) => Data = data;

        public int HP { get => Data[0x00]; set => Data[0x00] = (byte)value; }
        public int ATK { get => Data[0x01]; set => Data[0x01] = (byte)value; }
        public int DEF { get => Data[0x02]; set => Data[0x02] = (byte)value; }
        public int SPE { get => Data[0x03]; set => Data[0x03] = (byte)value; }
        public int SPA { get => Data[0x04]; set => Data[0x04] = (byte)value; }
        public int SPD { get => Data[0x05]; set => Data[0x05] = (byte)value; }
        public int Type1 { get => Data[0x06]; set => Data[0x06] = (byte)value; }
        public int Type2 { get => Data[0x07]; set => Data[0x07] = (byte)value; }
        public int CatchRate { get => Data[0x08]; set => Data[0x08] = (byte)value; }
        public int EvoStage { get => Data[0x09]; set => Data[0x09] = (byte)value; }
        public int EVYield { get => BitConverter.ToUInt16(Data, 0x0A); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x0A); }
        public int Item1 { get => BitConverter.ToInt16(Data, 0x0C); set => BitConverter.GetBytes((short)value).CopyTo(Data, 0x0C); }
        public int Item2 { get => BitConverter.ToInt16(Data, 0x0E); set => BitConverter.GetBytes((short)value).CopyTo(Data, 0x0E); }
        public int Item3 { get => BitConverter.ToInt16(Data, 0x10); set => BitConverter.GetBytes((short)value).CopyTo(Data, 0x10); }
        public int Gender { get => Data[0x12]; set => Data[0x12] = (byte)value; }
        public int HatchCycles { get => Data[0x13]; set => Data[0x13] = (byte)value; }
        public int BaseFriendship { get => Data[0x14]; set => Data[0x14] = (byte)value; }
        public int EXPGrowth { get => Data[0x15]; set => Data[0x15] = (byte)value; }
        public int EggGroup1 { get => Data[0x16]; set => Data[0x16] = (byte)value; }
        public int EggGroup2 { get => Data[0x17]; set => Data[0x17] = (byte)value; }
        public int Ability1 { get => BitConverter.ToUInt16(Data, 0x18); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x18); }
        public int Ability2 { get => BitConverter.ToUInt16(Data, 0x1A); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x1A); }
        public int AbilityH { get => BitConverter.ToUInt16(Data, 0x1C); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x1C); }
        public int EscapeRate { get => 0; set { } } // moved?
        public int FormStatsIndex { get => BitConverter.ToUInt16(Data, 0x1E); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x1E); }
        public int FormSprite { get => 0; set { } } // ???
        public int FormCount { get => Data[0x20]; set => Data[0x20] = (byte)value; }
        public int Color { get => Data[0x21] & 0x3F; set => Data[0x21] = (byte)((Data[0x21] & 0xC0) | (value & 0x3F)); }
        public bool IsPresentInGame { get => ((Data[0x21] >> 6) & 1) == 1; set => Data[0x21] = (byte)((Data[0x21] & ~0x40) | (value ? 0x40 : 0)); }
        public bool SpriteForm { get => false; set { } }
        public int BaseEXP { get => BitConverter.ToUInt16(Data, 0x22); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x22); }
        public int Height { get => BitConverter.ToUInt16(Data, 0x24); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x24); }
        public int Weight { get => BitConverter.ToUInt16(Data, 0x26); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x26); }

        public uint TM1 { get => BitConverter.ToUInt32(Data, 0x28); set => BitConverter.GetBytes(value).CopyTo(Data, 0x28); }
        public uint TM2 { get => BitConverter.ToUInt32(Data, 0x2C); set => BitConverter.GetBytes(value).CopyTo(Data, 0x2C); }
        public uint TM3 { get => BitConverter.ToUInt32(Data, 0x30); set => BitConverter.GetBytes(value).CopyTo(Data, 0x30); }
        public uint TM4 { get => BitConverter.ToUInt32(Data, 0x34); set => BitConverter.GetBytes(value).CopyTo(Data, 0x34); }
        public uint Tutor { get => BitConverter.ToUInt32(Data, 0x38); set => BitConverter.GetBytes(value).CopyTo(Data, 0x38); }

        public int Species { get => BitConverter.ToUInt16(Data, 0x3C); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x3C); }
        public int HatchSpecies { get => BitConverter.ToUInt16(Data, 0x3E); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x3E); }
        public int HatchFormIndex { get => BitConverter.ToUInt16(Data, 0x40); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x40); }
        public int PokeDexIndex { get => BitConverter.ToUInt16(Data, 0x42); set => BitConverter.GetBytes((ushort)value).CopyTo(Data, 0x42); }
    }
}
