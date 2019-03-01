using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManeger : MonoBehaviour {
	[SerializeField]GameObject[] _button = new GameObject[20];
	[SerializeField]GameObject[] _posUi = new GameObject[5];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		BattlePosUiButtonResponse ();
	}
    //全部のButtonを押せなくするか押せるようにする-----------------------------------------------------
	public void ButtonResponse(bool x){
		for ( int i = 0; i < _button.Length; i++ ) {
			_button[i].GetComponent<UnityEngine.UI.Button>( ).interactable = x;
		}
	}
    //-----------------------------------------------------------------------------------

    //_posUiを全部表示か非表示にする----------------------------------------------------
    public void PosUiResponse(bool value){ 
		for(int i = 0; i < _posUi.Length; i++){ 
			_posUi[i].SetActive(value);
		}
	}
    //----------------------------------------------------------------------------------

    //_posUiが表示されてるとButtonの制限-------------------------------------------------
    public void PosUiDisplayResponse() {
        for (int i = 0; i < _posUi.Length; i++) {
            for(int a = 0; a < _button.Length; a++) {
                if (_posUi[i].activeInHierarchy) {
                    _button[a].GetComponent<UnityEngine.UI.Button>().interactable = false;
                } else {
                    _button[a].GetComponent<UnityEngine.UI.Button>().interactable = true;
                }
            }
        }
    }
    //-----------------------------------------------------------------------------------

	//相手のターンにButtonの制限-----------------------------------------------------------
	public void EnemyTurnButtonResponse(bool value, int arrayNumber){
		_button[arrayNumber].GetComponent<UnityEngine.UI.Button>().interactable = value;
	}

	//----------------------------------------------------------------------------------

	//_battleUiか_posUi表示してる時にButtonの制限----------------------------------------------------
	public void BattlePosUiButtonResponse(){
		for (int i = 0; i < _posUi.Length; i++) {
			if (_posUi [i].activeInHierarchy) {
				ButtonResponse (false);
			} 
		}
	}
	//-------------------------------------------------------------------------------------
	//_battleUiか_posUi表示してる時にButtonの制限----------------------------------------------------
	public void BattlePosUiButtonResponseTrue(){
		for (int i = 0; i < _posUi.Length; i++) {
			if (!_posUi [i].activeInHierarchy ) {
				ButtonResponse (true);
			} 
		}
	}
    //-------------------------------------------------------------------------------------
    
    //スキルボタンの制限------------------------------------------------------------
    public void SkillButtonRestraction(bool value) {
        _button[2].GetComponent<UnityEngine.UI.Button>().interactable = value;
    }
    //------------------------------------------------------------------------------


}
