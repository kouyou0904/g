using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButton : MonoBehaviour {
   // [SerializeField] GameObject _scrollCanvas = null;
  //  bool Check;
    Animator _animator;

	// Use this for initialization
	void Start () {
       // Check = false;
        _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void scroll() {
        bool value = true;
        if (!_animator.GetBool("ScrollFlag")){
            value = true;
        }else{
            value = false;
        }
        _animator.SetBool("ScrollFlag", value);
    }
    public void CanvasApper() {
      /*  if (!_scrollCanvas.activeInHierarchy){
            _scrollCanvas.SetActive(true);
        } else {
            _scrollCanvas.SetActive(false);
        }*/
    }

}
