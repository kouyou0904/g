using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCircle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//フィールドの座標----------------------------------
	public void FieldPosSetting( Vector3 FieldVec ){
		transform.position = FieldVec;
	}
	//--------------------------------------------------

	public Vector3 FieldVec( ){
		return transform.position;
	}

}
