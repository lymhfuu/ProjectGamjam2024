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
        public MaterialType mt;
    }
    /// <summary>
    /// ҩ��
    /// </summary>
    public class MedicalmentModel : BaseModel
    {
        public int id;                         //ҩ��id
        public string name;                    //ҩ������
        public string materialA;     //�ϳɲ���A
        public string materialB;     //�ϳɲ���B
        public string specialMaterial;   //�������
        public string effectType;          //����
        public int[] skillValue;                //������ֵ
        public string description;             //Ч��

        public override void InitModel()
        {
            //TODO:��ʼ��
        }
    }
}

