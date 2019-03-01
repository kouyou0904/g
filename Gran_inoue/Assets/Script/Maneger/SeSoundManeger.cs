using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeSoundManeger : MonoBehaviour {

	[SerializeField]CharacterAnim[] _characterAnim = new CharacterAnim[20]; 


    //モーション別に音を変える
	public AudioClip FuroideAttack;
	public AudioClip FuroideDown;
	public AudioClip FuroideHit;
	public AudioClip FuroideWalk;
	public AudioClip FuroideMono;
	public AudioClip FuroideSkill;

	public AudioClip PenguinReinforcedFormAttack;
	public AudioClip PenguinReinforcedFormDown;
	public AudioClip PenguinReinforcedFormHit;
	public AudioClip PenguinReinforcedFormWalk;
	public AudioClip PenguinReinforcedFormMono;


	public AudioClip PenguinAttack;
	public AudioClip PenguinDown;
	public AudioClip PenguinHit;
	public AudioClip PenguinWalk;
	public AudioClip PenguinMono;
	public AudioClip PenguinSkill;

	public AudioClip SwiftAttack;
	public AudioClip SwiftDown;
	public AudioClip SwiftHit;
	public AudioClip SwiftWalk;
	public AudioClip SwiftMono;
	public AudioClip SwiftSkill;

	public AudioClip SwiftShikigamiAttack;
	public AudioClip SwiftShikigamiDown;
	public AudioClip SwiftShikigamiHit;
	public AudioClip SwiftShikigamiWalk;
	public AudioClip SwiftShikigamiMono;
	public AudioClip SwiftShikigamiSkill;

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
			if (_characterAnim[0].Attack() && _check ) {
			audioSource.PlayOneShot (FuroideAttack, 0.7F);
				_check = false;
			}
			if (_characterAnim [0].Down () && _check) {
			audioSource.PlayOneShot (FuroideDown, 0.7F);
				_check = false;
			}
            if (_characterAnim[0].Hit() && _check) {
			audioSource.PlayOneShot(FuroideHit, 0.7F);
                _check = false;
            }
            
            if(_characterAnim[0].Walk() && _check){
			audioSource.PlayOneShot(FuroideWalk, 0.7F);
                _check = false;
            }
            if (_characterAnim[0].Mono() && _check){
			audioSource.PlayOneShot(FuroideMono, 0.7F);
                _check = false;
            }
            if (_characterAnim[0].Skill() && _check) {
			audioSource.PlayOneShot(FuroideSkill, 0.7F);
                _check = false;
            }
		if (_characterAnim[1].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [1].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[1].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[1].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[1].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[1].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}

		if (_characterAnim[1].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [1].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[1].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[1].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[1].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}

		if (_characterAnim[2].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [2].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[2].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[2].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[2].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[2].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[2].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [2].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[2].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[2].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[2].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}

		if (_characterAnim[3].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [3].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[3].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[3].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[3].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[3].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[3].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [3].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[3].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[3].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[3].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}

		if (_characterAnim[4].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [4].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[4].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[4].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[4].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[4].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[4].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [4].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[4].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[4].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[4].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[5].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [5].Down () && _check) {
			audioSource.PlayOneShot (SwiftDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[5].Hit() && _check) {
			audioSource.PlayOneShot(SwiftHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[5].Walk() && _check){
			audioSource.PlayOneShot(SwiftWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[5].Mono() && _check){
			audioSource.PlayOneShot(SwiftMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[5].Skill() && _check) {
			audioSource.PlayOneShot(SwiftSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[6].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [6].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[6].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[6].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[6].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[6].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[7].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [7].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[7].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[7].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[7].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[7].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[8].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [8].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[8].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[8].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[8].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[8].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[9].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [9].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[9].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[9].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[9].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[9].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[10].Attack() && _check ) {
			audioSource.PlayOneShot (FuroideAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [10].Down () && _check) {
			audioSource.PlayOneShot (FuroideDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[10].Hit() && _check) {
			audioSource.PlayOneShot(FuroideHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[10].Walk() && _check){
			audioSource.PlayOneShot(FuroideWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[10].Mono() && _check){
			audioSource.PlayOneShot(FuroideMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[10].Skill() && _check) {
			audioSource.PlayOneShot(FuroideSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[11].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [11].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[11].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[11].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[11].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[11].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}

		if (_characterAnim[11].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [11].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[11].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[11].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[11].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}

		if (_characterAnim[12].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [12].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[12].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[12].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[12].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[12].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}

		if (_characterAnim[12].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [12].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[12].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[12].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[12].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}

		if (_characterAnim[13].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [13].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[13].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[13].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[13].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[13].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}

		if (_characterAnim[13].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [13].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[13].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[13].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[13].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}

		if (_characterAnim[14].Attack() && _check ) {
			audioSource.PlayOneShot (PenguinAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim[14].Down () && _check) {
			audioSource.PlayOneShot (PenguinDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[14].Hit() && _check) {
			audioSource.PlayOneShot(PenguinHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[14].Walk() && _check){
			audioSource.PlayOneShot(PenguinWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[14].Mono() && _check){
			audioSource.PlayOneShot(PenguinMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[14].Skill() && _check) {
			audioSource.PlayOneShot(PenguinSkill, 0.7F);
			_check = false;
		}

		if (_characterAnim[14].PenguinReinforcedFormAttack() && _check ) {
			audioSource.PlayOneShot (PenguinReinforcedFormAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [14].PenguinReinforcedFormDown () && _check) {
			audioSource.PlayOneShot (PenguinReinforcedFormDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[14].PenguinReinforcedFormHit() && _check) {
			audioSource.PlayOneShot(PenguinReinforcedFormHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[14].PenguinReinforcedFormWalk() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[14].PenguinReinforcedFormMono() && _check){
			audioSource.PlayOneShot(PenguinReinforcedFormMono, 0.7F);
			_check = false;
		}

		if (_characterAnim[15].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [15].Down () && _check) {
			audioSource.PlayOneShot (SwiftDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[15].Hit() && _check) {
			audioSource.PlayOneShot(SwiftHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[15].Walk() && _check){
			audioSource.PlayOneShot(SwiftWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[15].Mono() && _check){
			audioSource.PlayOneShot(SwiftMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[15].Skill() && _check) {
			audioSource.PlayOneShot(SwiftSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[16].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [16].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[16].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[16].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[16].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[16].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[17].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [17].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[17].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[17].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[17].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[17].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[18].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [18].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[18].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[18].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[18].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[18].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
		if (_characterAnim[19].Attack() && _check ) {
			audioSource.PlayOneShot (SwiftShikigamiAttack, 0.7F);
			_check = false;
		}
		if (_characterAnim [19].Down () && _check) {
			audioSource.PlayOneShot (SwiftShikigamiDown, 0.7F);
			_check = false;
		}
		if (_characterAnim[19].Hit() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiHit, 0.7F);
			_check = false;
		}

		if(_characterAnim[19].Walk() && _check){
			audioSource.PlayOneShot(SwiftShikigamiWalk, 0.7F);
			_check = false;
		}
		if (_characterAnim[19].Mono() && _check){
			audioSource.PlayOneShot(SwiftShikigamiMono, 0.7F);
			_check = false;
		}
		if (_characterAnim[19].Skill() && _check) {
			audioSource.PlayOneShot(SwiftShikigamiSkill, 0.7F);
			_check = false;
		}
        }
        //-----------------------------------------------------------
}
