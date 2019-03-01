using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSound : MonoBehaviour {
	[SerializeField]CharacterAnim _characterAnim = null; 

	//モーション別に音を変える
	public AudioClip PenguinAttack;
	public AudioClip PenguinDown;
	public AudioClip PenguinHit;
	public AudioClip PenguinWalk;
	public AudioClip PenguinMono;
	public AudioClip PenguinSkill;
	public AudioClip PenguinStand;

	public AudioClip PenguinReinforcedFormAttack;
	public AudioClip PenguinReinforcedFormDown;
	public AudioClip PenguinReinforcedFormHit;
	public AudioClip PenguinReinforcedFormWalk;
	public AudioClip PenguinReinforcedFormMono;
	public AudioClip PenguinReinforcedFormSkill;
	public AudioClip PenguinReinforcedFormStand;

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
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim.Down () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim.Hit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim.Walk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim.Mono() && _check){

			_check = true;
		}
		if (_characterAnim.Skill() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim.Stand() && _check) {

			_check = true;
		}
	
		if (_characterAnim.Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim.Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim.Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim.Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim.Mono() && _check){
			
			_check = true;
		}
		if (_characterAnim.Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim.Stand() && _check) {
			
			_check = true;
		}
	}
}
