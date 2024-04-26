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
    /// ҩ��
    /// </summary>
    public class MedicalmentModel : BaseModel
    {
        public string name;                    //��������
        public SyntheticMedical materialA;     //�ϳɲ���A
        public SyntheticMedical materialB;     //�ϳɲ���A
        public MaterialType specialMaterial;   //�������
        public EffectType effectType;          //����
        public int[] skillValue;                //������ֵ
        public string description;             //Ч��

        public override void InitModel()
        {
            //TODO:��ʼ��
        }
    }
}

