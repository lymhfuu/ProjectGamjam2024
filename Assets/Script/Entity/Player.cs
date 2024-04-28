using Game.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Medicalment
{
    public MedicalmentModel medModel;
    public int num;
}
public class Player : BaseEntity
{
    private AttackUnitModel model;
    private Medicalment myMedicalment;

    public Player(AttackUnitModel atm)
    {
        this.model = atm;
        this.CurHP = model.hp;
        this.Attack = model.Attack;
    }
    
    public void SynthesisMedicalment(SyntheticMedical sm,MaterialType mt)
    {
        this.leavesMoveTimes--;
    }


    public override void UseSkill(BaseEntity target)
    {
        base.UseSkill(target);

    }

    public void ReleaseMedicalment(BaseEntity target)
    {
        this.leavesMoveTimes--;
    }
}
