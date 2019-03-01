using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManeger : MonoBehaviour {
    [SerializeField]CutInManeger _cutInManeger = null;
	[SerializeField]CharacterManeger _characterManeger = null;
    [SerializeField]CutIn[] _cutIn = new CutIn[9];
	[SerializeField]MainBGM _mainBgm = null;
	[SerializeField]SoundLibraly _soundLibraly = null;
	[SerializeField]UiManeger _uiManeger = null;
	[SerializeField]EndButton _endButton = null;
    [SerializeField]GameObject[] _team = new GameObject[4];
    [SerializeField]TeamCount[] _teamCount = new TeamCount[2];
    [SerializeField]EnemyTeamCount[] _enemyTeamCount = new EnemyTeamCount[2];
    [SerializeField]WinningOrLosingSceneTrasition _winningOrLosingSceneTrasition = null;
	[SerializeField]EnemyMove _enemyMove = null;
    [SerializeField]CharacterAnim[] _characterAnim = new CharacterAnim[10];
	[SerializeField]BattleManeger _battlemaneger = null;
    [SerializeField]SkillManeger _skillmaneger = null;
    [SerializeField]PopUpButton _popupbutton= null;

	[SerializeField]float _enemyAttackInterval = 0;//各エネミーの攻撃後の待機時間[単位：秒]
    bool _soundCheck;
    bool _youStanbyCheck;
	bool _youMainChecker;
	bool _youEndChecker;
	bool _enemyStanbyCheck;
	bool _enemyMainCheck;
	bool _enemyEndCheck;
    bool _attackMotion;
	bool _endAutomatic;
	bool _endCutInCheck;

    bool _manual;


    public int _targetCharaNum;

    int _moveNum;

	public int _phaseNum = 0;
    enum PartStatus {
        YOUR_STANDBY_PHASE,
        YOUR_MAIN_PHASE,
        YOUR_END_PHASE,

        ENEMY_STANDBY_PHASE,
        ENEMY_MAIN_PHASE,
        ENEMY_END_PHASE
    }

	PartStatus _status;

	// Use this for initialization
    void Start () {

		_soundCheck = true;
        _youStanbyCheck = true;
		_youMainChecker = true;
		_youEndChecker = true;
		_enemyStanbyCheck = true;
		_enemyMainCheck = true;
		_enemyEndCheck = true;
        _attackMotion = false;
		_endAutomatic = false;
		_endCutInCheck = true;

        _manual = false;
        _moveNum = 0;



	}
	
	// Update is called once per frame
    void Update () {

		if (_enemyTeamCount[0].PlayerVictory()) {
			_uiManeger.ButtonResponse(false);
			_cutIn[4].CutInMotion();
		}

		if (_enemyTeamCount[1].PlayerVictory()) {
			_uiManeger.ButtonResponse(false);
			_cutIn[4].CutInMotion();
		}

		if (_cutIn[4].CutInWait()) {
			_winningOrLosingSceneTrasition.Victory();
		}


		if (_teamCount[0].PlayerLose()) {
            _uiManeger.ButtonResponse(false);
            _cutIn[5].CutInMotion();
		}

		if (_teamCount[1].PlayerLose()) {
            _uiManeger.ButtonResponse(false);
            _cutIn[5].CutInMotion();
		}

		if (_cutIn[5].CutInWait()) {
			_winningOrLosingSceneTrasition.Lose();
		}

		if(_team[0].activeInHierarchy &&
			_endCutInCheck){
			if (_characterManeger.GetAllAction()) {
				_endButton.EndCheck (true);
				_endCutInCheck = false;
			}
		}

		if(_team[1].activeInHierarchy && 
			_endCutInCheck){
			if (_characterManeger.GetAllAction()) {
				_endButton.EndCheck (true);
				_endCutInCheck = false;
			}
		}

        switch ( _status ) {
            case PartStatus.YOUR_STANDBY_PHASE:
                YourStanby();
                break;
			case PartStatus.YOUR_MAIN_PHASE:
                YourMain();
                break;
            case PartStatus.YOUR_END_PHASE:
                YourEnd();
                break;
            case PartStatus.ENEMY_STANDBY_PHASE:
                EnemyStanby();
                break;
            case PartStatus.ENEMY_MAIN_PHASE:
                EnemyMain();
                break;
            case PartStatus.ENEMY_END_PHASE:
                EnemyEnd();
                break;
        }
	}

    void YourStanby() {
		if (_cutIn[8].CutInWait() || _cutIn[3].CutInWait()) {
			if (_youStanbyCheck) {
				if (_soundCheck) {
					_mainBgm.YouBGM ();
					_soundCheck = false;
                    _cutIn[3].CutInWaiting();
					_phaseNum = 0;
				}

				_cutIn [0].CutInMotion ();
				_youStanbyCheck = false;

			}
        }
		_battlemaneger.RingNowReset();
        _skillmaneger.PSwiftSkillofPowerUP();

		if (!_youStanbyCheck) {
			_youStanbyCheck = true;
			_status = PartStatus.YOUR_MAIN_PHASE;
			return;
		}
    }

    void YourMain() {
        if (_cutIn[0].CutInWait()){
			if (_youMainChecker) {
				_characterManeger.PlayerMoveTrigger (true);
				_uiManeger.ButtonResponse (true);
				_soundCheck = true;
				_youMainChecker = false;
				_cutIn [3].CutInWaiting ();
                _phaseNum = 1;
                if (!_manual)
                {
                    PopUpButton();
                    _manual = true;
                    Debug.Log("とおったよー");
                }
            }
        _characterManeger.PlayerSwiftSkillRestraction();	
        _characterManeger.MonoPosFuroideRestrction ();
		_characterManeger.MonoPosSwiftRestrction ();
		_characterManeger.MonoPosPenguinSill ();
        }


		if (_endButton.EndChecker ()) {
			_youMainChecker = true;
			_cutIn [1].CutInMotion ();
			_status = PartStatus.YOUR_END_PHASE;
			return;
		}

        //_uiManeger.PosUiDisplayResponse();

    }

    void YourEnd() {
		if (_endButton.EndChecker ()) {
			if(_youEndChecker){
                _uiManeger.PosUiResponse(false);
                _cutIn[0].CutInWaiting();
				_youMainChecker = true;
				_uiManeger.EnemyTurnButtonResponse (false,1);
				_uiManeger.EnemyTurnButtonResponse (false,2);
				_uiManeger.EnemyTurnButtonResponse (false,3);

                Invoke("EndPhaseMotion", 1f);

				_characterManeger.PlayerMoveTrigger (false);
				_soundLibraly.StopSoundWithFadeOut ();
				_youEndChecker = false;
				_phaseNum = 2;

            	}
			}

		if (_cutIn [1].CutInWait ()) {
			_endButton.EndCheck (false);
			_youEndChecker = true;
			_status = PartStatus.ENEMY_STANDBY_PHASE;
			return;
		}
    }

    void EnemyStanby() {
        if (_cutIn[1].CutInWait()) {
			if (_enemyStanbyCheck) {
				if (_soundCheck) {
					_mainBgm.EnemyBGM ();
					_soundCheck = false;
					_endCutInCheck = true;
					_phaseNum = 3;
					_characterManeger.SetAllActionEnd (false);
					_characterManeger.SetAllAction (false);
				}

				if (_team [2].activeInHierarchy) {
					_characterManeger.FuroideEnemyStopMonoRestriction ();
					if (_team [1].activeInHierarchy) {
						_characterManeger.SwiftStopMonoRestriction ();
					}
				}

				if (_team [3].activeInHierarchy) {
					_characterManeger.SwiftEnemyStopMonoRestriction ();
					if (_team [0].activeInHierarchy) {
						_characterManeger.FuroideStopMonoRestriction ();
					}
				}

				if (_team[0].activeInHierarchy) {
					for (int i = 1; i < 5; i++) {
						if (_characterAnim[i].PenguinReinforcedFormMono()) {
							_characterManeger.StopMonoRestriction(i);
						}
					}
				}

				_cutIn [2].CutInMotion ();

				_enemyStanbyCheck = false;
			}
        }

		_battlemaneger.RingNowReset();
		_battlemaneger.EEnemyInput ();

		if (_cutIn [2].CutInWait ()) {
			_cutIn [1].CutInWaiting ();
			_enemyStanbyCheck = true;
			_status = PartStatus.ENEMY_MAIN_PHASE;
			return;
		}
    }

    void EnemyMain() {
		if (_cutIn [2].CutInWait ()) {
			//1Fだけ呼ばれてるもの-------------------------------------------------------------------------
			if (_enemyMainCheck) {
				_soundCheck = true;
				_enemyMainCheck = false;
				StartCoroutine (EnemyMoveAction ());//エネミーの行動処理
				_phaseNum = 4;
//				if (_team [2].activeInHierarchy) {
//					for (int i = 10; i < 15; i++) {
//						_enemyMove.EnemySwiftCpuMove (i);
//					}
//				}
//
//				if (_team [3].activeInHierarchy) {
//					for (int i = 15; i < 20; i++) {
//						_enemyMove.EnemySwiftCpuMove (i);
//					}
//				}
			}
			//----------------------------------------------------------------------------------------------

			if (_enemyMove.SetMove ()) {
                if (_attackMotion) { 

				    if (_team [2].activeInHierarchy) {
					    _enemyMove.EnemyFuroideCpuAttack (_moveNum);
                        _targetCharaNum = _moveNum;
                        _attackMotion = false;
				    }

                    if (_team[3].activeInHierarchy) {
                        _enemyMove.EnemySwiftCpuAttack(_moveNum);
                        _targetCharaNum = _moveNum;
                        _attackMotion = false;
                    }
				}
			}
		}

        //毎F呼ばれるもの---------------------------------------------------------------------------------

		if (_endButton.EnemyEndChecker ()) {
			_enemyMainCheck = true;
			_cutIn [2].CutInWaiting ();
			_status = PartStatus.ENEMY_END_PHASE;
			return;
		}

        //----------------------------------------------------------------------------------------------------
    }

    void EnemyEnd() {
		if (_endButton.EnemyEndChecker()) {
			if (_enemyEndCheck) {
				_cutIn [3].CutInMotion ();
				//if (_team [2].activeInHierarchy) {
				//	_characterManeger.FuroideEnemyMonoRestriction ();
				//}

				//if (_team [3].activeInHierarchy) {
				//	_characterManeger.SwiftEnemyMonoRestriction ();
				//}
				_soundLibraly.StopSoundWithFadeOut ();
				_endButton.EnemyEndCheck (false);
				_enemyEndCheck = false;
				_phaseNum = 5;
				_characterManeger.AllSetPos ();

                //-------------------------------------------------
                if (_team[2].activeInHierarchy) {
                    for (int i = 10; i < 15; i++) {
                        if (_characterAnim[i].Mono()) {
                            _characterManeger.StopMonoRestriction(i);
                        }
                    }
                }

                if (_team[3].activeInHierarchy) {
                    for (int i = 15; i < 20; i++) {
                        if (_characterAnim[i].Mono()) {
                            _characterManeger.StopMonoRestriction(i);
                        }
                    }
                }
                //------------------------------------------------

            }

			}
		if (_cutIn [3].CutInWait ()) {
            _enemyEndCheck = true;
            _enemyMove.GetMiniReset();
			_status = PartStatus.YOUR_STANDBY_PHASE;
			return;
		}



    }

	//エネミーＣＰＵの動きを処理する関数(コルーチン)
	IEnumerator EnemyMoveAction( ) {
		if (_team [2].activeInHierarchy) {
			for (int i = 10; i < 15; i++) {
//				Debug.Log ("フロイデの移動");
				_enemyMove.EnemyFuroideCpuMove (i);
                _moveNum = i;
                _attackMotion = true;
                if (_characterManeger.GetCharacterWalk(i).gameObject.activeSelf)//死んでいないとき処理をする
                {
                    yield return new WaitForSeconds(_enemyAttackInterval);
                }
            }
		}

		if (_team [3].activeInHierarchy) {
			for (int i = 15; i < 20; i++) {
				_enemyMove.EnemySwiftCpuMove (i);
                _moveNum = i;
                _attackMotion = true;
                if (_characterManeger.GetCharacterWalk(i).gameObject.activeSelf)//死んでいないとき処理をする
                {
                    yield return new WaitForSeconds (_enemyAttackInterval);
                }
			}
		}
		_endButton.EnemyEndCheck (true);
        _enemyMove.GetMove();

    }

	public int numnum(){
		return _enemyMove.numnum();
	}
    public void PopUpButton()
    {
        _popupbutton.Slide0();
    }

    void EndPhaseMotion() {
        if (_team[0].activeInHierarchy)
        {
            for (int i = 0; i < 5; i++)
            {
                if (!_characterAnim[i].Mono() &&
                !_characterAnim[i].PenguinReinforcedFormMono())
                {
                    _characterManeger.MonoRestriction(i);
                }
            }
        }

        if (_team[1].activeInHierarchy)
        {
            for (int i = 5; i < 10; i++)
            {
                if (!_characterAnim[i].Mono() && !_characterAnim[5].Roop())
                {
                    _characterManeger.MonoRestriction(i);
                }
                if (!_characterAnim[i].Mono() && _characterAnim[5].Roop())
                {
                    for (int j = 6; j < 10; j++)
                    {
                        _characterManeger.MonoRestriction(j);
                    }
                }
            }
        }
    }
}
