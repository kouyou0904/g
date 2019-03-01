using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningOrLosingSceneTrasition : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Victory() {
        SceneManager.LoadScene("GameClear");
    }

    public void Lose() {
        SceneManager.LoadScene("GameOver");
    }

}