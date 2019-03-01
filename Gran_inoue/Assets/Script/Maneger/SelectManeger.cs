using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectManeger : MonoBehaviour {
    [SerializeField] CharacterSelectYesButton _characterSelectButton = null;
    [SerializeField] LoadSceneManger _loadSceneManger = null;


    bool[] _selectCheck = new bool[6];

	// Use this for initialization
	void Start () {
        for (int i = 0; i < _selectCheck.Length; i++) {
            _selectCheck[i] = CharacterSelectYesButton.SelectNumber(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
        for( int i = 0; i < 6; i++) {
            if (_characterSelectButton.SceneSelectNumber(i)) {
              Invoke ("MainScene", 1f);
                
            }
        }
	}

	public void MainScene(){
        _loadSceneManger.LoadNextScene();
	}
}
