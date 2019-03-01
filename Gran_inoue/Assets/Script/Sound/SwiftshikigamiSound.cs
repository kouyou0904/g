using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftshikigamiSound : MonoBehaviour {
	[SerializeField]CharacterAnim _characterAnim = null; 

	//モーション別に音を変える
	public AudioClip SwiftshikigamiAttack;
	public AudioClip SwiftshikigamiDown;
	public AudioClip SwiftshikigamiHit;
	public AudioClip SwiftshikigamiWalk;
	public AudioClip SwiftshikigamiMono;
	public AudioClip SwiftshikigamiSkill;
	public AudioClip SwiftshikigamiStand;

	AudioSource audioSource;

	bool _check;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		_check = true;
	}

	// Update is called once per frame
	void Update () {
		//アニメーションフラグで判定をとる--------------------------
		if (_characterAnim.Attack() && _check ) {
			audioSource.PlayOneShot (SwiftshikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim.Down () && _check) {
			audioSource.PlayOneShot (SwiftshikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim.Hit() && _check) {
			audioSource.PlayOneShot(SwiftshikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim.Walk() && _check){
			audioSource.PlayOneShot(SwiftshikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim.Mono() && _check){
			
			_check = true;
		}
		if (_characterAnim.Skill() && _check) {
			audioSource.PlayOneShot(SwiftshikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim.Stand() && _check) {

			_check = true;
		}
	}
}