using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutIn : MonoBehaviour {

    Animator _animator;

	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //--カットインのStateがスクロールしているかどうかを返す関数-----------------------------
    public bool CutInStart(){
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("CutIn");
        }
    //--------------------------------------------------------------------------------------

    //--カットインのStateがwait状態かどうかを返す関数---------------------------------------
     public bool CutInWait(){
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.IsName("wait2");
        }
    //--------------------------------------------------------------------------------------


    //--現在のStateの再生時間を返す関数( 返り値：0~1(開始時：0, 終了時：1) )----------------
    public float ResearchStatrPlayTime() {
        int layer = _animator.GetLayerIndex("Base Layer");
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(layer);
        return animatorStateInfo.normalizedTime;
    }
    //--------------------------------------------------------------------------------------

	public void CutInMotion(){
		_animator.SetTrigger ("CutInFlag");
	}

	public void CutInWaiting(){
		_animator.SetTrigger ("waitFlag");
	}

}
