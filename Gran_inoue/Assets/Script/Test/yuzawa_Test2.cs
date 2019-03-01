using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuzawa_Test2 : MonoBehaviour {
    [SerializeField]GameObject _Surrender = null;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClicked() {
        bool value = true;
        if ( !_Surrender.activeInHierarchy ) {
            value = true;
        }
        else {
            value = false;
        }
        _Surrender.SetActive(value);
    }
}
