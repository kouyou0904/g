using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutInManeger : MonoBehaviour {
    [SerializeField] GameObject _yourTurn = null;
    [SerializeField] GameObject _youTurnEnd = null;
    [SerializeField] GameObject _enemyTurn = null;
    [SerializeField] GameObject _enemyTurnEnd = null;
    [SerializeField] GameObject _youwin = null;
    [SerializeField] GameObject _youlose = null;
    [SerializeField] GameObject _down = null;
    [SerializeField] GameObject _giveUp = null;
	[SerializeField] GameObject _firstCutIn = null;
    bool _cutIn;

    // Use this for initialization
    void Start () {
        _cutIn = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool TurnCutIn() {
        return _cutIn;
    }

    //各カットインの表示-----------------------------
    public void MyTurn(bool value) {
        _yourTurn.SetActive(value);
        _cutIn = value;
    }

    public void MyTurnEnd(bool value) {
        _youTurnEnd.SetActive(value);
    }

    public void EnemyTurn(bool value) {
        _enemyTurn.SetActive(value);
    }

    public void EnemyTurnEnd(bool value) {
        _enemyTurnEnd.SetActive(value);
    }

    public void YouWin(bool value) {
        _youwin.SetActive(value);
    }

    public void YouLose(bool value) {
        _youlose.SetActive(value);
    }

    public void Down(bool value) {
        _down.SetActive(value);
    }

    public void GiveUp(bool value) {
        _giveUp.SetActive(value);
    }

	public void FirstCutIn(){
		Destroy(_firstCutIn);
	}
    //-----------------------------------------------------

}
