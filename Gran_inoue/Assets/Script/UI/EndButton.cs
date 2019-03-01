using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour {
	bool _endChecker;
	bool _enemyEndChecker;

	// Use this for initialization
	void Start () {
		_endChecker = false;
		_enemyEndChecker = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void EndCheck(bool value){
		_endChecker = value;
	}

	public void EndTRUE(){
		_endChecker = true;
	}

	public bool EndChecker(){
		return _endChecker;
	}

	public void EnemyEndCheck(bool value){
		_enemyEndChecker = value;
	}

	public bool EnemyEndChecker(){
		return _enemyEndChecker;
	}
}
