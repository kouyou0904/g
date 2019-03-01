using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour {
	Animator _animator;
	bool _yesCheck;
	bool _noCheck;

	public float _count = 0;
	public static float _stanbyNum = 30; 

	// Use this for initialization
	void Start () {

		_yesCheck = false;
		_noCheck = false;
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		_count += Time.deltaTime;
		TutorialStart( );
	}
	public void Yes(){
		_animator.SetTrigger ("ScrollTrasition");
		CountReset( );
	}

	public void No(){
		_noCheck = true;
		_animator.SetTrigger ("ScrollTrasition");
	}

	void TutorialStart(){
		if ( _count >= _stanbyNum ) {
			SceneManager.LoadScene( "Tutorial" );
		}
	}

	void TutorialSkip(){
		SceneManager.LoadScene("CharacterSelect");
	}

	public void CountReset(){
		_count = 0;
	}

	public void GetStanbyNum(float num){
		_stanbyNum = num;
	}

	public float SetStanbyNum(){
		return _stanbyNum;
	}
}
