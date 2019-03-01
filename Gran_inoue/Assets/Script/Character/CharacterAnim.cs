using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour {
	Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//--攻撃のStateをしているかどうかを返す関数---------------------------------------------
	public bool Attack(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("Attack");
	}
	//--------------------------------------------------------------------------------------

	//--倒れてるかのStateをしているかどうかを返す関数---------------------------------------
	public bool Down(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("Down");
	}
    //--------------------------------------------------------------------------------------

    //--当たるのStateをしているかどうかを返す関数-------------------------------------------
    public bool Hit()
    {
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("Hit");
    }
    //--------------------------------------------------------------------------------------

    //--スキル失敗のStateをしているかどうかを返す関数---------------------------------------
    public bool SkillMiss()
    {
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("SkillMiss");
    }
    //--------------------------------------------------------------------------------------

    //--歩きのStateをしているかどうかを返す関数---------------------------------------------
    public bool Walk(){
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("Walk");
    }
    //--------------------------------------------------------------------------------------

    //--MonoのStateをしているかどうかを返す関数---------------------------------------------
    public bool Mono()
    {
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("Mono");
    }
    //--------------------------------------------------------------------------------------

    //--SkillのStateをしているかどうかを返す関数---------------------------------------------
    public bool Skill() {
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("Skill");
    }
    //--------------------------------------------------------------------------------------

    //--SkillのStateをしているかどうかを返す関数---------------------------------------------
    public bool Roop() {
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("Roop");
    }
    //--------------------------------------------------------------------------------------

    //--強化形態がStandどうかを返す関数-------------------------------------
    public bool PenguinReinforcedFormStand(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("PenguinReinforcedFormStand");
	}
	//--------------------------------------------------------------------------------------

	//--強化形態がHitどうかを返す関数-------------------------------------
	public bool PenguinReinforcedFormHit(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("PenguinReinforcedFormHit");
	}
	//--------------------------------------------------------------------------------------

	//--強化形態がDownどうかを返す関数-------------------------------------
	public bool PenguinReinforcedFormDown(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("PenguinReinforcedFormDown");
	}
	//--------------------------------------------------------------------------------------

	//--強化形態がAttackどうかを返す関数-------------------------------------
	public bool PenguinReinforcedFormAttack(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("PenguinReinforcedFormAttack");
	}
	//--------------------------------------------------------------------------------------

	//--強化形態がWalkどうかを返す関数-------------------------------------
	public bool PenguinReinforcedFormWalk(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("PenguinReinforcedFormWalk");
	}
	//--------------------------------------------------------------------------------------

	//--強化形態がMonoどうかを返す関数-------------------------------------
	public bool PenguinReinforcedFormMono(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("PenguinReinforcedFormMono");
	}
	//--------------------------------------------------------------------------------------

    //--キャラクターのStateが待機状態かどうかを返す関数-------------------------------------
    public bool Stand(){
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.IsName("Stand");
	}
    //--------------------------------------------------------------------------------------

    //--現在のStateの再生時間を返す関数( 返り値：0~1(開始時：0, 終了時：1) )----------------
    public float ResearchStatrPlayTime() {
		int layer = _animator.GetLayerIndex("Base Layer");
		AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
		return animatorStateInfo.normalizedTime;
	}
	//--------------------------------------------------------------------------------------

}
