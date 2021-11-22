using System;
using System.Collections.Generic;
using System.Text;

namespace UnityDPtools.Item
{
    public class ItemJsonFile
    {
        public UnityJsonMetadata m_GameObject { get; set; }
        public int m_Enabled { get; set; }
        public UnityJsonMetadata m_Script { get; set; }
        public string m_Name { get; set; }
        public Item[] Item { get; set; }
        public Wazamachine[] WazaMachine { get; set; }
    }

    public class Item
    {
        public int no { get; set; }
        public int type { get; set; }
        public int iconid { get; set; }
        public int price { get; set; }
        public int bp_price { get; set; }
        public int eqp { get; set; }
        public int atc { get; set; }
        public int nage_atc { get; set; }
        public int sizen_atc { get; set; }
        public int sizen_type { get; set; }
        public int tuibamu_eff { get; set; }
        public int sort { get; set; }
        public int group { get; set; }
        public int group_id { get; set; }
        public int fld_pocket { get; set; }
        public int field_func { get; set; }
        public int battle_func { get; set; }
        public int wk_cmn { get; set; }
        public int wk_critical_up { get; set; }
        public int wk_atc_up { get; set; }
        public int wk_def_up { get; set; }
        public int wk_agi_up { get; set; }
        public int wk_hit_up { get; set; }
        public int wk_spa_up { get; set; }
        public int wk_spd_up { get; set; }
        public int wk_prm_pp_rcv { get; set; }
        public int wk_prm_hp_exp { get; set; }
        public int wk_prm_pow_exp { get; set; }
        public int wk_prm_def_exp { get; set; }
        public int wk_prm_agi_exp { get; set; }
        public int wk_prm_spa_exp { get; set; }
        public int wk_prm_spd_exp { get; set; }
        public int wk_friend1 { get; set; }
        public int wk_friend2 { get; set; }
        public int wk_friend3 { get; set; }
        public int wk_prm_hp_rcv { get; set; }
        public long flags0 { get; set; }
    }

    public class Wazamachine
    {
        public int itemNo { get; set; }
        public int machineNo { get; set; }
        public int wazaNo { get; set; }
    }
}
