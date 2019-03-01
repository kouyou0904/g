using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {
	[SerializeField]GameObject[] _characterSelectButton = new GameObject[6];                //チームの画像
	[SerializeField]CharacterSelectButton _characterSelectButton2 = null;
	Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponentInChildren<Animator>( );
	}
	
	// Update is called once per frame
	void Update (){
		
	}

    //格チームの画像の非表示----------------------------------------
	public void ScrollDisapper0 (){
		if (_characterSelectButton [0].activeInHierarchy) {
			_animator.SetTrigger ("1-2Disapper");
			Invoke ("ReOK", 1.43f);
		}
	}

	public void ScrollDisapper1 (){
		if (_characterSelectButton [1].activeInHierarchy) {
			_animator.SetTrigger ("1-2Disapper");
			Invoke ("ReOK", 1.43f);
		}
	}

	public void ScrollDisapper2 (){
		if (_characterSelectButton [2].activeInHierarchy) {
			_animator.SetTrigger ("1-2Disapper");
			Invoke ("ReOK", 1.43f);
		}
	}

	public void ScrollDisapper3 (){
		if (_characterSelectButton [3].activeInHierarchy) {
			_animator.SetTrigger ("1-2Disapper");
			Invoke ("ReOK", 1.43f);
		}
	}

	public void ScrollDisapper4 (){
		if (_characterSelectButton [4].activeInHierarchy) {
			_animator.SetTrigger ("1-2Disapper");
			Invoke ("ReOK", 1.43f);
		}
	}

	public void ScrollDisapper5 (){
		if (_characterSelectButton [5].activeInHierarchy) {
			_animator.SetTrigger ("1-2Disapper");
			Invoke ("ReOK", 1.43f);
		}
	}
    //-------------------------------------------------------------

	void ReOK(){
		_characterSelectButton2.CharacterSelectResponse (true);
	}

    //画像を非表示にしてる------------------------------------------
	public void ScrollRear (){
		for (int i = 0; i < _characterSelectButton.Length; i++) {
			_characterSelectButton [i].SetActive (false);
		}
	}
    //--------------------------------------------------------------
}
