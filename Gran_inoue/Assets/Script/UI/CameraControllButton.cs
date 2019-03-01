using UnityEngine;

public class CameraControllButton : MonoBehaviour
{
    [SerializeField]CameraControll _cameraControll = null;
    [SerializeField]Camera _camera = null;
    [SerializeField]GameObject _zoomIn = null;
    [SerializeField]GameObject _zoomOut = null;

    float InSpeed = 0.5f;
    float OutInSpeed = -0.5f;
    int InCount; //何フレーム処理したかを見るもの
    int OutCount;
    int Number_of_time = 20; //何回ズーム処理を行うか

    bool InCheck;        //ズームインボタンが押されたかどうか
    bool InCheck2;       //二段階目でズームインボタンが押されたかどうか
    bool OutCheck;       //ズームアウトボタンが押されたかどうか
    bool OutCheck2;      //二段階目でズームアウトボタンが押されたかどうか

    public static int ZoomNO = 0; //現在のズームが何段階目かを残すところ

    // Use this for initialization
    void Start(){
        InCheck = false;
        InCheck2 = false;
        OutCheck = false;
        OutCheck2 = false;
    }

    // Update is called once per frame
    void Update() {

        //もし各_countがNumber_of_timeを超えたら変数の初期化とボタンを反応するようにしてる--------------
        if (InCount > Number_of_time){
            InitializationIn();
            ZoomInNoResponse(true);
            ZoomOutNoResponse(true);
        }

        if (OutCount > Number_of_time){
            InitializationOut();
            ZoomInNoResponse(true);
            ZoomOutNoResponse(true);
        }
        //--------------------------------------------------------------------------------------------------


        //カメラサイズごとのズームイン、アウトの処理----------------------------------------------------------
		if (_camera.orthographicSize <= CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE && InCheck && !InCheck2) {
			InCount++;
			CameraZoomIn( CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE2 );
			ZoomInNoResponse(false);
			ZoomOutNoResponse(false);
		}

		if (_camera.orthographicSize >= CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE3 && 
            _camera.orthographicSize <= CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE2 &&
            InCheck &&
            InCheck2) {
			InCount++;
			CameraZoomIn(CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE3);
			ZoomInNoResponse(false);
			ZoomOutNoResponse(false);
		}

		if (_camera.orthographicSize <= CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE2 &&
            OutCheck &&
            !OutCheck2) {
			OutCount++;
			CameraZoomOut(CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE2);
			ZoomInNoResponse(false);
			ZoomOutNoResponse(false);
		}

		if (_camera.orthographicSize <= CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE && 
            _camera.orthographicSize >= CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE2 
            && OutCheck  
            && OutCheck2) {
			OutCount++;
			CameraZoomOut(CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE);
			ZoomInNoResponse(false);
			ZoomOutNoResponse(false);
        }


        //カメラのサイズごとに押せるボタンの制限----------------------------------------------
        if (_camera.orthographicSize == CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE) {
            ZoomOutNoResponse(false);
        }

        if (_camera.orthographicSize == CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE3) {
            ZoomInNoResponse(false);
        }

        //--------------------------------------------------------------------------------------


    }
    //カメラのズームイン処理---------------------------------------------------------------
	void CameraZoomIn( float Size ) {
        if (InCount < Number_of_time) {
            _cameraControll.Zoom(InSpeed);
        }else{
			_cameraControll.ChangeOrthographicSize(Size);
        }
    }
    //-------------------------------------------------------------------------------------

    //カメラのズームアウト処理--------------------------------------------------------------

	void CameraZoomOut( float Size ) {
        if (OutCount < Number_of_time){
            _cameraControll.Zoom(OutInSpeed);
        }else{
			_cameraControll.ChangeOrthographicSize(Size);
        }
    }
    //---------------------------------------------------------------------------------------

    //カメラのボタンが押されたらトリガーをとおす-----------------------------------------
    public void InCameraButton(){

        ZoomNO++;

        InCheck = true;
        if (_camera.orthographicSize == CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE2) {
            InCheck2 = true;
        }
    }

    public void OutCameraButton(){

        ZoomNO--;

        OutCheck = true;
        if (_camera.orthographicSize == CameraControll.DEFAULT_ORTHOGRAPHIC_SIZE2) {
            OutCheck2 = true;
        }
    }
    //---------------------------------------------------------------------------------

    //各ボタンに使っている変数を初期化している-----------------------------------------
    void InitializationIn(){
        InCheck = false;
        InCheck2 = false;
        InCount = 0;
    }

    void InitializationOut(){
        OutCheck = false;
        OutCheck2 = false;
        OutCount = 0;
    }
    //---------------------------------------------------------------------------------

    //ズームボタンを反応しないようにしてる--------------------------------------------
    public void ZoomInNoResponse(bool x){
        _zoomIn.GetComponent<UnityEngine.UI.Button>().interactable = x;
    }

    public void ZoomOutNoResponse(bool x){
        _zoomOut.GetComponent<UnityEngine.UI.Button>().interactable = x;
    }
    //---------------------------------------------------------------------------------

}