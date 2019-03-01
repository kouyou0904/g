using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("changeScene", 44f);
	}


	// Update is called once per frame
	void Update () {

	}

	void changeScene()
	{
		SceneManager.LoadScene ("Title");
	}
}
