using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSkill : MonoBehaviour {
    Animator _animator;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Skill() {
        _animator.SetTrigger("SkillFlag");
    }

}
