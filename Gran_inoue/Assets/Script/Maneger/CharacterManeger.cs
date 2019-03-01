using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManeger : MonoBehaviour
{
    [SerializeField] CharacterSelector _characterSelector = null;
    [SerializeField] PlayerScript _playerScript = null;
    [SerializeField] CharacterWalk[] _characterWalk = new CharacterWalk[20];
    [SerializeField] CharacterAnim[] _characterAnim = new CharacterAnim[20];
    [SerializeField] GameObject[] _attackCircle = new GameObject[20];
	[SerializeField] GameObject[] _posUi = new GameObject[5];
    [SerializeField] UiManeger _uiManeger = null;
    [SerializeField] GameObject[] _team = new GameObject[2];
    [SerializeField] FieldCircle _fieldCircle = null;
    [SerializeField] CutIn _cutIn = null;

    bool _attackCheck;	//攻撃したかどうかを示す変数
    bool _determination;//位置決定ボタン押したかどうか
    bool _posThreeChoices;
	bool _allAction;

    int  _targetChecker;

    Vector2 Direction;

    Vector2 _fieldVec;

    int _determinationNum;//位置決定したキャラの配列番号
    int _charaNum;
    public int _attackNum;	//攻撃する側の配列番号

    float _blowAwayAcceleration;
    float _fieldRadius;

    // Use this for initialization
    void Start() {
        _attackCheck = false;
        _determination = false;
        _posThreeChoices = false;
        _targetChecker = -1;
        _fieldVec = _fieldCircle.FieldVec();
        //フィールドの円の半径の導出----------------------------------------------------------------------------------------
        Sprite fieldRangeCircleSprite = _fieldCircle.GetComponent<SpriteRenderer>().sprite;//移動範囲の円のsprite
        Vector3 fieldRangeCircleScale = _fieldCircle.gameObject.transform.localScale;
        _fieldRadius = (fieldRangeCircleSprite.rect.width / 2) * fieldRangeCircleScale.x / fieldRangeCircleSprite.pixelsPerUnit;
        //----------------------------------------------------------------------------------------------------------------

    }

    // Update is called once per frame
    void Update() {
        _characterSelector.TeamApper();
        _characterSelector.EnemyTeamApper();

		for (int i = 0; i < _posUi.Length; i++) {
			if (_posUi [i].activeInHierarchy) {
				_characterWalk [i].CharaTrigger (false);
				_characterWalk [5].CharaTrigger (false);
				_characterWalk [6].CharaTrigger (false);
				_characterWalk [7].CharaTrigger (false);
				_characterWalk [8].CharaTrigger (false);
				_characterWalk [9].CharaTrigger (false);
			}
		}

        if (_determination) {
            MoveRestriction(_determinationNum);
            _determination = false;
        }

        PosUiCharaRestraction();

		//
		for(int i = 0; i < 10; i++){
            if (_characterWalk[i].CharaSet()) {
                _characterWalk[i].TargetDisplay(true);
            } else {
                _characterWalk[i].TargetDisplay(false);
            }
		}
        CutinRingOut();

        AttackMoveRestraction();
		if ( _team[ 0 ].activeInHierarchy ) {
			ActionFuroideEnd( );
		}
		if ( _team[ 1 ].activeInHierarchy ) {
			ActionSwiftEnd( );
		}
        FuroideSkillButtonRestractionn();
    }

	//==========================================================================================================================================
	//public関数

	//======================================================
	//ゲッター
	public PlayerScript GetPlayerScript( ) {
		return _playerScript;
	}
	public CharacterWalk GetCharacterWalk( int arrayNum ) {
		return _characterWalk [ arrayNum ];
	}
	//======================================================
	//======================================================

    //キャラの移動先の決定----------------------------------------------
	public void SetPos(int arrayNumber) {
		for (int i = 0; i < _characterWalk.Length; i++) {
            if (i == arrayNumber) {
                _characterWalk[i].CenterPosSet();
            }
		}
    }
    //-------------------------------------------------------------------

	//全キャラの移動先の決定----------------------------------------------
	public void AllSetPos() {
		for (int i = 0; i < _characterWalk.Length; i++) {
			_characterWalk[i].CenterPosSet();
		}
	}
	//-------------------------------------------------------------------

    //キャラの移動先のリセット-------------------------------------------
	public void ResetPos(int arrayNumber) {
       for (int i = 0; i < _characterWalk.Length; i++) {
            if (i == arrayNumber) {
                _characterWalk[i].PlayerPosReset();
            }
       }
    }
    //-------------------------------------------------------------------

    //キャラ全員を移動制限-----------------------------------------------
    public void MoveTrigger(bool value) {
        for (int i = 0; i < _characterWalk.Length; i++) {
            _characterWalk[i].CharaTrigger(value);
        }
    }
    //-------------------------------------------------------------------

	//プレイヤーキャラ全員を移動制限-----------------------------------------------
	public void PlayerMoveTrigger(bool value) {
		for (int i = 0; i < 10; i++) {
			_characterWalk[i].CharaTrigger(value);
		}
	}
	//-------------------------------------------------------------------

	//エネミーキャラ全員を移動制限-----------------------------------------------
	public void EnemyMoveTrigger(bool value) {
		for (int i = 20; i < 11; i--) {
			_characterWalk[i].CharaTrigger(value);
		}
	}
	//-------------------------------------------------------------------

    //キャラ個々を移動制限-----------------------------------------------
    public void MoveRestriction(int arrayNumber) {
        for (int i = 0; i < _characterWalk.Length; i++) {
            if (i == arrayNumber) {
                _characterWalk[i].CharaTrigger(false);
            }
        }
    }
    //-------------------------------------------------------------------

	//キャラ個々を移動制限解除-----------------------------------------------
	public void StopMoveRestriction(int arrayNumber) {
		for (int i = 0; i < _characterWalk.Length; i++) {
			if (i == arrayNumber) {
				_characterWalk[i].CharaTrigger(true);
			}
		}
	}
	//-------------------------------------------------------------------


    //キャラ個々の攻撃モーション-----------------------------------------
    public void AttackRestriction(int arrayNumber) {
        for (int i = 0; i < _characterWalk.Length; i++) {
            if (i == arrayNumber) {
                _characterWalk[i].AttackMotion();//個々の攻撃モーション
				_attackNum = arrayNumber;//攻撃する側の配列番号を取得
                AttackCheck(true);
            }
        }
    }
    //-------------------------------------------------------------------

    //プレイヤーチーム１キャラ全員の行動後のモノモーション-----------------------
    public void FuroideMonoRestriction() {
        for (int i = 0; i < 5; i++) {
            _characterWalk[i].MonoMotion();
        }
    }
    //-------------------------------------------------------------------

    //プレイヤーチーム２キャラ全員の行動後のモノモーション-----------------------
    public void SwiftMonoRestriction() {
        _characterWalk[5].MonoMotion();
        _characterWalk[6].MonoMotion();
        _characterWalk[7].MonoMotion();
        _characterWalk[8].MonoMotion();
        _characterWalk[9].MonoMotion();
    }
    //--------------------------------------------------------------------

    //エネミーチーム１キャラ全員の行動後のモノモーション-------------------------
    public void FuroideEnemyMonoRestriction() {
        _characterWalk[10].MonoMotion();
        _characterWalk[11].MonoMotion();
        _characterWalk[12].MonoMotion();
        _characterWalk[13].MonoMotion();
        _characterWalk[14].MonoMotion();
    }
    //------------------------------------------------------------------


    //エネミーチーム2キャラ全員の行動後のモノモーション-------------------------
    public void SwiftEnemyMonoRestriction() {
		_characterWalk[15].MonoMotion();
		_characterWalk[16].MonoMotion();
		_characterWalk[17].MonoMotion();
		_characterWalk[18].MonoMotion();
		_characterWalk[19].MonoMotion();
    }
    //-------------------------------------------------------------------

    //キャラ個々の行動後モノモーション-----------------------------------
    public void MonoRestriction(int arrayNumber) {
        for (int i = 0; i < _characterWalk.Length; i++) {
            if (i == arrayNumber) {
                _characterWalk[i].MonoMotion();
            }
        }
    }
    //-------------------------------------------------------------------

    //キャラ個々の行動後モノモーション-----------------------------------
    public void StopMonoRestriction(int arrayNumber) {
        _characterWalk[arrayNumber].StopMonoMotion();
    }
    //-----------------------------------------------------------------

    //プレイヤーチーム1キャラ全員の行動後のモーションの解除---------------------
    public void FuroideStopMonoRestriction() {
        for (int i = 0; i < 5; i++) {
            _characterWalk[i].StopMonoMotion();
        }
    }
    //-------------------------------------------------------------------

    //プレイヤーチーム2キャラ全員の行動後のモーションの解除---------------------
    public void SwiftStopMonoRestriction() {
        _characterWalk[5].StopMonoMotion();
        _characterWalk[6].StopMonoMotion();
        _characterWalk[7].StopMonoMotion();
        _characterWalk[8].StopMonoMotion();
        _characterWalk[9].StopMonoMotion();
    }
    //-------------------------------------------------------------------

    //エネミーチーム1キャラ全員の行動後のモーションの解除---------------------
    public void FuroideEnemyStopMonoRestriction() {
        _characterWalk[10].StopMonoMotion();
        _characterWalk[11].StopMonoMotion();
        _characterWalk[12].StopMonoMotion();
        _characterWalk[13].StopMonoMotion();
        _characterWalk[14].StopMonoMotion();
    }
    //-------------------------------------------------------------------


    //エネミーチーム2キャラ全員の行動後のモーションの解除-----------------------
    public void SwiftEnemyStopMonoRestriction() {
		_characterWalk[15].StopMonoMotion();
		_characterWalk[16].StopMonoMotion();
		_characterWalk[17].StopMonoMotion();
		_characterWalk[18].StopMonoMotion();
		_characterWalk[19].StopMonoMotion();
    }
    //-------------------------------------------------------------------

    //キャラ個々のダウンモーション---------------------------------------
    public void DownMotion(int arrayNumber) {
        for (int i = 0; i < _characterWalk.Length; i++) {
            if (i == arrayNumber) {
                _characterWalk[i].DownMotion();
            }
        }
    }
    //-------------------------------------------------------------------

    //キャラ個々のヒットモーション---------------------------------------
    public void HitMotion() {
        for (int i = 0; i < _characterWalk.Length; i++) {
			if (i == _playerScript.GetTargetCharaNum()) {
//				Debug.Log ("ひっと"+_playerScript.GetTargetCharaNum());
                _characterWalk[i].HitMotion();
            }
        }
    }
    //-------------------------------------------------------------------

    //キャラ攻撃サークルの表示か非表示---------------------------------------
    public void CircleFalse(bool value) {
        for (int i = 0; i < _attackCircle.Length; i++) {
            _attackCircle[i].SetActive(value);
        }
    }
	//-------------------------------------------------------------------

	//キャラ個々攻撃サークルの表示か非表示---------------------------------------
	public void CircleIndividualFalse(int arrayNumber) {
		for (int i = 0; i < _attackCircle.Length; i++) {
			if(i == arrayNumber){
                _attackCircle[i].SetActive(false);
			}
		}
	}
	//-------------------------------------------------------------------

	//攻撃時のターゲットの吹っ飛び方向を返す関数
	public Vector2 BlowAwayDirection() {
        Vector2 direction;
		direction = (_characterWalk [_playerScript.GetTargetCharaNum()]._characterPos - _characterWalk [_attackNum]._characterPos).normalized;
		return direction;
    }

	//キャラクターの速度を変えるように_characterWalkに指示する関数
	public void ChangeVelocity(Vector2 vec) {
		_characterWalk [_playerScript.GetTargetCharaNum()].ChangeVelocity (vec);
    }

	//受け手側の座標を返す関数
	public Vector2 EnemyPosition() {
        Vector2 EnemyPos;
		EnemyPos = _characterWalk [_playerScript.GetTargetCharaNum()]._characterPos;
        return EnemyPos;
    }

	//キャラクターの加速度をvec分増加させる関数ように_characterWalkに指示する関数
	public void BlowAwayAcceleration(Vector2 vec) {
		_characterWalk [_playerScript.GetTargetCharaNum()].BlowAwayAcceleration (vec);
    }

	//_attackCheckの値を変更する変数
    public void AttackCheck(bool value) {
        _attackCheck = value;
    }

    public bool AttackChecking() {
        return _attackCheck;
    }

	public Vector2 CharacterPos(int arrayNumber){
		return _characterWalk [arrayNumber]._characterPos;
	}

	public float CharacterPosRadius(int arrayNumber){
		return _characterWalk [arrayNumber].PosRadius ();
	}

	public void CharacterPosMove(int arrayNumber, Vector2 vec){
		_characterWalk [arrayNumber].CharacterPos (vec);
	}

    //PositionUiの位置決定した時に行う処理--------------------------------
    public void PositionDetermination(int arrayNumber) {
        _determinationNum = arrayNumber;
        SetPos(arrayNumber);
        MonoRestriction(arrayNumber);
        CircleIndividualFalse(arrayNumber);
        _uiManeger.PosUiResponse(false);
		_uiManeger.ButtonResponse (true);
        TargetEnemyAllDisplay(false);
        _determination = true;
		_characterWalk [arrayNumber].SetActionEnd (true);
		_characterWalk[ arrayNumber ].IsTriggerCheck( false );

        _posThreeChoices = true;
    }
    //----------------------------------------------------------------

    //PositionUiのリセットした時に行う処理--------------------------------
    public void PositionReset(int arrayNumber) {
        ResetPos(arrayNumber);
        CircleFalse(false);
        StopMoveRestriction(arrayNumber);
        _posThreeChoices = true;
		_uiManeger.ButtonResponse (true);
        TargetEnemyAllDisplay(false);
		_characterWalk[ arrayNumber ].IsTriggerCheck( false );
    }
    //----------------------------------------------------------------

    //三択の時に他のキャラを触れなくする------------------------------
    public void PosUiCharaRestraction() {
        for (int i = 0; i < _posUi.Length; i++) {
            for(int a = 0; a < 10; a++) {
                if (_posUi[i].activeInHierarchy) {
                    _characterWalk[a].CharaTrigger(false);
                } else {
                    if (!_posUi[i].activeInHierarchy && _posThreeChoices) {
                        _characterWalk[a].CharaTrigger(true);
                    }
                }
            }
        }

        _posThreeChoices = false;
    }
    //---------------------------------------------------------------

    //_posThreeChoicesの値変えたい関数----------------------------
    public void GetPosThree(bool value) {
        _posThreeChoices = value;
    }
    //-----------------------------------------------------------

	public bool SetPosThree(){
		return _posThreeChoices;
	}
	//monoモーションをした時に動けないようにした-----------------------------
	public void MonoPosFuroideRestrction(){
		if (_team[0].activeInHierarchy) {
			for (int i = 0; i < 5; i++) {
				if (_characterAnim[i].Mono()) {
					_characterWalk[i].CharaTrigger(false);
                    _playerScript.SetAttackCheck(false);
				}
			}
		}
	}

	public void MonoPosSwiftRestrction(){
		if (_team[1].activeInHierarchy) {
			for (int i = 5; i < 10; i++) {
				if (_characterAnim[i].Mono()) {
					_characterWalk[i].CharaTrigger(false);
                    _playerScript.SetAttackCheck(false);
				}
			}
		}
	}

	public void MonoPosPenguinSill(){
		if (_team [0].activeInHierarchy) {
			for(int i = 1; i < 5; i++){
				if (_characterAnim [i].PenguinReinforcedFormMono ()) {
					_characterWalk[i].CharaTrigger(false);
					_playerScript.SetAttackCheck(false);
				}
			}
		}
	}
	//-----------------------------------------------------------------

	//フィールドの外にキャラが出たら配列番号を介す---------------------------------------------
	public int FieldCharaDisapper(int arrayNumber) {
		if (_fieldRadius * 1.01f < (_characterWalk[arrayNumber]._characterPos - _fieldVec).magnitude) {
			return arrayNumber;
		}
		return -1;
		
	}
	//----------------------------------------------------------------------------------------
	
	public void TargetIndividualDisplay(bool value, int arrayNumber) {
		if( arrayNumber >= 0 ){
			_characterWalk[arrayNumber].TargetDisplay(value);
		}
		if ( value ){
			 _targetChecker = arrayNumber; 
		}
	}

	public int TargetDisplaySet(){
		return _targetChecker;
	}

    //Playerが攻撃する時の処理をまとめた--------------------------------
    public void PlayerBattle(int arrayNumber) {
        SetPos(arrayNumber);
        AttackRestriction(arrayNumber);
        CircleFalse(false);
        _uiManeger.ButtonResponse(true);
        TargetEnemyAllDisplay(false);
		_characterWalk [arrayNumber].SetActionEnd (true);
		_characterWalk[ arrayNumber ].IsTriggerCheck( false );

    }
    //-----------------------------------------------------------------

	//プレイヤー側のペンギンのスキル---------------------------------------------------------
	public void PlayerPenguinSkill(){ 
		for(int i = 1; i < 5; i++){ 
			_characterWalk[i].SkillMotion();
			_characterWalk[i].PenguinCircle();
		}
	}
	//--------------------------------------------------------------------------------------------

	//エネミー側のペンギンのスキル---------------------------------------------------------
	public void EnemyPenguinSkill(){ 
		for(int i = 11; i < 15; i++){ 
			_characterWalk[i].SkillMotion();
			_characterWalk[i].PenguinCircle();
		}
	}
	//--------------------------------------------------------------------------------------------

	//プレイヤー側の陣獅子のスキル-------------------------------------------------------------
	public void PlayerSwiftSkill(){ 
		_characterWalk[5].SkillMotion();
	}
	//-----------------------------------------------------------------------------------------

	//エネミー側の陣獅子のスキル-------------------------------------------------------------
	public void EnemySwiftSkill(){ 
		_characterWalk[15].SkillMotion();
	}
	//-----------------------------------------------------------------------------------------

	//プレイヤー側の陣獅子のスキルの終わり-------------------------------------------------------------
	public void PlayerSwiftStopSkill(){ 
		_characterWalk[5].StopSkillMotion();
	}
    //-----------------------------------------------------------------------------------------

    //プレイヤー側の陣獅子のカラーモーション--------------------------------------------------
    public void PlayerSwiftColor() {
        _characterWalk[5].ColorMotion();
    }
    //----------------------------------------------------------------------------------------

    //エネミー側の陣獅子のカラーモーション--------------------------------------------------
    public void EnemySwiftColor() {
        _characterWalk[15].ColorMotion();
    }
    //----------------------------------------------------------------------------------------

    //エネミー側の陣獅子のスキルの終わり-------------------------------------------------------------
    public void EnemySwiftStopSkill(){ 
		_characterWalk[15].StopSkillMotion();
	}
	//-----------------------------------------------------------------------------------------

	//各キャラクターのDragUpの値を介す関数----------------------------------------------------------
	public bool GetCharaDragUp(int arrayNumber){
		return _characterWalk [arrayNumber].GetDragUp ();
	}
	//-------------------------------------------------------------------------------------------

	//各キャラクターのDragUpの値を変える関数----------------------------------------------------------
	public void SetCharaDragUp(int arrayNumber, bool value){
		_characterWalk [arrayNumber].SetDragUp (value);
	}
	//-------------------------------------------------------------------------------------------

	//全部のActionEndを変える関数-------------------------------------------------------------------------
	public void AllActionEnd(){
		for (int i = 0; i < 10; i++) {
			_characterWalk [i].SetActionEnd (false);
		}
	}

    //----------------------------------------------------------------------------------------------------

    //プレイヤー側の陣獅子がスキル使用時移動制限する関数-------------------------
    public void PlayerSwiftSkillRestraction() {
        if (_characterAnim[5].Skill() ||
            _characterAnim[5].Roop() ||
            _characterAnim[5].Mono() || 
            _characterAnim[5].Attack() ) {

            _characterWalk[5].CharaTrigger(false);
            _uiManeger.SkillButtonRestraction(false);
        } else {
            if (_team[1].activeInHierarchy) {
                _characterWalk[5].CharaTrigger(true);
                _uiManeger.SkillButtonRestraction(true);
            }
        }
    }
    //-----------------------------------------------------------------------------------
    
    //行動後のトリガー用意-------------------------------------------------------------------------------------
    public void ActionFuroideEnd(){
		if ((_characterWalk [0].GetActionEnd() ||
			!_characterWalk [0].gameObject.activeInHierarchy)&&
			(_characterWalk [1].GetActionEnd() ||
			!_characterWalk [1].gameObject.activeInHierarchy)&&
			(_characterWalk [2].GetActionEnd() ||
			!_characterWalk [2].gameObject.activeInHierarchy)&&
			(_characterWalk [3].GetActionEnd() ||
			!_characterWalk [3].gameObject.activeInHierarchy)&&
			(_characterWalk [4].GetActionEnd()||
			!_characterWalk [4].gameObject.activeInHierarchy)) {
			_allAction = true;
		}
	}

	public void ActionSwiftEnd(){
		if ( (_characterWalk[ 5 ].GetActionEnd( ) ||
			!_characterWalk[ 5 ].gameObject.activeInHierarchy) &&
		     (_characterWalk[ 6 ].GetActionEnd( ) ||
			!_characterWalk[ 6 ].gameObject.activeInHierarchy) &&
		     (_characterWalk[ 7 ].GetActionEnd( ) ||
			!_characterWalk[ 7 ].gameObject.activeInHierarchy) &&
		     (_characterWalk[ 8 ].GetActionEnd( ) ||
			!_characterWalk[ 8 ].gameObject.activeInHierarchy) &&
		     (_characterWalk[ 9 ].GetActionEnd( ) ||
			!_characterWalk[ 9 ].gameObject.activeInHierarchy )) {
			_allAction = true;
		}
	}
	//------------------------------------------------------------------------------------------------------------

	public bool GetAllAction(){
		return _allAction;
	}

	public void SetAllAction(bool value){
		_allAction = value;
	}

	public void SetAllActionEnd(bool value){
		for (int i = 0; i < 10; i++) {
			_characterWalk [i].SetActionEnd (value);
		}
	}

    public void ActionSetting() {
        for (int i = 0; i < 10; i++) {
            if (!_characterWalk[i].GetActionEnd()) {
                StopMoveRestriction(i);
            }
        }
    }

	//全プレイヤー側のキャラの_targetSquareを表示か非表示か--------------------------------------------------
	void TargetAllDisplay( bool value ){ 
		for(int i = 0; i < 10; i++){
			_characterWalk[i].TargetDisplay(value);
		}
	}
    //---------------------------------------------------------------------------------------

    //全エネミー側のキャラの_targetSquareを表示か非表示か--------------------------------------------------
    void TargetEnemyAllDisplay(bool value) {
        for (int i = 10; i < 20; i++) {
            _characterWalk[i].TargetDisplay(value);
        }
    }
    //---------------------------------------------------------------------------------------
    //リングアウトしたときのカットイン処理-----------------------------
    void CutinRingOut() {
        for (int i = 0; i < _characterWalk.Length; i++) {
            if (_characterWalk[i].SetRingOut()) {
               _cutIn.CutInMotion();
               _characterWalk[i].GetRingOut(false);
            }
        }
    }
    //-----------------------------------------------------------------

    //攻撃する時にキャラクターが動かないようにする関数-----------------------------
    void AttackMoveRestraction() {
        if (_playerScript.GetAttackCheck()) {
            MoveRestriction(_attackNum);
        }
    }
    //-----------------------------------------------------------------------------

    //プレイヤー側がフロイデ選択したときスキルボタンを使えなくする-----------------------
    void FuroideSkillButtonRestractionn() {
        if (_team[0].activeInHierarchy) {
            _uiManeger.SkillButtonRestraction(false);
        }
    }
    //-----------------------------------------------------------------------------------

    //===========================================================================================================================================
    //===========================================================================================================================================

}