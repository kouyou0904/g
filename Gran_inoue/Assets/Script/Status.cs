//ステータスUIをアクティブにする
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour {

	public static string Name;
	public static Sprite Icon;
	public static int HP;
	public static int Attack;
	public static int MagicAttack;
	public static int Impact;
	public static int Defance;
	public static int MagicDefance;
	public static int Weight;
	public static int Technology;
	public static int Avoidance;

	public Status( string name, int hp, int att, int M_att, int imp, int def, int M_def, int wei, int tec, int avo) {
		Name = name;
		HP = hp;
		Attack = att;
		MagicAttack = M_att;
		Impact = imp;
		Defance = def;
		MagicDefance = M_def;
		Weight = wei;
		Technology = tec;
		Avoidance = avo;
	}
		
		
	public GameObject player;
	public GameObject Enemy;

	public Text Text_Name;
	public Image Image_Icon;
	public Text Text_HP;
	public Text Text_Attack;
	public Text Text_MagicAttack;
	public Text Text_Impact;
	public Text Text_Defance;
	public Text Text_MagicDefance;
	public Text Text_Weight;
	public Text Text_Technology;
	public Text Text_Avoidance;

	// Use this for initialization
	void Start () {
		Text_Name.text = Status.Name;
		Image_Icon.sprite = Status.Icon;
		Text_HP.text = "HP ： " + Status.HP;
		Text_Attack.text = "攻撃 ： " + Status.Attack;
		Text_MagicAttack.text = "魔攻 ： " + Status.MagicAttack;
		Text_Impact.text = "衝撃 ： " + Status.Impact;
		Text_Defance.text = "防御 ： " + Status.Defance;
		Text_MagicDefance.text = "魔防 ： " + Status.MagicDefance;
		Text_Weight.text = "重さ ： " + Status.Weight;
		Text_Technology.text = "技術 ： " + Status.Technology;
		Text_Avoidance.text = "回避 ： " + Status.Avoidance;
	}
	
	// Update is called once per frame
	void Update () {
		Text_Name.text = Status.Name.ToString();
		Image_Icon.sprite = Status.Icon;
		Text_HP.text = "HP ： " + Status.HP.ToString();
		Text_Attack.text = "攻撃 ： " + Status.Attack.ToString();
		Text_MagicAttack.text = "魔攻 ： " + Status.MagicAttack.ToString();
		Text_Impact.text = "衝撃 ： " + Status.Impact.ToString();
		Text_Defance.text = "防御 ： " + Status.Defance.ToString();
		Text_MagicDefance.text = "魔防 ： " + Status.MagicDefance.ToString();
		Text_Weight.text = "重さ ： " + Status.Weight.ToString();
		Text_Technology.text = "技術 ： " + Status.Technology.ToString();
		Text_Avoidance.text = "回避 ： " + Status.Avoidance.ToString();
	}

}
