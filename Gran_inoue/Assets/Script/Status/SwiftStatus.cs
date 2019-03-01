using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftStatus : MonoBehaviour {

	[SerializeField]  PlayerScript _playerscript = null;
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
        MAXHP = _entitystatus.param[2].HP;
        HP = _entitystatus.param[2].HP;
        Attack = _entitystatus.param[2].Att;
        Defance = _entitystatus.param[2].Def;
        MagicAttack = _entitystatus.param[2].Matt;
        MagicDefance = _entitystatus.param[2].Mdef;
        Impact = _entitystatus.param[2].Imap;
        Weight = _entitystatus.param[2].Wei;
        Technology = _entitystatus.param[2].Tec;
        Avoidance = _entitystatus.param[2].Avo;
       // Debug.Log("じんHP" + HP);

    }
    void Update(){
		
	}

	public int SwiftMAXHP() {
		return MAXHP;
	}

    public int SwiftHP(int ThisAttack)
    {
        HP = HP - ThisAttack;
		Died ();
        return HP;
    }

	public int SwiftAttack(int Change)
    {
		Attack = Attack + Change;
        return Attack;
    }

	public int SwiftMAttck(int Change)
    {
		MagicAttack = MagicAttack + Change;
        return MagicAttack;
    }

	public int SwiftImpact(int Change)
    {
		Impact = Impact + Change;
        return Impact;
    }

	public int SwiftDefance(int Change)
    {
		Defance = Defance + Change;
        return Defance;
    }

	public int SwiftMDefance(int Change)
    {
		MagicDefance = MagicDefance + Change;
        return MagicDefance;
    }

	public int SwiftWeight(int Change)
    {
		Weight = Weight + Change;
        return Weight;
    }

	public int SwiftTechnology(int Change)
    {
		Technology = Technology + Change;
        return Technology;
    }

	public int SwiftAvoidance(int Change)
    {
		Avoidance = Avoidance + Change;
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
                    this.gameObject.SetActive(false);
                    died = true;

                }
            }
        }
    }
}
