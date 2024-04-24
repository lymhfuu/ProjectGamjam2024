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
        DirectHurt,
        Controller,
        Buff,
        ContinueHurt,
        ContinueEffect,
        ChangeEnv
    }
    /// <summary>
    /// 药剂
    /// </summary>
    public class MedicalmentModel : BaseModel
    {
        public string name;                    //敌人名称
        public MaterialColor[] material;       //合成材料
        public MaterialType specialMaterial;//特殊材料
        public EffectType effectType;          //类型
        public string description;             //效果

        public override void InitModel()
        {
            //TODO:初始化
        }
    }
}

