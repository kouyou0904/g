using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackCircle : MonoBehaviour {
    bool _check;
    int _circleChara;
	int _exitCircleChara = -1;
	Vector2 Vec;

	// Use this for initialization
	void Start () {
        _check = false;
        _circleChara = -1;
		_exitCircleChara = -1;
	}
	
	// Update is called once per frame
	void Update () {
		Vec = this.transform.position;
	}
	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Enemy" ||
            other.gameObject.tag == "SubEnemy"){
            _check = true;
			_exitCircleChara = -1;
            _circleChara = other.gameObject.GetComponent<CharacterWalk>().ARRAYNUMBER;
        }
    }

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag == "Enemy" ||
			other.gameObject.tag == "SubEnemy" ){
			_check = false;
			_circleChara = -1;
            _exitCircleChara = other.gameObject.GetComponent<CharacterWalk>().ARRAYNUMBER;
		}
	}

    public bool CircleCheck() {
        return _check;
    }

    public void NoCheck(){
        _check = false;
    }

	//ACの座標----------------------------------
	public void AcPosSetting( Vector2 AcVec ){
		transform.position = AcVec;
	}
	//--------------------------------------------------

	public Vector2 AcVec( ){
		return Vec;
	}

    public int GetCircleChara() {
        return _circleChara;
    }
	 public int GetExitCircleChara() {
        return _exitCircleChara;
    }
}
