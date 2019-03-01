using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FroideSound : MonoBehaviour {
	[SerializeField]CharacterAnim _characterAnim = null; 

	//モーション別に音を変える
	public AudioClip FroideAttack;
	public AudioClip FroideDown;
	public AudioClip FroideHit;
	public AudioClip FroideWalk;
	public AudioClip FroideMono;
	public AudioClip FroideSkill;
	public AudioClip FroideStand;

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
			audioSource.PlayOneShot (FroideAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim.Down () && _check) {
			audioSource.PlayOneShot (FroideDown, 0.7F);
			_check = false;
		}
		if (_characterAnim.Hit() && _check) {
			audioSource.PlayOneShot(FroideHit, 0.7F);
			_check = false;
		}

		if(_characterAnim.Walk() && _check){
			audioSource.PlayOneShot(FroideWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim.Mono() && _check){
			
			_check = true;
		}
		if (_characterAnim.Skill() && _check) {
			audioSource.PlayOneShot(FroideSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim.Stand() && _check) {
			
			_check = true;
		}
	}
}

