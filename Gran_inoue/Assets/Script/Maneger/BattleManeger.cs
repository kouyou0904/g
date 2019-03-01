using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManeger : MonoBehaviour {

    [SerializeField]
	FroideStatus[] _fstatus = null;
    [SerializeField]
	SwiftStatus[] _sstatus = null;
	[SerializeField]
	PenguinStatus[] _pstatus = null;
	[SerializeField]
	SwftShikigamiStandStatus[] _ssstatus = null;



    [SerializeField]
    Status _status;
	[SerializeField] CharacterManeger _characterManeger = null;

	public GameObject PTeam1;
	public GameObject PTeam2;
	public GameObject ETeam1;
	public GameObject ETeam2;

	//ステータス関連の変数====================================
    int PlayerHP = 0;
    int PlayerAttack = 0;
    int PlayerMagicAttack = 0;
    int PlayerDefence = 0;
    int PlayerMagicDefence = 0;
    int PlayerImpact = 0;
    int PlayerWeight = 0;

	int EnemyHP = 0;
	int EnemyAttack = 0;
	int EnemyMagicAttack = 0;
	int EnemyDefence = 0;
	int EnemyMagicDefence = 0;
	int EnemyImpact = 0;
	int EnemyWeight = 0;

	int[] EEnemyHP = new int[5];
	int[] EEnemyAttack = new int[5];
	int[] EEnemyMagicAttack = new int[5];
	int[] EEnemyDefence = new int[5];
	int[] EEnemyMagicDefence = new int[5];
	int[] EEnemyImpact = new int[5];
	int[] EEnemyWeight = new int[5];
	//=======================================================


	//バトル計算時に使用する変数============================
	//=====================================================
	public int ImpactRate = 1;
	int ThisAttack = 0;
    static bool Playerset = false;
    static bool Enemyset = false;
    static bool Allset = false;

    bool[] ringoutnow = new bool [20];

	float _length;//吹っ飛ばしの距離

	int _blowAwayCount = 0;
	public int _countTime = 0;
	Vector2 _blowAwayPos;											//ふっ飛ばし変位
	float _blowAwayTime;											//ふっ飛ばし時の移動時間

	bool flameTrigger = false;										//AttackChecking()がtrueになったかどうかを返す変数

    // Use this for initialization
    void Start () {		
		RingNowReset();
		for (int i = 0; i < 5; i++) {
			EEnemyHP [i] = 0;
			EEnemyAttack [i] = 0;
			EEnemyMagicAttack [i] = 0;
			EEnemyDefence [i] = 0;
			EEnemyMagicDefence [i] = 0;
			EEnemyImpact [i] = 0;
			EEnemyWeight [i] = 0;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_characterManeger.AttackChecking()) {
			flameTrigger = true;
		}

		if (flameTrigger) {
			_blowAwayCount++;
			
		} else {
			_blowAwayCount = 0;
		}

		if (_blowAwayCount == 1) {
            _characterManeger.HitMotion();
			_characterManeger.AttackCheck(false);
		}

			
		if (_blowAwayCount > _countTime) {
			flameTrigger = false;
			//Vector2 vec = new Vector2 (0, 0);
			//_characterManeger.ChangeVelocity (vec);
		}
				

		if (flameTrigger && _blowAwayCount <= _countTime) {
			//BlowAwayAcceleration ();
		}


		
	}


	//エネミーのＨＰをThisAttack減らしステータスを更新する
    void PlayerOutput()
    {
       // Debug.Log("ThisAttack："+ThisAttack);
        if (ThisAttack >= 0)
        {
            if (PTeam1.activeSelf == true) {

                if (Status.Name == "迅獅子") {
                    Status.HP = _sstatus[1].SwiftHP(ThisAttack);
                } else if (Status.Name == "式神1") {
                    Status.HP = _ssstatus[4].SwiftShikigamiHP(ThisAttack);
                } else if (Status.Name == "式神2") {
                    Status.HP = _ssstatus[5].SwiftShikigamiHP(ThisAttack);
                } else if (Status.Name == "式神3") {
                    Status.HP = _ssstatus[6].SwiftShikigamiHP(ThisAttack);
                } else if (Status.Name == "式神4") {
                    Status.HP = _ssstatus[7].SwiftShikigamiHP(ThisAttack);
                }
            }

            if (PTeam2.activeSelf == true) {
                if (Status.Name == "フロイデ") {
                    Status.HP = _fstatus[1].FroideHP(ThisAttack);
                } else if (Status.Name == "ペンギンちゃん1" ||
                           Status.Name == "ペンギンさん1") {
                    Status.HP = _pstatus[4].PenguinHP(ThisAttack);
                } else if (Status.Name == "ペンギンちゃん2" ||
                           Status.Name == "ペンギンさん2") {
                    Status.HP = _pstatus[5].PenguinHP(ThisAttack);
                } else if (Status.Name == "ペンギンちゃん3" ||
                           Status.Name == "ペンギンさん3") {
                    Status.HP = _pstatus[6].PenguinHP(ThisAttack);
                } else if (Status.Name == "ペンギンちゃん4" ||
                           Status.Name == "ペンギンさん4") {
                    Status.HP = _pstatus[7].PenguinHP(ThisAttack);
                }
            }

        }
        //攻撃されたキャラのHPを取得し、HPが0でなければ吹っ飛ばす。
        if (Status.HP > 0)
        {
            PlayerLength();
            BlowAwayCalculation(_length);
        }
        Reset();
    }

	//プレイヤーのＨＰをThisAttack減らしステータスを更新する
	void EnemyOutput(int _EcharaNam, int ThisAttack,int EnemyImpactSet)
    {
		if (ThisAttack >= 0) {
			if (ETeam1.activeSelf == true) {
//				Debug.Log (ThisAttack);
				if (_EcharaNam == 5) {
					Status.HP = _sstatus [0].SwiftHP (ThisAttack);
				} else if (_EcharaNam == 6) {
					Status.HP = _ssstatus [0] .SwiftShikigamiHP (ThisAttack);
				} else if (_EcharaNam == 7) {
					Status.HP = _ssstatus [1] .SwiftShikigamiHP (ThisAttack);
				} else if (_EcharaNam == 8) {
					Status.HP = _ssstatus [2] .SwiftShikigamiHP (ThisAttack);
				} else if (_EcharaNam == 9) {
					Status.HP = _ssstatus [3] .SwiftShikigamiHP (ThisAttack);
				}
			}

//            Debug.Log("キャラ番号所得"+_EcharaNam);

			if (ETeam2.activeSelf == true) {
				
				if (_EcharaNam == 0) {
				 _fstatus [0].FroideHP (ThisAttack);
             //       Debug.Log("攻撃"+_fstatus[0].FroideHP(ThisAttack));
				} else if (_EcharaNam == 1) {
				_pstatus [0].PenguinHP (ThisAttack);
             //       Debug.Log("攻撃" + _pstatus[0].PenguinHP(ThisAttack));
                }
                else if (_EcharaNam == 2) {
				_pstatus [1].PenguinHP (ThisAttack);
             //       Debug.Log("攻撃" + _pstatus[1].PenguinHP(ThisAttack));
                }
                else if (_EcharaNam == 3) {
				_pstatus [2].PenguinHP (ThisAttack);
              //      Debug.Log("攻撃" + _pstatus[2].PenguinHP(ThisAttack));
                }
                else if (_EcharaNam == 4) {
				_pstatus [3].PenguinHP (ThisAttack);
              //      Debug.Log("攻撃" + _pstatus[3].PenguinHP(ThisAttack));
                }
            }
		}
        if (ThisAttack > 0 && Status.HP > 0)
        {
            EnemyLength(EnemyImpactSet);
            BlowAwayCalculation(_length);
        }
        Reset();
    }

    public void RingOutRun(int CharaNum,int Dmage)
    {	
		switch( CharaNum ) {
			case 0:
				if(!ringoutnow[CharaNum]) {
					_fstatus[0].FroideHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
		        break;

			case 1:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[0].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			
				case 2:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[1].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 3:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[2].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 4:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[3].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 5:
				if (!ringoutnow[CharaNum])
				{
					_sstatus[0].SwiftHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 6:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[0].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 7:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[1].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 8:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[2].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 9:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[3].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 10:
				if (!ringoutnow[CharaNum])
				{
					_fstatus[1].FroideHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 11:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[4].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 12:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[5].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 13:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[6].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 14:
				if (!ringoutnow[CharaNum])
				{
					_pstatus[7].PenguinHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 15:
				if (!ringoutnow[CharaNum])
				{
					_sstatus[1].SwiftHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 16:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[4].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 17:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[5].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 18:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[6].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
			case 19:
				if (!ringoutnow[CharaNum])
				{
					_ssstatus[7].SwiftShikigamiHP(Dmage);
					ringoutnow[CharaNum] = true;
					return;
				}
				break;
		}


	}

    //ふっ飛ばし距離lengthから吹っ飛ばしの変位・初速度算出する関数
	void BlowAwayCalculation(float length)
	{
		CharacterWalk targetCM = _characterManeger.GetCharacterWalk ( _characterManeger.GetPlayerScript().GetTargetCharaNum() );	//攻撃される側のCharacterWalk
		float acceleration = targetCM.GetAcceleration();	//攻撃される側の加速度
		float blowAwayTime = Mathf.Sqrt( ( 2 * length ) / acceleration );	//ふっ飛ばし時の移動時間 ※等加速度運動の式よりv = 0のときx-x_0 = lengthという条件より算出　t = (2s/a)^1/2
		Vector2 firstVelocity = acceleration * blowAwayTime * _characterManeger.BlowAwayDirection();	//吹っ飛び時の初速度 v = a * t * (吹っ飛び方向ベクトル)
		targetCM.ChangeVelocity( firstVelocity );
		//_characterManeger.ChangeVelocity(firstVelocity);
		//吹っ飛びベクトル描画処理-----------------------------------------------------------------------------------------------------
		Vector2 blowAwayPos = length  * _characterManeger.BlowAwayDirection();	//ふっ飛ばし変位
		Debug.DrawLine( _characterManeger.GetCharacterWalk( _characterManeger._attackNum )._characterPos , blowAwayPos, Color.red);
		//----------------------------------------------------------------------------------------------------------------------------
	}

	//プレイヤー側の吹っ飛ばす距離を代入する
    void PlayerLength()
    {
        _length = ( PlayerImpact - EnemyWeight ) * ImpactRate;
        Debug.Log(_length);
    }

	//エネミー側の吹っ飛ばす距離を代入する
    void EnemyLength( int EnemyImpact )
    {
        _length = ( EnemyImpact - PlayerWeight ) * ImpactRate;
     //   Debug.Log("PlayerWeight" + PlayerWeight);
      //  Debug.Log(_length);
    }


	//====================================================================
	//public関数

	//関数の機能コメント
	public void PlayerInput()
	{
		PlayerHP = Status.HP;
		PlayerAttack = Status.Attack;
		PlayerMagicAttack = Status.MagicAttack;
		PlayerDefence = Status.Defance;
		PlayerMagicDefence = Status.MagicDefance;
		PlayerImpact = Status.Impact;
		PlayerWeight = Status.Weight;

//		   Debug.Log(Status.Name);
		//   Debug.Log(PlayerHP);
		//  Debug.Log(PlayerAttack);
		//  Debug.Log(PlayerMagicAttack);
		//  Debug.Log(PlayerDefence);
		//  Debug.Log(PlayerMagicDefence);

		Playerset = true;
	}


	//関数の機能コメント
	public void PlayerInputisEnemyAttack(int _charanum)
	{
		switch(_charanum){
            
		case 0:
			PlayerHP = _fstatus [0].FroideHP (0);
			PlayerAttack = _fstatus [0].FroideAttack ();
			PlayerMagicAttack = _fstatus [0].FroideMAttck ();
			PlayerDefence = _fstatus [0].FroideDefance ();
			PlayerMagicDefence = _fstatus [0].FroideMDefance ();
			PlayerImpact = _fstatus [0].FroideImpact ();
			PlayerWeight = _fstatus [0].FroideWeight ();
			break;

		case 1:
			PlayerHP = _pstatus [0].PenguinHP (0);
			PlayerAttack = _pstatus [0].PenguinAttack (0);
			PlayerMagicAttack = _pstatus [0].PenguinMAttck (0);
			PlayerDefence = _pstatus [0].PenguinDefance (0);
			PlayerMagicDefence = _pstatus [0].PenguinMDefance (0);
			PlayerImpact = _pstatus [0].PenguinImpact (0);
			PlayerWeight = _pstatus [0].PenguinWeight (0);
			break;

		case 2:
			PlayerHP = _pstatus [1].PenguinHP (0);
			PlayerAttack = _pstatus [1].PenguinAttack (0);
			PlayerMagicAttack = _pstatus [1].PenguinMAttck (0);
			PlayerDefence = _pstatus [1].PenguinDefance (0);
			PlayerMagicDefence = _pstatus [1].PenguinMDefance (0);
			PlayerImpact = _pstatus [1].PenguinImpact (0);
			PlayerWeight = _pstatus [1].PenguinWeight (0);
			break;

		case 3:
			PlayerHP = _pstatus [2].PenguinHP (0);
			PlayerAttack = _pstatus [2].PenguinAttack (0);
			PlayerMagicAttack = _pstatus [2].PenguinMAttck (0);
			PlayerDefence = _pstatus [2].PenguinDefance (0);
			PlayerMagicDefence = _pstatus [2].PenguinMDefance (0);
			PlayerImpact = _pstatus [2].PenguinImpact (0);
			PlayerWeight = _pstatus [2].PenguinWeight (0);
			break;

		case 4:
			PlayerHP = _pstatus [3].PenguinHP (0);
			PlayerAttack = _pstatus [3].PenguinAttack (0);
			PlayerMagicAttack = _pstatus [3].PenguinMAttck (0);
			PlayerDefence = _pstatus [3].PenguinDefance (0);
			PlayerMagicDefence = _pstatus [3].PenguinMDefance (0);
			PlayerImpact = _pstatus [3].PenguinImpact (0);
			PlayerWeight = _pstatus [3].PenguinWeight (0);
			break;

		case 5:
			PlayerHP = _sstatus [0].SwiftHP (0);
			PlayerAttack = _sstatus [0].SwiftAttack (0);
			PlayerMagicAttack = _sstatus [0].SwiftMAttck (0);
			PlayerDefence = _sstatus [0].SwiftDefance (0);
			PlayerMagicDefence = _sstatus [0].SwiftMDefance (0);
			PlayerImpact = _sstatus [0].SwiftImpact(0);
			PlayerWeight =_sstatus [0].SwiftWeight(0);
           //     Debug.Log("すてーたすはいったよ");
                break;

		case 6:
			PlayerHP = _ssstatus [0].SwiftShikigamiHP(0);
			PlayerAttack = _ssstatus [0].SwiftShikigamiAttack ();
			PlayerMagicAttack = _ssstatus [0].SwiftShikigamiMAttck ();
			PlayerDefence = _ssstatus [0].SwiftShikigamiDefance ();
			PlayerMagicDefence =_ssstatus [0].SwiftShikigamiMDefance();
			PlayerImpact = _ssstatus [0].SwiftShikigamiImpact();
			PlayerWeight =_ssstatus [0].SwiftShikigamiWeight();
			break;

		case 7:
			PlayerHP = _ssstatus [1].SwiftShikigamiHP (0);
			PlayerAttack = _ssstatus [1].SwiftShikigamiAttack ();
			PlayerMagicAttack = _ssstatus [1].SwiftShikigamiMAttck ();
			PlayerDefence = _ssstatus [1].SwiftShikigamiDefance ();
			PlayerMagicDefence = _ssstatus [1].SwiftShikigamiMDefance ();
			PlayerImpact = _ssstatus [1].SwiftShikigamiImpact();
			PlayerWeight =_ssstatus [1].SwiftShikigamiWeight();
			break;

		case 8:
			PlayerHP = _ssstatus [2].SwiftShikigamiHP (0);
			PlayerAttack = _ssstatus [2].SwiftShikigamiAttack ();
			PlayerMagicAttack = _ssstatus [2].SwiftShikigamiMAttck ();
			PlayerDefence = _ssstatus [2].SwiftShikigamiDefance ();
			PlayerMagicDefence = _ssstatus [2].SwiftShikigamiMDefance ();
			PlayerImpact = _ssstatus [2].SwiftShikigamiImpact();
			PlayerWeight =_ssstatus [2].SwiftShikigamiWeight();
			break;

		case 9:
			PlayerHP = _ssstatus [3].SwiftShikigamiHP (0);
			PlayerAttack = _ssstatus [3].SwiftShikigamiAttack ();
			PlayerMagicAttack = _ssstatus [3].SwiftShikigamiMAttck ();
			PlayerDefence = _ssstatus [3].SwiftShikigamiDefance ();
			PlayerMagicDefence = _ssstatus [3].SwiftShikigamiMDefance ();
			PlayerImpact = _ssstatus [3].SwiftShikigamiImpact();
			PlayerWeight =_ssstatus [3].SwiftShikigamiWeight();
			break;

		}
     //   Debug.Log("すてーたはこれだよ"+PlayerWeight);

    }


    //関数の機能コメント
    public void EnemyInput()
	{
       
		EnemyHP = Status.HP;
		EnemyAttack = Status.Attack;
		EnemyMagicAttack = Status.MagicAttack;
		EnemyDefence = Status.Defance;
		EnemyMagicDefence = Status.MagicDefance;
		EnemyImpact = Status.Impact;
		EnemyWeight = Status.Weight;

		//   Debug.Log(Status.Name);
		//   Debug.Log(EnemyHP);
		//   Debug.Log(EnemyAttack);
		//   Debug.Log(EnemyMagicAttack);
		//   Debug.Log(EnemyDefence);
		//   Debug.Log(EnemyMagicDefence);

		Enemyset = true;
	}

	public void EEnemyInput(){

		if (ETeam1.activeInHierarchy) {
			EEnemyHP [0] = _fstatus [1].FroideHP (0);
			EEnemyAttack [0] = _fstatus [1].FroideAttack ();
			EEnemyMagicAttack [0] = _fstatus [1].FroideMAttck ();
			EEnemyDefence [0] = _fstatus [1].FroideDefance ();
			EEnemyMagicDefence [0] = _fstatus [1].FroideDefance ();
			EEnemyImpact [0] = _fstatus [1].FroideImpact ();
			EEnemyWeight [0] = _fstatus [1].FroideWeight ();

			for (int i = 0; i < 4; i++) {
				EEnemyHP [i + 1] = _pstatus [i + 4].PenguinHP (0);
				EEnemyAttack [i + 1] = _pstatus [i + 4].PenguinAttack (0);
				EEnemyMagicAttack [i + 1] = _pstatus [i + 4].PenguinMAttck (0);
				EEnemyDefence [i + 1] = _pstatus [i + 4].PenguinDefance (0);
				EEnemyMagicDefence [i + 1] = _pstatus [i + 4].PenguinDefance (0);
				EEnemyImpact [i + 1] = _pstatus [i + 4].PenguinImpact (0);
				EEnemyWeight [i + 1] = _pstatus [i + 4].PenguinWeight (0);
			}
		}

		if (ETeam2.activeInHierarchy) {
			EEnemyHP [0] = _sstatus [1].SwiftHP (0);
			EEnemyAttack [0] = _sstatus [1].SwiftAttack (0);
			EEnemyMagicAttack [0] = _sstatus [1].SwiftMAttck (0);
			EEnemyDefence [0] = _sstatus [1].SwiftDefance (0);
			EEnemyMagicDefence [0] = _sstatus [1].SwiftDefance (0);
			EEnemyImpact [0] = _sstatus [1].SwiftImpact (0);
			EEnemyWeight [0] = _sstatus [1].SwiftWeight (0);

			for (int i = 0; i < 4; i++) {
				EEnemyHP [i + 1] = _ssstatus [i + 4].SwiftShikigamiHP (0);
				EEnemyAttack [i + 1] = _ssstatus [i + 4].SwiftShikigamiAttack ();
				EEnemyMagicAttack [i + 1] = _ssstatus [i + 4].SwiftShikigamiMAttck ();
				EEnemyDefence [i + 1] = _ssstatus [i + 4].SwiftShikigamiDefance ();
				EEnemyMagicDefence [i + 1] = _ssstatus [i + 4].SwiftShikigamiDefance ();
				EEnemyImpact [i + 1] = _ssstatus [i + 4].SwiftShikigamiImpact ();
				EEnemyWeight [i + 1] = _ssstatus [i + 4].SwiftShikigamiWeight ();
			}
		}

	}


	//関数の機能コメント
	public void PlayerRun()
	{
		//Debug.Log ("プレイヤーアタック："+PlayerAttack);
		//Debug.Log ("プレイヤーマジック"+PlayerMagicAttack);



		if (PlayerMagicAttack == 0) {
			ThisAttack = PlayerAttack - EnemyDefence;
		} else if (PlayerAttack == 0) {
			ThisAttack = PlayerMagicAttack - EnemyMagicDefence;
		}
        ThisAttack = ThisAttack * 10;
		PlayerOutput ();

	}


	//関数の機能コメント
	public void EnemyRun(int _PcharaNam,int _EcharaNam)
	{
        int EnemyImpactSet = 0;
		if (ETeam1.activeInHierarchy)
        {
		//	Debug.Log ("的番号" + _EcharaNam);
          //  Debug.Log ("敵攻撃力"+EEnemyMagicAttack[_EcharaNam-10]);
            if (EEnemyMagicAttack[_EcharaNam - 10] == 0)
            {
                ThisAttack = EEnemyAttack[_EcharaNam - 10] - PlayerDefence;
                EnemyImpactSet = EEnemyImpact[_EcharaNam - 10];
             }
            else if (EEnemyAttack[_EcharaNam - 10] == 0)
            {
                ThisAttack = EEnemyMagicAttack[_EcharaNam - 10] - PlayerMagicDefence;
                EnemyImpactSet = EEnemyImpact[_EcharaNam - 10];
            }
        }

		else if (ETeam2.activeInHierarchy)
        {
            //Debug.Log ("敵攻撃力"+EEnemyMagicAttack[_EcharaNam-15]);
            if (EEnemyMagicAttack[_EcharaNam - 15] == 0)
            {
                ThisAttack = EEnemyAttack[_EcharaNam - 15] - PlayerDefence;
                EnemyImpactSet = EEnemyImpact[_EcharaNam - 15];

            }
            else if (EEnemyAttack[_EcharaNam - 15] == 0)
            {
                ThisAttack = EEnemyMagicAttack[_EcharaNam - 15] - PlayerMagicDefence;
                EnemyImpactSet = EEnemyImpact[_EcharaNam - 15];

            }
        }

     //   Debug.Log("ぷれいやーばりや" + PlayerDefence+PlayerMagicDefence);

        ThisAttack = ThisAttack * 10;

        EnemyOutput (_PcharaNam,ThisAttack,EnemyImpactSet);

	}


	//関数の機能コメント
	public void Reset()
	{
		Playerset = false;
		Enemyset = false;
		Allset = false;
		_length = 0;
		ThisAttack = 0;
	}


	public void RingNowReset(){
		for (int i = 0; i < 20; i++)
		{
			ringoutnow[i] = false;
		}
	}


	//====================================================================
	//====================================================================

}
