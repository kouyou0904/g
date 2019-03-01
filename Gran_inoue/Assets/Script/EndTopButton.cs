using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTopButton : MonoBehaviour {
	[SerializeField]GameObject _button = null;
	public float _countset = 0;
	float _count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_count += Time.deltaTime;
		if (_count > _countset) {
			ButtonResponse (true);
		}
		if (_count < _countset) {
			ButtonResponse (false);
		}

	}
	public void ButtonResponse(bool x){
		_button.GetComponent<UnityEngine.UI.Button>( ).interactable = x;
	}
}
