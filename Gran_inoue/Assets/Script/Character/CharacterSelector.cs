using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {
    [SerializeField]CharacterSelectYesButton _characterSelectYesButton = null;
    [SerializeField]GameObject[] _team = new GameObject[6];
    [SerializeField]GameObject[] _enemyTeam = new GameObject[6]; 

    bool[] _selectCheck = new bool[6];

	// Use this for initialization
	void Start () {
        for (int i = 0; i < _selectCheck.Length; i++){
            _selectCheck[i] = CharacterSelectYesButton.SelectNumber(i);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TeamApper(  ) {
        for (int i = 0; i < _team.Length; i++) {
            if (_selectCheck[i]) {
                _team[i].SetActive(true);
            }
            if( !_selectCheck[i])
            {
                _team[i].SetActive(false);
            }
         }
    }
    public void EnemyTeamApper( ) {
        for (int i = 0; i < _enemyTeam.Length; i++) {
            if (_selectCheck[i]) {
                _enemyTeam[i].SetActive(true);
            }
            if (!_selectCheck[i])
            {
                _enemyTeam[i].SetActive(false);
            }
        }
    }
}
