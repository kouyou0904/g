using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FroideStatus : MonoBehaviour {

	[SerializeField] PlayerScript _playerscript = null;
    public Entity_Status _entitystatus = null;

	public float smallspeed = 0.1f;
    bool died = false;


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
        _entitystatus = Resources.Load("Date/Status") as Entity_Status;
        MAXHP = _entitystatus.param[0].HP;
        HP = _entitystatus.param[0].HP;
        Attack = _entitystatus.param[0].Att;
        Defance = _entitystatus.param[0].Def;
        MagicAttack = _entitystatus.param[0].Matt;
        MagicDefance = _entitystatus.param[0].Mdef;
        Impact = _entitystatus.param[0].Imap;
        Weight = _entitystatus.param[0].Wei;
        Technology = _entitystatus.param[0].Tec;
        Avoidance = _entitystatus.param[0].Avo;
     //   Debug.Log("ふろHP"+HP);

    }

    void Update() {

	}

	public int FroideMAXHP() {
		return MAXHP;
	}

    public int FroideHP (int ThisAttack)
    {
        HP = HP - ThisAttack;
		Died ();
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
        if (!died)
        {
            if (HP <= 0)
            {
                this.gameObject.transform.localScale -= new Vector3(smallspeed, smallspeed, 0);
                if (this.gameObject.transform.localScale.x <= 0 ||
                    this.gameObject.transform.localScale.y <= 0)
                {
                    _playerscript.Diedmotion();
                    Debug.Log("Died");

                    this.gameObject.SetActive(false);
                    died = true;

                }
            }
        }
    }

}
