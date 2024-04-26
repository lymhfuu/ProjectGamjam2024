using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Model
{
    public enum MaterialColor
    {
        Red,
        Yellow,
        Blue
    }

    public enum EffectType
    {
        Damage,
        ChangeValue,
        Buff,
        Skill,
        Action,
        NULL
    }

    public struct SyntheticMedical
    {
        public MaterialColor m1;
        public MaterialColor m2;
    }
    /// <summary>
    /// 药剂
    /// </summary>
    public class MedicalmentModel : BaseModel
    {
        public string name;                    //敌人名称
        public SyntheticMedical materialA;     //合成材料A
        public SyntheticMedical materialB;     //合成材料A
        public MaterialType specialMaterial;   //特殊材料
        public EffectType effectType;          //类型
        public int[] skillValue;                //技能数值
        public string description;             //效果

        public override void InitModel()
        {
            //TODO:初始化
        }
    }
}

