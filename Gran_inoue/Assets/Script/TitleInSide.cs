using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInSide : MonoBehaviour {
	[SerializeField]GameObject _tutorialUi = null;
	[SerializeField]GameObject _button = null;
	[SerializeField]GameObject _button2 = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		_tutorialUi.SetActive (false);
		_button.SetActive (true);
		_button2.SetActive (false);
	}
}
