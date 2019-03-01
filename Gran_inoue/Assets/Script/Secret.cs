using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Secret : MonoBehaviour {
    public int Jump = 0;
    int Count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( Jump <= Count)
        {
            SceneManager.LoadScene("Secret");   
        }
	}

    public void JumpCount()
    {
        Count += 1;
    }
    
    public void SecretScene()
    {
        SceneManager.LoadScene("Secret");

    }
    public void QuestionScene()
    {
        SceneManager.LoadScene("Question");
    }
}
