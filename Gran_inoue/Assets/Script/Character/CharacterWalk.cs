using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//==キャラクターの移動関連を管理するクラス
public class CharacterWalk : MonoBehaviour
{
    [SerializeField]GameObject[] _circle = new GameObject[2];	//攻撃範囲と移動範囲の円
    [SerializeField]GameObject _postionUi = null;				//「決定しますか？」のUI
	[SerializeField]CharacterCircle _characterCircle = null;
    [SerializeField]CharacterAttackCircle _characterAttackCircle = null;
	[SerializeField]FieldCircle _fieldCircle = null;
	[SerializeField]GameObject _targetSquare = null;            //行動ができるかどうかの四角のやつ
	[SerializeField]GameObject _summonEffect = null;			//召喚エフェクト

    float _radius;												//移動範囲の円の半径
	float _fieldRadius;
	bool[] _ringOut = new bool[20];
	bool DragUp = false;
    public bool _characerSetting;                                      //キャラの移動制限
    bool _posUi;                                                //PositionUiの表示の制限
    bool _cutInRingOut;                                         //リングアウトしたかどうか
	bool _target;                                               //タッチ時のUIを表示しないかどうかのフラグ
	bool _feedOutCheck;		
	bool _actionEnd;


    public int ARRAYNUMBER = 0;
    Animator _animator;

	float Smallspeed = -0.005f;

	Vector3 _mousePoint;										//マウスのWorld座標
	Vector3 _scale;
	Vector3 _fieldVec;
    Vector4 _color;                                            //オブジェクトの色
	public Vector2 _characterPos;

	[SerializeField] float _dynamicFrictionCoeffiction = 0;			//各キャラクターの動摩擦係数
	float _acceleration;											//加速度の大きさ

	//Vector3 _playerVec;
	//Vector3 objectPointInScreen;
	//bool Positionoksetting = false;

    // Use this for initialization
    void Start() {

        _animator = GetComponentInChildren<Animator>();


		for (int i = 0; i < _ringOut.Length; i++) {
			_ringOut[i] = false;
		}
		_scale = this.transform.localScale;

		_characterPos = this.transform.position;

		_target = false;

		_fieldVec = _fieldCircle.FieldVec ();

		_characerSetting = false;

        _cutInRingOut = false;

		_feedOutCheck = false;

		_actionEnd = false;

        _color = this.GetComponent<SpriteRenderer>().color;
		//移動範囲の円の半径の導出----------------------------------------------------------------------------------------
		Sprite moveRangeCircleSprite = _characterCircle.GetComponent<SpriteRenderer> ().sprite;//移動範囲の円のsprite
		Vector3 moveRangeCircleScale = _characterCircle.gameObject.transform.localScale;
		_radius = (moveRangeCircleSprite.rect.width / 2) * moveRangeCircleScale.x / moveRangeCircleSprite.pixelsPerUnit;
        //----------------------------------------------------------------------------------------------------------------

		//フィールドの円の半径の導出----------------------------------------------------------------------------------------
		Sprite fieldRangeCircleSprite = _fieldCircle.GetComponent<SpriteRenderer> ().sprite;//移動範囲の円のsprite
		Vector3 fieldRangeCircleScale = _fieldCircle.gameObject.transform.localScale;
		_fieldRadius = (fieldRangeCircleSprite.rect.width / 2) * fieldRangeCircleScale.x / fieldRangeCircleSprite.pixelsPerUnit;
		//----------------------------------------------------------------------------------------------------------------

		_acceleration = _dynamicFrictionCoeffiction * Physics.gravity.magnitude;	//ふっ飛ばし時の運動方程式を計算し加速度導出( ma = μ'mg )※動摩擦力を考慮

    }

    // Update is called once per frame
    void Update() {
		_characterPos = this.transform.position;

        //各プレイヤー側エネミー側のリスポーン処理-----------------------------------
		if ( gameObject.transform.localScale.x <= 0 && 
			_fieldRadius < (this.transform.position - _fieldVec).magnitude) {
            if (this.gameObject.tag == "Player" ||
                this.gameObject.tag == "SubPlayer") {
                this.transform.position = new Vector2(0, -4);
                this.transform.localScale = new Vector2(1, 1);
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
				_summonEffect.SetActive(true);
				_feedOutCheck = true;
            }
		}

        if (gameObject.transform.localScale.x <= 0 && 
			_fieldRadius < (this.transform.position - _fieldVec).magnitude) {
            if (this.gameObject.tag == "Enemy" ||
                this.gameObject.tag == "SubEnemy") {
                this.transform.position = new Vector2(0, 4);
                this.transform.localScale = new Vector2(1, 1);
                this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
				_summonEffect.SetActive(true);
				_feedOutCheck = true;

			}
		}
        //-----------------------------------------------------------------------
        FieldDisapper ();

		if (_feedOutCheck) {
			Invoke("ColorReset", 1.5f);
			Invoke("SummonDisapper", 1.5f);
			_feedOutCheck = false;
		}

		//摩擦力による減速処理------------------------------------------------------------------------------
		Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
		if ( rb.velocity.magnitude > 0 ) {//速度を持っていたら減速処理
			if (rb.velocity.magnitude <= _acceleration * Time.deltaTime) {//速さが加速度の大きさより小さい時
				rb.velocity = Vector2.zero;
			} else {
				rb.velocity += -_acceleration * rb.velocity.normalized * Time.deltaTime;
			}
		}
		//--------------------------------------------------------------------------------------------------
	}

    //キャラクターをドラッグしている間に呼ばれる関数------------------------------------------------------------------------------------
    void OnMouseDrag() {
        if (_characerSetting)  {
			//_mousePointの更新--------------------------------------------------
			_mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_mousePoint.z = transform.position.z;
			//-------------------------------------------------------------------
			_targetSquare.SetActive(false);
			_target = true;
			IsTriggerCheck (true);

			//キャラクターの座標の更新---------------------------------------------------------------------------------------------------
			Vector3 centerToMouseVec = _mousePoint - _characterCircle.CenterVec();//移動範囲の円の中心からマウスの座標へのベクトル
			Vector3 fieldCenterToMouseVec = _mousePoint - _fieldVec;//フィールドの円の中心からマウスの座標へのベクトル

			Vector3 fieldCenterToCenterVec = _characterCircle.CenterVec() - _fieldVec;//フィールドの円の中心から移動範囲の円へのベクトル
			float a = 1f;
			float bPrime = Vector3.Dot (fieldCenterToCenterVec, centerToMouseVec) / centerToMouseVec.magnitude;
			float c = fieldCenterToCenterVec.sqrMagnitude - _fieldRadius * _fieldRadius;
			float t = -bPrime + Mathf.Sqrt( bPrime * bPrime - a * c );//centerToMouseVec.normalized * t がフィールドの円上になるようなtを算出

			if (centerToMouseVec.magnitude <= _radius && fieldCenterToMouseVec.magnitude <= _fieldRadius) {//マウスの座標が移動範囲内にある時 かつ マウスの座標がフィールド円内にある時
				this.transform.position = _mousePoint;//マウスの座標に移動
			} else if ( centerToMouseVec.magnitude <= _radius && fieldCenterToMouseVec.magnitude > _fieldRadius ) {//マウスの座標が移動範囲内にある時 かつ マウスの座標がフィールド円外にある時
				this.transform.position = _characterCircle.CenterVec () + centerToMouseVec.normalized * t;//フィールドの円とcenterToMouseVecを方向ベクトルとする直線との交点に移動
				//this.transform.position = _fieldVec + fieldCenterToMouseVec.normalized * _fieldRadius;//フィールドの円周上に移動
			} else {
				Vector3 pointWhichIsOnTheCharacterCircle = _characterCircle.CenterVec () + centerToMouseVec.normalized * _radius;//移動範囲の円周上の点
				if ( ( pointWhichIsOnTheCharacterCircle - _fieldVec ).magnitude >= _fieldRadius ) {//移動範囲の円がフィールド円からはみ出している時
					this.transform.position = _characterCircle.CenterVec () + centerToMouseVec.normalized * t;//フィールドの円とcenterToMouseVecを方向ベクトルとする直線との交点に移動
					//this.transform.position = _fieldVec + fieldCenterToMouseVec.normalized * _fieldRadius;//フィールドの円周上に移動
				} else {
					this.transform.position = pointWhichIsOnTheCharacterCircle;//移動範囲の円周上に移動
				}
			}
			//--------------------------------------------------------------------------------------------------------------------------
			//-----------------------------------------------------------------------------------------------
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------------

    //キャラクターを触った瞬間に呼ばれる関数-----------------------------------------------------------------------------------------------
    void OnMouseDown(){
		DragUp = true;
        if (_characerSetting){
            WalkMotion();
            _circle[0].SetActive(true);
            _circle[1].SetActive(true);
            _posUi = true;
        } else {
            _posUi = false;
        }

    }
    //----------------------------------------------------------------------------------------------------------------------------------------

    //キャラクターを離した瞬間に呼ばれる関数---------------------------------------------------------------------------------------------------
    void OnMouseUp(){
        StopWalkMotion();
		_target = false;
        if (!_characterAttackCircle.CircleCheck()){
            _circle[0].SetActive(false);
        }
        _characerSetting = false;
        _circle[1].SetActive( false );
        if (_posUi){
            _postionUi.SetActive(true);
        }

	}
    //--------------------------------------------------------------------------------------------------------------------------------------------

//	public void Positionok() {                                 
//		Positionoksetting = true;
//	}

    
 
	//徐々に小さくなって消える---------------------------------------------------
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Circle") {
			TargetDisplay (false);
		}
	}



	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Circle" &&
			(this.gameObject.tag == "Enemy" || 
			this.gameObject.tag == "SubEnemy")) {
			TargetDisplay (true);
		}
	}
    //------------------------------------------------------------------------------

    


	//=================================================================================================
	//public関数

	//=====================================
	//ゲッター
	public float GetAcceleration() {
		return _acceleration;
	}
	//=====================================
	//=====================================

	//キャラの座標を決定させる----------------------------------------------------
	public void CenterPosSet(){
		_characterCircle.CeterPosSetting (this.transform.position);
		_characterPos = this.transform.position;
	}
	//----------------------------------------------------------------------------

	//キャラの座標をリセットさせる------------------------------------------------
	public void PlayerPosReset(){
		this.transform.position = _characterCircle.CenterVec();
	}
	//----------------------------------------------------------------------------

	public void CharaTrigger(bool value){
		_characerSetting = value;
	}

	//各モーションに入るためのトリガー----------------------------------------------
	public void WalkMotion() {
		_animator.SetTrigger("WalkFlag");
	}

	public void StopWalkMotion() {
		_animator.SetTrigger("StopWalkFlag");
	}

	public void MonoMotion(){
		_animator.SetTrigger("MonoFlag");
	}

	public void StopMonoMotion() {
		_animator.SetTrigger("StopMonoFlag");
	}

	public void AttackMotion() {
		_animator.SetTrigger("AttackFlag");
	}

	public void DownMotion() {
		_animator.SetTrigger("DownFlag");
	}

	public void HitMotion() {
		_animator.SetTrigger("HitFlag");
	}

	public void SkillMotion(){ 
		_animator.SetTrigger("SkillFlag");
	}

	public void StopSkillMotion(){ 
		_animator.SetTrigger("StopSkillFlag");
	}

    public void ColorMotion() {
        _animator.SetTrigger("ColorFlag");
    }

	//------------------------------------------------------------------------------------

	//キャラクターの速度を変える関数------------------------------------------------------------
	public void ChangeVelocity( Vector2 vec ){
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = vec;
	}
	//------------------------------------------------------------------------------------------

	//キャラクターの加速度をaccelerationVec分増加させる関数--------------------------------------
	public void BlowAwayAcceleration( Vector2 accelerationVec ){
		this.gameObject.GetComponent<Rigidbody2D> ().velocity += accelerationVec;
	}
	//------------------------------------------------------------------------------------------

    //フィールド外へ出たらの処理------------------------------------------------------------------
	public void FieldDisapper(){
        if (_fieldRadius < (this.transform.position - _fieldVec).magnitude && !_characerSetting && !_cutInRingOut) {
            this.gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0);
            if (this.gameObject.transform.localScale.x >= 0.8) {
                _cutInRingOut = true;
            }
        }
	}
    //-------------------------------------------------------------------------------------------

	public float PosRadius(){
		return _radius;
	}

	public void CharacterPos(Vector2 vec){
		this.transform.position = vec;
	}

	public float FieldRadius() {
		return _fieldRadius;
	}
	
	public Vector2 FieldVec() {
		return _fieldVec;
	}

	//アタックサークルのスケールの変化-------------------------------------------------------------------
	public void PenguinCircle(){ 
		_circle[0].transform.localScale = new Vector3(0.16f, 0.16f, 1);
	}

	//---------------------------------------------------------------------------------------------------
	
	//_targetSquare表示か非表示----------------------------------------------------------------------
	public void TargetDisplay( bool value ){ 
		_targetSquare.SetActive(value);
	}
	//----------------------------------------------------------------------------------------------
	
	//DragUpの値を介す関数--------------------------------------------------------------------------
	public bool DragTarget(){ 
		return _target;
	}
    //---------------------------------------------------------------------------------------------

    //_characerSettingの値を介す関数--------------------------------------------------------------------------
    public bool CharaSet(){
		return _characerSetting;
	}
    //-----------------------------------------------------------------------------------------------------

    //_cutInRingOutの値を介す関数--------------------------------------------------------------------------
    public bool SetRingOut() {
        return _cutInRingOut;
    }
    //--------------------------------------------------------------------------------------------------

    //_cutInRingOutの値を変更する関数--------------------------------------------------------------------------
    public void GetRingOut(bool value) {
        _cutInRingOut = value;
    }
	//------------------------------------------------------------------------------------------------------

	public bool GetDragUp(){
		return DragUp;
	}

	public void SetDragUp(bool value){
		DragUp = value;
	}

	public bool GetActionEnd(){
		return _actionEnd;
	}

	public void SetActionEnd(bool value){
		_actionEnd = value;
	}

	//カラーをリセット--------------------------------------------------------------------------------
	void ColorReset() {
		this.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
	}
	//--------------------------------------------------------------------------------------------------

	//召喚エフェクトを非表示-------------------------------------------------------------------------
	void SummonDisapper() {
		_summonEffect.SetActive(false);
	}
	//--------------------------------------------------------------------------------------------------

	//isTriggerをtrueかfalse-------------------------------------------------------------------------
	public void IsTriggerCheck(bool value) {
		this.gameObject.GetComponent<CapsuleCollider2D> ().isTrigger = value;
	}
	//--------------------------------------------------------------------------------------------------

    //======================================================================================================
    //======================================================================================================


}