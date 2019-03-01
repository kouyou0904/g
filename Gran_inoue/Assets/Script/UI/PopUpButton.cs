using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpButton : MonoBehaviour {
    [SerializeField] GameObject[] _popUp = new GameObject[5];
    Camera _camera;
    Vector3 _cameraposi;


    int _pagenum = 0;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();
        Vector3 _cameraposi = this.transform.localPosition;
       _cameraposi = new Vector3(0, 0, -10);

    }

    // Update is called once per frame
    void Update () {
  
	}
    public void Pagenext()
    {
        _pagenum += 1;
        Slide0();
    }
    public void Pageback()
    {
        _pagenum -= 1;
        Slide0();
    }
    public void PageSkip()
    {
        _pagenum = -1;
        Slide0();
    }

    public void Slide0() {
        switch (_pagenum) {
            case -2:
                _pagenum = -1;
                break;
            case -1:
                for(int i = 0; i < 5; i++ ){
                    _popUp[i].SetActive(false);

                }
                    _cameraposi = new Vector3(0, 0, -10);
                break;
            case 0:
                _popUp[_pagenum].SetActive(true);
                _popUp[_pagenum + 1].SetActive(false);
                _cameraposi = new Vector3(0, 60, -10);

                break;
            case 1:
                 _popUp[_pagenum - 1].SetActive(false);
                 _popUp[_pagenum].SetActive(true);
                _popUp[_pagenum + 1].SetActive(false);
                break;
            case 2:
                _popUp[_pagenum - 1].SetActive(false);
                _popUp[_pagenum].SetActive(true);
                _popUp[_pagenum + 1].SetActive(false);
                break;
            case 3:
                _popUp[_pagenum - 1].SetActive(false);
                _popUp[_pagenum].SetActive(true);
                _popUp[_pagenum + 1].SetActive(false);
                break;
            case 4:
                _popUp[_pagenum - 1].SetActive(false);
                _popUp[_pagenum].SetActive(true);
                break;
            case 5:
                _popUp[_pagenum - 1].SetActive(false);
                _pagenum = -1;
                break;
        }
    }

    public void ReverseSlide() {

    }


}
