using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Model
{
    public enum Drop
    {
        A,
        B,
        C,
        D,
        NULL
    }
    public enum EntityType
    {
        Enemy,
        Player,
        MapEntity
    }
    public enum AttackType
    {
        Sword,
        Range,
        NULL,
    }
    /// <summary>
    /// ���˱�������ң�
    /// </summary>
    public class AttackUnitModel : BaseModel
    {
        public string name;            //��������
        public EntityType entityType;  //��λ����
        public int hp;                 //Ѫ��
        public int moveTimes;          //�ж���
        public int stepLength;         //�ƶ���
        public int watchRange;         //������Χ
        public AttackType attackType;  //��������
        public int rangeLeft;          //��Χ��ʼ
        public int RangeRight;         //��Χ����
        public string skillDescription;//��������
        public int useSkill;           //�����ж���
        public Drop dropMaterial;      //���ϵ���

        public override void InitModel()
        {
            //TODO:��ʼ��
        }
    }
}

