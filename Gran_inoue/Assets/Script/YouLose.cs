using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouLose : MonoBehaviour {

    float _timeCount; //時間経過を確認するやつ
    bool _sceneMove; //シーン遷移フラグ
    //public bool _countFlag; //時間をはかる為のフラグ


    //------ゲッター-------------
    public bool GetSceneMove() {
        return _sceneMove;
    }
    //----------------------------
	// Use this for initialization
	void Start () {
		 _timeCount = 0;
        _sceneMove = false;
        //_countFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
        _timeCount += Time.deltaTime;
        if(_timeCount >= 2f) {
            _sceneMove = true;
        }
//        Debug.Log(_sceneMove);
	}
}