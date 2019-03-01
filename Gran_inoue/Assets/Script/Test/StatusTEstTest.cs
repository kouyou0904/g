using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusTEstTest : MonoBehaviour {

    public Entity_Status _entitystatus = null;
    
    public int Charanum = -1;
    public int spritenum = 0;
    [SerializeField] Sprite[] Icon = null;
    [SerializeField]
    GameObject statusui;

    public static string Name;
   // public static Sprite Icon;
    public static int MAXHP;
    public static int HP;
    public static int Attack;
    public static int MagicAttack;
    public static int Impact;
    public static int Defance;
    public static int MagicDefance;
    public static int Weight;
    public static int Technology;
    public static int Avoidance;

    public GameObject player;
    public GameObject Enemy;

    public Text Text_Name = null;
    public Image Image_Icon = null;
    public Text Text_HP = null;
    public Text Text_Attack = null;
    public Text Text_MagicAttack = null;
    public Text Text_Impact = null;
    public Text Text_Defance = null;
    public Text Text_MagicDefance = null;
    public Text Text_Weight = null;
    public Text Text_Technology = null;
    public Text Text_Avoidance = null;

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        statusui.gameObject.SetActive(false);
        _entitystatus = Resources.Load("Date/Status") as Entity_Status;


        //  _entitystatus.param[0].HP = 1;
        switch (Charanum)
        {
            case 0:
                Name = "フロイデ";
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
                statusui.gameObject.SetActive(true);
                break;

            case 1:
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

        Debug.Log(HP);
        Text_Name.text = Name.ToString();
     //   Image_Icon.sprite = Icon[Charanum];
        Text_HP.text = "HP = " + int.Parse(HP.ToString());
        Text_Attack.text = "攻撃 = " + int.Parse(Attack.ToString());
        Text_MagicAttack.text = "魔攻 = " + int.Parse(MagicAttack.ToString());
        Text_Impact.text = "衝撃 = " + int.Parse(Impact.ToString());
        Text_Defance.text = "防御 = " + int.Parse(Defance.ToString());
        Text_MagicDefance.text = "魔防 = " + int.Parse(MagicDefance.ToString());
        Text_Weight.text = "重さ = " + int.Parse(Weight.ToString());
        Text_Technology.text = "技術 = " + int.Parse(Technology.ToString());
        Text_Avoidance.text = "回避 = " + int.Parse(Avoidance.ToString());
    }


}

