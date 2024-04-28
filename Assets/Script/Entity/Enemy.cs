using Game.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseEntity
{
    private AttackUnitModel model;
    private Medicalment myMedicalment;

    public Enemy(AttackUnitModel atm)
    {
        this.model = atm;
        this.CurHP = model.hp;
        this.Attack = model.Attack;
    }

    public override void UseSkill(BaseEntity target)
    {
        base.UseSkill(target);

    }
}
