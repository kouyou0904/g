using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_Status : ScriptableObject
{	
	public List<Param> param = new List<Param> ();

	[System.SerializableAttribute]
	public class Param
	{
		
		public string ID;
		public string NAME;
		public int HP;
		public int Att;
		public int Def;
		public int Matt;
		public int Mdef;
		public int Imap;
		public int Wei;
		public int Tec;
		public int Avo;
	}
}