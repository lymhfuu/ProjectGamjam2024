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
    /// ҩ��
    /// </summary>
    public class MedicalmentModel : BaseModel
    {
        public string name;                    //��������
        public MaterialColor[] material;       //�ϳɲ���
        public MaterialType specialMaterial;//�������
        public EffectType effectType;          //����
        public string description;             //Ч��

        public override void InitModel()
        {
            //TODO:��ʼ��
        }
    }
}

