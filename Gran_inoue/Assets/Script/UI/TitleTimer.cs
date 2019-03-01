using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleTimer : MonoBehaviour {
    [SerializeField]
    Text _titletimer = null;

    [SerializeField]
    InputField _inputfield = null;

    float time = 0;

	// Use this for initialization
	void Start () {
        time = TutorialButton._stanbyNum;
        _inputfield.text = "" + time.ToString();

    }

    // Update is called once per frame
    void Update () {
        TutorialButton._stanbyNum = float.Parse (_titletimer.text);
        Debug.Log(TutorialButton._stanbyNum);
    }
}
