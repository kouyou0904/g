using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosDecisionButton : MonoBehaviour {
    [SerializeField]GameObject _posUi = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PosNo() {
        _posUi.SetActive( false );
    }
}
