using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManger : MonoBehaviour {
    private AsyncOperation async;
    public GameObject LoadingUi;
    public Slider Slider;
    bool loadset = false;

    public void LoadNextScene()
    {
        if ( !loadset ) {
            LoadingUi.SetActive(true);
            StartCoroutine(LoadScene());
            loadset = true;
        }
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("main");

        while (!async.isDone)
        {
            Slider.value = async.progress;
            yield return null;
        }
    }
}
