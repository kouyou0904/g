using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour {

	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //決定ボタンを押すとフラグに反応してキャラクターが動く
	public void AttackAnim(){
		animator.SetTrigger ("AttackFlag");
	}
	public void DownAnim(){
		animator.SetTrigger ("DownFlag");
	}
    public void HitAnim() {
        animator.SetTrigger("HitFlag");
    }
    public void SkillMissAnim(){
        animator.SetTrigger("SkillMissFlag");
    }
    public void WalkAnim() {
        animator.SetTrigger("WalkFlag");
    }
    public void MonoAnim(){
        animator.SetTrigger("MonoFlag");
    }
    public void SkillStartAnim(){
        animator.SetTrigger("SkillStartFlag");
    }
}

