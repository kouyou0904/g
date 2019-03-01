using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim: MonoBehaviour {
    
    Animator _animator;

    // Use this for initialization
    void Start( ) {
        _animator = GetComponentInChildren<Animator>( );
    }

    // Update is called once per frame
    void Update( ) {

    }
    public void Replace( ) {
        _animator.SetTrigger( "ReplaceFlag" );
    }

    public void Clicked( int ArrayNumber ) {
		for (int i = 0; i < ArrayNumber; i++)
			if ( i == ArrayNumber ) {
				_animator.SetTrigger("CharacterSelectFlag");
			}
    }
    
    public void ScrollDisapper( ) {
        _animator.SetTrigger( "1-2Disapper" );
    }

	public void PenguinAttack(){
		_animator.SetTrigger ("PenguinAttackFlag");
	}




}