using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectButton : MonoBehaviour {
	[SerializeField]GameObject[] _characterSelectButton = new GameObject[6];
	[SerializeField]GameObject[] _caracterButton = new GameObject[6];

	static int Loadnumber;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	}
	public void Clicked( int ArrayNumber ) {
		bool value = true;
		for (int i = 0; i < _characterSelectButton.Length; i++) {
			if (i == ArrayNumber) {
				if (!_characterSelectButton [i].activeInHierarchy) {
					Loadnumber = i;
				}
				_characterSelectButton [i].SetActive (value);
				CharacterSelectResponse (false);
			}
		}
	}
	public void CharacterSelectResponse(bool x){
		for( int i = 0; i < _characterSelectButton.Length; i++ ){
			_caracterButton[i].GetComponent<UnityEngine.UI.Button>().interactable = x;
		}
	}

}	
