using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurrederButton : MonoBehaviour {

	[SerializeField]GameObject _surrenderImage = null;
    [SerializeField]CutIn _cutin = null;
	//BottonScriptの取得
	BottonScript _scenes;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void _SurrenderButton(){
		if (!_surrenderImage.activeInHierarchy) {
			_surrenderImage.SetActive (true);
		} else {
			_surrenderImage.SetActive (false);
		}
	}
	public void _SurrendNo(){
		if (_surrenderImage.activeInHierarchy) {
			_surrenderImage.SetActive (false);
		}
	}
    public void SurrendYes() {
		if(_surrenderImage.activeInHierarchy) {
            _surrenderImage.SetActive(false);
            _cutin.CutInMotion();
           
			//シーン遷移
	//		_scenes._Title ();
			//送らせて処理をさせている
		//	Invoke ("Scenechenge", 5.0f);

        }
    }

	void Scenechenge(){
		Debug.Log ("ktkr");
		SceneManager.LoadScene( "GameOver" );
	}
}
