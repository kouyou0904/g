using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectYesButton : MonoBehaviour {

   public static bool[] _decision = new bool[6];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < _decision.Length; i++){
            _decision[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //格チームのYesボタンをおしたときにどのボタンが押されたかどうか----------------
    public void SelectJugement(int arrayNumber) {
        for (int i = 0; i < _decision.Length; i++) {
            if (i == arrayNumber) {
                _decision[arrayNumber] = true;
            }
        }
    }

    //------------------------------------------------------------------------------

    public static bool SelectNumber(int arrayNumber) {
         return _decision[arrayNumber];
    }

    public bool SceneSelectNumber(int arrayNumber){
        return _decision[arrayNumber];
    }
}
