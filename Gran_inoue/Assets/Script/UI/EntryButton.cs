using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryButton : MonoBehaviour {
	[SerializeField]GameObject _entryButton = null;
	[SerializeField]GameObject _tutorialUi = null;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnEntry(){
		_entryButton.SetActive (true);
		//Invoke ("UiActive", 0.5f);
	}

	public void UiActive(){
		_tutorialUi.SetActive (true);
	}
		
}
