using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwftShikigamiStandStatus : MonoBehaviour {

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
        MAXHP = _entitystatus.param[3].HP;
        HP = _entitystatus.param[3].HP;
        Attack = _entitystatus.param[3].Att;
        Defance = _entitystatus.param[3].Def;
        MagicAttack = _entitystatus.param[3].Matt;
        MagicDefance = _entitystatus.param[3].Mdef;
        Impact = _entitystatus.param[3].Imap;
        Weight = _entitystatus.param[3].Wei;
        Technology = _entitystatus.param[3].Tec;
        Avoidance = _entitystatus.param[3].Avo;
      //  Debug.Log("しきP" + HP);

    }

    void Update(){

	}

	public int SwiftShikigamiMAXHP() {
		return MAXHP;
	}

	public int SwiftShikigamiHP (int ThisAttack)
	{
		HP = HP - ThisAttack;
		Died ();
		return HP;
	}

	public int SwiftShikigamiAttack()
	{
		return Attack;
	}

	public int SwiftShikigamiMAttck()
	{
		return MagicAttack;
	}

	public int SwiftShikigamiImpact()
	{
		return Impact;
	}

	public int SwiftShikigamiDefance()
	{
		return Defance;
	}

	public int SwiftShikigamiMDefance()
	{
		return MagicDefance;
	}

	public int SwiftShikigamiWeight()
	{
		return Weight;
	}

	public int SwiftShikigamiTechnology()
	{
		return Technology;
	}

	public int SwiftShikigamiAvoidance()
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
                    Debug.Log("とおったんぐ");
                    died = true;
                }
            }
        }
    }
}
