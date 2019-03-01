using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDebug : MonoBehaviour {

    public Entity_Status _status = null;
    public Entity_StatusReset _statusreset = null;

    [SerializeField]
    GameObject _content = null;

    [SerializeField]
    InputField[] _input = new InputField[28];


	// Use this for initialization
	void Start () {

        _status = Resources.Load("Date/Status") as Entity_Status;

        _content.transform.localPosition = new Vector3(0, 0, 0);
        Set();
       
        Debug.Log(_status.param[2].HP);
    }

    // Update is called once per frame
    void Update () {

        if (_content.transform.localPosition.y > 380) {
            _content.transform.localPosition -= new Vector3(0, 50, 0);
        }
        if (_content.transform.localPosition.y < 0)
        {
            _content.transform.localPosition += new Vector3(0,50,0);
        }

    }

    public void StatusSet()
    {
        for (int i = 0; i < 4; i++)
        {
            _status.param[i].HP = int.Parse(_input[0 + (i * 7)].text);
            _status.param[i].Att = int.Parse(_input[1 + (i * 7)].text);
            _status.param[i].Matt = int.Parse(_input[2 + (i * 7)].text);
            _status.param[i].Def = int.Parse(_input[3 + (i * 7)].text);
            _status.param[i].Mdef = int.Parse(_input[4 + (i * 7)].text);
            _status.param[i].Imap = int.Parse(_input[5 + (i * 7)].text);
            _status.param[i].Wei = int.Parse(_input[6 + (i * 7)].text);
        }
    }
    
    public void Set()
    {
        for (int i = 0; i < 4; i++)
        {
            _input[0 + (i * 7)].text = "" + _status.param[i].HP.ToString();
            _input[1 + (i * 7)].text = "" + _status.param[i].Att.ToString();
            _input[2 + (i * 7)].text = "" + _status.param[i].Matt.ToString();
            _input[3 + (i * 7)].text = "" + _status.param[i].Def.ToString();
            _input[4 + (i * 7)].text = "" + _status.param[i].Mdef.ToString();
            _input[5 + (i * 7)].text = "" + _status.param[i].Imap.ToString();
            _input[6 + (i * 7)].text = "" + _status.param[i].Wei.ToString();
        }
    }

    public void Reset()
    {
        _statusreset = Resources.Load("Date2/StatusReset") as Entity_StatusReset;

        for (int i = 0; i < 4; i++)
        {
            _status.param[i].HP   = _statusreset.param[i].HP;
            _status.param[i].Att  = _statusreset.param[i].Att ;
            _status.param[i].Matt = _statusreset.param[i].Matt;
            _status.param[i].Def  = _statusreset.param[i].Def ;
            _status.param[i].Mdef = _statusreset.param[i].Mdef;
            _status.param[i].Imap = _statusreset.param[i].Imap;
            _status.param[i].Wei  = _statusreset.param[i].Wei ;
        }
        Set();
    }
}
