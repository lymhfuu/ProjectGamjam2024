using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    private int _curHp;
    private int _maxHp;
    public int leavesMoveTimes;
    private int _attck;

    public int CurHP
    {
        get
        {
            return _curHp;
        }
        set
        {
            _curHp = value;
        }
    }

    public int MaxHp
    {
        get
        {
            return _maxHp;
        }
        set
        {
            _maxHp = value;
        }
    }

    public  int Attack
    {
        get { return _attck; }

        set{ }
    }

    public bool CanMove()
    {
        if (this.leavesMoveTimes <= 0)
            return false;

        return true;
    }


    public virtual void UseSkill(BaseEntity target)
    {
        this.leavesMoveTimes--;
    }

    public void GetHurt(int damege)
    {
        this.CurHP -= damege;
        if (this.CurHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

    }
}
