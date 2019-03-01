using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonScript : MonoBehaviour {

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
	public void CharacterSelect()
	{
		SceneManager.LoadScene("CharacterSelect");
	}
	public void Library() 
	{
		SceneManager.LoadScene( "Library" );
	}
	public void _Main(){
		SceneManager.LoadScene( "Main" );
	}
	public void _Title(){
		SceneManager.LoadScene( "Title" );
	}
    public void _Option()
    {
        SceneManager.LoadScene("Option");
    }
}