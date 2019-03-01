using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateSave : MonoBehaviour {

    string key = "good";
    string keys = "bad";
    int good;
    int bad;
    public Text _goodnum;
    public Text _badnun;

    string yeskey = "yes";
    string nokey = "no";
    int yes;
    int no;
    public Text _yesnum;
    public Text _nonun;

    [SerializeField]
    GameObject _realyset = null;


	// Use this for initialization
	void Start () {
        good = PlayerPrefs.GetInt(key);
        bad = PlayerPrefs.GetInt(keys);

        yes = PlayerPrefs.GetInt(yeskey);
        no = PlayerPrefs.GetInt(nokey);
    }
	
	// Update is called once per frame
	void Update () {
        _goodnum.text = good.ToString() + " Good";
        _badnun.text = bad.ToString() + " Bad";

        _yesnum.text = yes.ToString() + " Yes";
        _nonun.text = no.ToString() + " No";

    }

    public void goodbotton()
    {
        good += 1;
        PlayerPrefs.SetInt(key, good);
        PlayerPrefs.Save();

    }
    public void badbotton()
    {
        bad += 1;
        PlayerPrefs.SetInt(keys, bad);
        PlayerPrefs.Save();
    }

    public void yesbotton()
    {
        yes += 1;
        PlayerPrefs.SetInt(yeskey, yes);
        PlayerPrefs.Save();

    }
    public void nobotton()
    {
        no += 1;
        PlayerPrefs.SetInt(nokey, no);
        PlayerPrefs.Save();
    }


    public void reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        good = PlayerPrefs.GetInt(key);
        bad = PlayerPrefs.GetInt(keys);
        yes = PlayerPrefs.GetInt(yeskey);
        no = PlayerPrefs.GetInt(nokey);
        _realyset.SetActive(false);

    }

    public void Realy()
    {
        _realyset.SetActive(true);
    }
    public void cansel()
    {
        _realyset.SetActive(false);

    }
}
