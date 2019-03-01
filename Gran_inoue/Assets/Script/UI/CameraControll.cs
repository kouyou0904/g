using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
//カメラの動きを管理するクラス
//
//使用方法：カメラにアタッチ
public class CameraControll : MonoBehaviour {
    public const float DEFAULT_ORTHOGRAPHIC_SIZE = 30.5f; //カメラの初期サイズ
    public const float DEFAULT_ORTHOGRAPHIC_SIZE2 = 20.5f;
	public const float DEFAULT_ORTHOGRAPHIC_SIZE3 = 10.5f;
    Camera _camera;

    //カメラの移動系
    Vector3 _cameraposi;
    bool CameraMoveUp;
    bool CameraMoveDown;
    bool CameraMoveLeft;
    bool CameraMoveRight;
    float SpeedUp = 0;

    public float Zoom1Leftjudg;
    public float Zoom1Rightjudg;
    public float Zoom1Upjudg;
    public float Zoom1Downjudg;
    
    public float Zoom2Leftjudg;
    public float Zoom2Rightjudg;
    public float Zoom2Upjudg;
    public float Zoom2Downjudg;

    public float Speed;
    public float SpeedUpTime;
    public float UpSpeed;

    //

    // Use this for initialization
    void Start () {
	//    _camera = GetComponent<Camera>();
    //    Vector3 _cameraposi = this.transform.localPosition;
    }


    void Update()
    {
     //   this.transform.localPosition = _cameraposi;

        float JoyY = CrossPlatformInputManager.GetAxis("Vertical");
        float JoyX = CrossPlatformInputManager.GetAxis("Horizontal");

        _cameraposi.x += JoyX * Speed * Time.deltaTime;
        _cameraposi.y += JoyY * Speed * Time.deltaTime;
       

        //_cameraposi.z = -10;

       
        

        //if (CameraMoveUp == true)
        //{
        //    _cameraposi.y += Speed * Time.deltaTime;
        //    SpeedUp +=  Time.deltaTime;
        //    if (SpeedUp >= SpeedUpTime)
        //    {
        //        _cameraposi.y += UpSpeed * Time.deltaTime;
        //    }
        //}
        //else if (CameraMoveDown == true)
        //{
        //    _cameraposi.y -= Speed * Time.deltaTime;
        //    SpeedUp += Time.deltaTime;
        //    if (SpeedUp >= SpeedUpTime)
        //    {
        //        _cameraposi.y -= UpSpeed * Time.deltaTime;
        //    }
        //}
        //else if (CameraMoveLeft == true)
        //{
        //    _cameraposi.x -= Speed * Time.deltaTime;
        //    SpeedUp += Time.deltaTime;
        //    if (SpeedUp >= SpeedUpTime)
        //    {
        //        _cameraposi.x -= UpSpeed * Time.deltaTime;
        //    }
        //}
        //else if (CameraMoveRight == true)
        //{
        //    _cameraposi.x += Speed * Time.deltaTime;
        //    SpeedUp += Time.deltaTime;
        //    if (SpeedUp >= SpeedUpTime)
        //    {
        //        _cameraposi.x += UpSpeed * Time.deltaTime;
        //    }
        //}
        //else
        //{
        //  SpeedUp = 0;
        //}


        if (CameraControllButton.ZoomNO == 0)
        {
            //CameraMoveDown = false;
            //CameraMoveLeft = false;
            //CameraMoveRight = false;
            //CameraMoveUp = false;

        }

        if (CameraControllButton.ZoomNO == 1)
        {
            if (this.transform.localPosition.x < Zoom1Leftjudg )
            {
                CameraMoveLeft = false;
                _cameraposi.x = Zoom1Leftjudg;
            }
            if (this.transform.localPosition.x > Zoom1Rightjudg)
            {
                CameraMoveRight = false;
                _cameraposi.x = Zoom1Rightjudg;
            }
            if (this.transform.localPosition.y > Zoom1Upjudg)
            {
                CameraMoveRight = false;
                _cameraposi.y = Zoom1Upjudg;
            }
            if (this.transform.localPosition.y < Zoom1Downjudg)
            {
                CameraMoveRight = false;
                _cameraposi.y = Zoom1Downjudg;
            }
        }

        if( CameraControllButton.ZoomNO == 2)
        {
            if (this.transform.localPosition.x < Zoom2Leftjudg)
            {
                CameraMoveLeft = false;
                _cameraposi.x = Zoom2Leftjudg;
            }
            if (this.transform.localPosition.x > Zoom2Rightjudg)
            {
                CameraMoveRight = false;
                _cameraposi.x = Zoom2Rightjudg;
            }
            if (this.transform.localPosition.y > Zoom2Upjudg)
            {
                CameraMoveRight = false;
                _cameraposi.y = Zoom2Upjudg;
            }
            if (this.transform.localPosition.y < Zoom2Downjudg)
            {
                CameraMoveRight = false;
                _cameraposi.y = Zoom2Downjudg;
            }

        }
        
    }


	//カメラをズームインする関数
	// Update is called once per frame
	public void Zoom(float zoomvalue ) {
        _camera.orthographicSize -= zoomvalue;
    }

    //カメラを除々にズームインする関数
    public void Zoom(float zoomvalue, float time) {
        StartCoroutine (ZoomGradually(zoomvalue,time) );
    }

    //カメラを除々にズームインする関数(Coroutine)
    IEnumerator ZoomGradually( float zoomvaluePertime, float time ) {
        while (time > 0) {
            Zoom (zoomvaluePertime * Time.deltaTime);
            time -= Time.deltaTime;
               yield return new WaitForSeconds (Time.deltaTime);
        }

    }
    //カメラの正投影サイズを変更する関数
    public void ChangeOrthographicSize(float orthographicSize) {
        _camera.orthographicSize = orthographicSize;
    }

    //カメラの移動のオンオフ
    public void CameraMoveUpOn()
    {

        CameraMoveUp = true;

    }
    public void CameraMoveUpOff()
    {

        CameraMoveUp = false;

    }

    public void CameraMoveDownOn()
    {

       CameraMoveDown = true;

    }
    public void CameraMoveDownOff()
    {

        CameraMoveDown = false;

    }

    public void CameraMoveLeftOn()
    {

        CameraMoveLeft = true;

    }
    public void CameraMoveLeftOff()
    {

        CameraMoveLeft = false;

    }

    public void CameraMoveRightOn()
    {

        CameraMoveRight = true;

    }
    public void CameraMoveRightOff()
    {

        CameraMoveRight = false;

    }

}
