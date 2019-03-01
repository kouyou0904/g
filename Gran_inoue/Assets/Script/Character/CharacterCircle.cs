using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCircle : MonoBehaviour {

	//Vector3 centerVec;

	// Use this for initialization
	void Start () {
		//centerVec = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //キャラのSCの座標----------------------------------
	public void CeterPosSetting( Vector3 PlayerVec ){
		transform.position = PlayerVec;
	}
    //--------------------------------------------------

	public Vector3 CenterVec( ){
		return transform.position;
	}
}
