using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yuzawa_Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Transition() {
        SceneManager.LoadScene ( "Yuzawa_Test2" );
    }
    public void Transition2()
    {
        SceneManager.LoadScene("Yuzawa_Test");
    }
    public void Title()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

}
