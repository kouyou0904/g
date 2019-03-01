using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftSound : MonoBehaviour {

	[SerializeField]CharacterAnim _characterAnim = null; 

	//モーション別に音を変える
	public AudioClip SwiftAttack;
	public AudioClip SwiftDown;
	public AudioClip SwiftHit;
	public AudioClip SwiftWalk;
	public AudioClip SwiftMono;
	public AudioClip SwiftSkill;
	public AudioClip SwiftStand;

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
		if (_characterAnim.Attack () && _check) {
			audioSource.PlayOneShot (SwiftAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim.Down () && _check) {
			audioSource.PlayOneShot (SwiftDown, 0.7F);
			_check = false;
		}
		if (_characterAnim.Hit () && _check) {
			audioSource.PlayOneShot (SwiftHit, 0.7F);
			_check = false;
		}

		if (_characterAnim.Walk () && _check) {
			audioSource.PlayOneShot (SwiftWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim.Mono () && _check) {

			_check = true;
		}
		if (_characterAnim.Skill () && _check) {
			audioSource.PlayOneShot (SwiftSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim.Stand () && _check) {

			_check = true;
		}
	}
}
