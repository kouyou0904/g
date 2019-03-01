using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMove : MonoBehaviour {
	[SerializeField]CharacterManeger _characterManeger = null;
	[SerializeField]PlayerScript _playerScrript = null;
	[SerializeField]BattleManeger _battleManger = null;

	bool Attackset = false;


	float _mini = 999999999;		//距離の最小値
	int _num = 0;			//最小値の配列番号
	bool _moveCheck;		//敵が動いたかどうか
	// Use this for initialization
	void Start () {
		_moveCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//敵フロイデの移動-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	public void EnemyFuroideCpuMove(int arrayNumber){
		float Length = 0;		//敵と味方の距離

		for(int i = 5; i < 10; i++){	//表示されているPlayerの配列番号
            if (_characterManeger.GetCharacterWalk(arrayNumber).gameObject.activeSelf)//死んでいないとき処理をする
            {
                Length = (_characterManeger.CharacterPos(arrayNumber) - _characterManeger.CharacterPos(i)).magnitude;
                if (_mini > Length)
                {
                  //  Debug.Log("いどう");
                    _mini = Length;
                    _num = i;
					//_battleManger.PlayerInputisEnemyAttack(_num);
					Attackset = true;
                }
            }
		}
		Vector2 targetVec = _characterManeger.CharacterPos (_num) - _characterManeger.CharacterPos (arrayNumber);	//プレイヤーから敵までの距離 
		Vector2 pointWhichIsOnTheCharacterCircle = _characterManeger.CharacterPos(arrayNumber) + targetVec.normalized * _characterManeger.CharacterPosRadius(arrayNumber);//移動範囲の円周上の点
		_characterManeger.CharacterPosMove(arrayNumber, pointWhichIsOnTheCharacterCircle);
		_moveCheck = true;
		}
	//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//敵ジン獅子の移動------------------------------------------------------------------------------------------------------------------------------------------------------
	public void EnemySwiftCpuMove(int arrayNumber){
		float Length = 0;		//敵と味方の距離

		for(int i = 0; i < 5; i++){		//表示されているPlayerの配列番号
            if (_characterManeger.GetCharacterWalk(arrayNumber).gameObject.activeSelf)//死んでいないとき処理をする
            {
          //      Debug.Log("新出ないよ"+i);
                Length = (_characterManeger.CharacterPos(arrayNumber) - _characterManeger.CharacterPos(i)).magnitude;
                if (_mini > Length)
                {
                    _mini = Length;
                    _num = i;
                    //	Debug.Log ("番号："+_num);
                    _battleManger.PlayerInputisEnemyAttack(_num);
                    Attackset = true;

                }
            }

		}
		Vector2 centerToMouseVec = _characterManeger.CharacterPos (_num) - _characterManeger.CharacterPos (arrayNumber);	 //プレイヤーから敵までの距離 
		Vector2 pointWhichIsOnTheCharacterCircle = _characterManeger.CharacterPos(arrayNumber) + centerToMouseVec.normalized * _characterManeger.CharacterPosRadius(arrayNumber);//移動範囲の円周上の点
		_characterManeger.CharacterPosMove(arrayNumber, pointWhichIsOnTheCharacterCircle);
		//Debug.Log (pointWhichIsOnTheCharacterCircle);
		_moveCheck = true;
	}
	//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	//敵フロイデの攻撃------------------------------------------------------------------------------------------------------------
	public void EnemyFuroideCpuAttack(int arrayNumber) {
        if (_characterManeger.GetCharacterWalk(arrayNumber).gameObject.activeSelf)//死んでいないとき処理をする
        {
         
            if (_playerScrript.AttackRadius(arrayNumber) >= _mini)
            {
               // Debug.Log("こうげき");
                _playerScrript.SetTargetCharaNum(_num);//攻撃ターゲットを設定
                _characterManeger.AttackRestriction(arrayNumber);
                //_characterManeger.EnemyPosition (_num);
                _battleManger.EnemyInput();
                _battleManger.PlayerInputisEnemyAttack(_num);

                _battleManger.EnemyRun(_num, arrayNumber);
                Attackset = false;
                GetMiniReset();
            }
		}
	}
	//------------------------------------------------------------------------------------------------------------------------------

	//敵ジン獅子の攻撃------------------------------------------------------------------------------------------------------------
	public void EnemySwiftCpuAttack(int arrayNumber){
        if (_characterManeger.GetCharacterWalk(arrayNumber).gameObject.activeSelf)//死んでいないとき処理をする
        {
            if (_playerScrript.AttackRadius(arrayNumber) >= _mini)
            {
                _playerScrript.SetTargetCharaNum(_num);
                _characterManeger.AttackRestriction(arrayNumber);
                //			if (Attackset == true) {
                //				Debug.Log ("Attackset:"+_num);

                _battleManger.EnemyInput();
                _battleManger.EnemyRun(_num, arrayNumber);
                Attackset = false;
                GetMiniReset();
                //			}
                //_characterManeger.EnemyPosition (_num);
            }
        }
	}
	//-----------------------------------------------------------------------------------------------------------------------------

	//_moveCheckの値をみる-----------------------------------------------------------------------------------------------------------
	public bool SetMove(){
		return _moveCheck;
	}
	//-----------------------------------------------------------------------------------------------------------------------------

	//_miniの値をリセット-------------------------------------------------------------------------------------------------------------
	public void GetMiniReset(){
		_mini = 999999999;
	}
    //-----------------------------------------------------------------------------------------------------------------------------

    //_moveCheckをリセット-----------------------------------------------------------------------------------------------------------
    public void GetMove() {
        _moveCheck = false;
    }

	public int numnum(){
		return _num;
	}
}
