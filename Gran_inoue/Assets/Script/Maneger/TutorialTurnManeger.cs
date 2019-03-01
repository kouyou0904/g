using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTurnManeger : MonoBehaviour {

	enum TutorialStatus {
		YOUR_STANDBY_PHASE,
		YOUR_MAIN_PHASE,
		YOUR_END_PHASE,

		ENEMY_STANDBY_PHASE,
		ENEMY_MAIN_PHASE,
		ENEMY_END_PHASE
	}

	TutorialStatus _status;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch ( _status ) {
			case TutorialStatus.YOUR_STANDBY_PHASE:
				break;

			case TutorialStatus.YOUR_MAIN_PHASE:
				break;

			case TutorialStatus.YOUR_END_PHASE:
				break;

			case TutorialStatus.ENEMY_STANDBY_PHASE:
				break;

			case TutorialStatus.ENEMY_MAIN_PHASE:
				break;

			case TutorialStatus.ENEMY_END_PHASE:
				break;
		}
	}
}
