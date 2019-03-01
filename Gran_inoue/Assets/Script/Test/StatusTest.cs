using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusTest : MonoBehaviour {

    [SerializeField] PlayerScript _playerscript = null;
    public Entity_Status _entitystatus = null;

    public int Charanum = 0;

    public float smallspeed = 0.1f;


    int MAXHP = 0;
    int HP = 0;
    int Attack = 0;
    int Defance = 0;
    int MagicAttack = 0;
    int MagicDefance = 0;
    int Impact = 0;
    int Weight = 0;
    int Technology = 0;
    int Avoidance = 0;

    void Start()
    {
        switch (Charanum)
        {
            case 0:
                _entitystatus = Resources.Load("Date/Status") as Entity_Status;
                MAXHP = _entitystatus.param[Charanum].HP;
                HP = _entitystatus.param[Charanum].HP;
                Attack = _entitystatus.param[Charanum].Att;
                Defance = _entitystatus.param[Charanum].Def;
                MagicAttack = _entitystatus.param[Charanum].Matt;
                MagicDefance = _entitystatus.param[Charanum].Mdef;
                Impact = _entitystatus.param[Charanum].Imap;
                Weight = _entitystatus.param[Charanum].Wei;
                Technology = _entitystatus.param[Charanum].Tec;
                Avoidance = _entitystatus.param[Charanum].Avo;
                break;

            case 1:
                _entitystatus = Resources.Load("Date/Status") as Entity_Status;
                MAXHP = _entitystatus.param[Charanum].HP;
                HP = _entitystatus.param[Charanum].HP;
                Attack = _entitystatus.param[Charanum].Att;
                Defance = _entitystatus.param[Charanum].Def;
                MagicAttack = _entitystatus.param[Charanum].Matt;
                MagicDefance = _entitystatus.param[Charanum].Mdef;
                Impact = _entitystatus.param[Charanum].Imap;
                Weight = _entitystatus.param[Charanum].Wei;
                Technology = _entitystatus.param[Charanum].Tec;
                Avoidance = _entitystatus.param[Charanum].Avo;
                break;

            case 2:
                _entitystatus = Resources.Load("Date/Status") as Entity_Status;
                MAXHP = _entitystatus.param[Charanum].HP;
                HP = _entitystatus.param[Charanum].HP;
                Attack = _entitystatus.param[Charanum].Att;
                Defance = _entitystatus.param[Charanum].Def;
                MagicAttack = _entitystatus.param[Charanum].Matt;
                MagicDefance = _entitystatus.param[Charanum].Mdef;
                Impact = _entitystatus.param[Charanum].Imap;
                Weight = _entitystatus.param[Charanum].Wei;
                Technology = _entitystatus.param[Charanum].Tec;
                Avoidance = _entitystatus.param[Charanum].Avo;
                break;

            case 3:
                _entitystatus = Resources.Load("Date/Status") as Entity_Status;
                MAXHP = _entitystatus.param[Charanum].HP;
                HP = _entitystatus.param[Charanum].HP;
                Attack = _entitystatus.param[Charanum].Att;
                Defance = _entitystatus.param[Charanum].Def;
                MagicAttack = _entitystatus.param[Charanum].Matt;
                MagicDefance = _entitystatus.param[Charanum].Mdef;
                Impact = _entitystatus.param[Charanum].Imap;
                Weight = _entitystatus.param[Charanum].Wei;
                Technology = _entitystatus.param[Charanum].Tec;
                Avoidance = _entitystatus.param[Charanum].Avo;
                break;

        }
    }

    void Update()
    {
        Died();
    }

    public int FroideMAXHP()
    {
        return MAXHP;
    }

    public int FroideHP(int ThisAttack)
    {
        HP = HP - ThisAttack;
        return HP;
    }

    public int FroideAttack()
    {
        return Attack;
    }

    public int FroideMAttck()
    {
        return MagicAttack;
    }

    public int FroideImpact()
    {
        return Impact;
    }

    public int FroideDefance()
    {
        return Defance;
    }

    public int FroideMDefance()
    {
        return MagicDefance;
    }

    public int FroideWeight()
    {
        return Weight;
    }

    public int FroideTechnology()
    {
        return Technology;
    }

    public int FroideAvoidance()
    {
        return Avoidance;
    }

    public void Died()
    {
        if (HP <= 0)
        {
            this.gameObject.transform.localScale -= new Vector3(smallspeed, smallspeed, 0);
            if (this.gameObject.transform.localScale.x <= 0 ||
                this.gameObject.transform.localScale.y <= 0)
            {
                _playerscript.Diedmotion();
                this.gameObject.SetActive(false);

            }
        }
    }

}

