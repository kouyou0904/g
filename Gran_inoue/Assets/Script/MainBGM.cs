using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBGM : MonoBehaviour {
	AudioSource _audioSource ;
	public AudioClip YourTurn;
	public AudioClip EnemyTurn;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void YouBGM(){
		_audioSource.clip = YourTurn;
		_audioSource.Play ();

	}

	public void EnemyBGM(){
		_audioSource.clip = EnemyTurn;
		_audioSource.Play ();
	}
}
