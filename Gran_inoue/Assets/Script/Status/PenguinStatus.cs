using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinStatus : MonoBehaviour {

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
        MAXHP = _entitystatus.param[1].HP;
        HP = _entitystatus.param[1].HP;
        Attack = _entitystatus.param[1].Att;
        Defance = _entitystatus.param[1].Def;
        MagicAttack = _entitystatus.param[1].Matt;
        MagicDefance = _entitystatus.param[1].Mdef;
        Impact = _entitystatus.param[1].Imap;
        Weight = _entitystatus.param[1].Wei;
        Technology = _entitystatus.param[1].Tec;
        Avoidance = _entitystatus.param[1].Avo;
     //   Debug.Log("ぺんHP" + HP);

    }
    void Update(){

	}

	public int PenguinMAXHP(int Skill) {
        MAXHP += Skill;
		return MAXHP;
	}

	public int PenguinHP (int ThisAttack)
	{
		HP = HP - ThisAttack;
		Died ();
		return HP;
	}

	public int PenguinAttack(int UP)
	{
        Attack += UP;
		return Attack;
	}

	public int PenguinMAttck(int UP)
	{
        MagicAttack += UP;
		return MagicAttack;
	}

	public int PenguinImpact(int UP)
	{
        Impact += UP;
		return Impact;
	}

	public int PenguinDefance(int UP)
	{
        Defance += UP;
		return Defance;
	}

	public int PenguinMDefance(int UP)
	{
        MagicDefance += UP;
		return MagicDefance;
	}

	public int PenguinWeight(int UP)
	{
        Weight += UP;
		return Weight;
	}

	public int PenguinTechnology()
	{
		return Technology;
	}

	public int PenguinAvoidance()
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
                    this.gameObject.SetActive(false);
                    died = true;

                }
            }
        }
    }
}

