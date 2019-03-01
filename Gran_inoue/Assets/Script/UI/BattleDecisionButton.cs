using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDecisionButton : MonoBehaviour {
    [SerializeField] GameObject _battleUi = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BattleUiDecision() {
        _battleUi.SetActive(false);
    }

}
