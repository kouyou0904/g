using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamCount : MonoBehaviour {

    bool _victory;

    // Use this for initialization
    void Start() {
        _victory = false;
    }

    // Update is called once per frame
    void Update() {
        EnemyTeamCounter();
    }

    public void EnemyTeamCounter() {
        int Count = transform.childCount;
        int answer = 0;
        for (int i = 0; i < Count; i++) {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf) {
                answer++;
            }
        }

        if (answer == 1) {
            _victory = true;
        }
    }

    public bool PlayerVictory() {
        return _victory;
    }
}
