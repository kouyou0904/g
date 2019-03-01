using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCount : MonoBehaviour {

    bool _lose;

    // Use this for initialization
    void Start () {
        _lose = false;
	}
	
	// Update is called once per frame
	void Update () {
		PlayerTeamCounter ();
	}

	public void PlayerTeamCounter() {
		int Count = transform.childCount;
		int answer = 0;
		for (int i = 0; i < Count; i++) {
			if (gameObject.transform.GetChild (i).gameObject.activeSelf) {
				answer++;
			}
		} 

		if (answer == 1) {
           _lose = true;
		}
	}

    public bool PlayerLose() {
        return _lose;
    }

}
