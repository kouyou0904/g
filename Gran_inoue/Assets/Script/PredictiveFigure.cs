using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictiveFigure : MonoBehaviour {
    [SerializeField]GameObject[] _uiCircle = new GameObject[2];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void _predictiveFigur() {
        for( int i = 0; i < _uiCircle.Length; i++ ) {
           if ( !_uiCircle[i].activeInHierarchy ) {
                 _uiCircle[i].SetActive(true);
            }else {
                _uiCircle[i].SetActive(false);
            }
            
        }
    }

}
