
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    [SerializeField]
    LayerMask layerMask;
    [SerializeField]
    CharacterAttackCircle[] _characterAttackCircle = new CharacterAttackCircle[20];
    [SerializeField]
    GameObject[] _circleAttack = new GameObject[10];
    [SerializeField]
    GameObject[] _posUi = new GameObject[5];
    [SerializeField]
    GameObject[] _battleUi = new GameObject[5];
    [SerializeField]
    FroideStatus[] _fstatus = new FroideStatus[2];
    [SerializeField]
    SwiftStatus[] _sstatus = new SwiftStatus[2];
    [SerializeField]
    PenguinStatus[] _pstatus = new PenguinStatus[8];
    [SerializeField]
    SwftShikigamiStandStatus[] _ssstatus = new SwftShikigamiStandStatus[8];
    [SerializeField]
    CharacterManeger _characterManeger = null;
    [SerializeField]
    UiManeger _uiManeger = null;
    [SerializeField]
    GameObject[] _team = new GameObject[2];
    [SerializeField]
    BattleManeger _battleManeger = null;
    [SerializeField]
    TurnManeger _turnManeger = null;
    [SerializeField] SkillManeger _skillManeger = null;
    [SerializeField]
    GameObject[] _manual = new GameObject[5];

    RaycastHit2D hit;

    public GameObject StatusUI_PLayer;
    public GameObject StatusUI_Enemy;
    public Status PlayerStatus;

    public Sprite FIcon_Player;
    public Sprite FIcon_Enemy;
    public Sprite PIcon_Player;
    public Sprite PIcon_Enemy;
    public Sprite PSIcon_Player;
    public Sprite PSIcon_Enemy;
    public Sprite SSIcon_Player;
    public Sprite SSIcon_Enemy;
    public Sprite SIcon_Player;
    public Sprite SIcon_Enemy;

	public int RingOutDmage = 20;

    public float DestroyTime = 0f;
    public float CircleValue = 1f;
    public float RunTIme = 1f;




    float[] _radius = new float[20];
    //テキストファイルで読み込むための準備☆
    [SerializeField]
    private TextAsset textAsset;
    //テキストファイルから読み込んだデータ
    private string loadtext;
    //改行で分割して配列に入れる
    private string[] splitText;
    //
    bool _circleChecker;
    bool _moveManual;
    bool diedcheck = false;

    bool _attackCheck;
    static bool a = false;
    static bool b = false;
    float maxDistance = 10;


    // Use this for initialization
    void Start()
    {
        //☆
        loadtext = (Resources.Load("Froide_Status", typeof(TextAsset)) as TextAsset).text;
        splitText = loadtext.Split(char.Parse("\n"));
        //
        _circleChecker = false;
        _attackCheck = false;
        _moveManual = false;

        for (int i = 0; i < _characterAttackCircle.Length; i++)
        {

            //攻撃範囲の円の半径の導出----------------------------------------------------------------------------------------
            Sprite attackRangeCircleSprite = _characterAttackCircle[i].GetComponent<SpriteRenderer>().sprite;//範囲の円のsprite
            Vector3 attckRangeCircleScale = _characterAttackCircle[i].gameObject.transform.localScale;
            _radius[i] = ((attackRangeCircleSprite.rect.width / 2) * attckRangeCircleScale.x / attackRangeCircleSprite.pixelsPerUnit) * CircleValue;
            //----------------------------------------------------------------------------------------------------------------
        }
        //StatusUIのアクティブの初期化
        a = false;
        b = false;

    }

    // Update is called once per frame
    void Update()
    {
        //マウスのボタンの取得

//		Debug.Log(_characterManeger.TargetDisplaySet());
		for (int i = 0; i < 10; i++){
		    if ( !_characterAttackCircle[i].CircleCheck() ){
			     _characterManeger.TargetIndividualDisplay(false, _characterAttackCircle[i].GetExitCircleChara());
			}
		}

        if (_manual[0].activeInHierarchy || 
            _manual[1].activeInHierarchy ||
            _manual[2].activeInHierarchy || 
            _manual[3].activeInHierarchy ||
            _manual[4].activeInHierarchy) {
            _characterManeger.PlayerMoveTrigger(false);
            _moveManual = true;
        }

        if (!_manual[0].activeInHierarchy &&
            !_manual[1].activeInHierarchy &&
            !_manual[2].activeInHierarchy &&
            !_manual[3].activeInHierarchy &&
            !_manual[4].activeInHierarchy && 
            _turnManeger._phaseNum == 1 &&
            _moveManual) {
            _characterManeger.ActionSetting();
            _moveManual = false;
        }

            TargetStatusOutput();

        for (int i = 0; i < 20; i++)
        {
          //  Debug.Log(_characterManeger.FieldCharaDisapper(i));

            if (_characterManeger.FieldCharaDisapper(i) >= 0)
            {
                _battleManeger.RingOutRun(_characterManeger.FieldCharaDisapper(i), RingOutDmage);
				//a = false;
				//b = false;

            }
            if (i >= 20)
            {
                i = -1;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
                if (!_manual[0].activeInHierarchy && !_manual[1].activeInHierarchy &&
                !_manual[2].activeInHierarchy && !_manual[3].activeInHierarchy &&
                !_manual[4].activeInHierarchy) {
                //RayCastの発動
                Ray ray = new Ray();
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, layerMask);
            }
        
           // Debug.Log("たーん："+_turnManeger._phaseNum);
           // もし、コライダーにぶつかったとき
            if (hit.collider)
            {

                StatusOutput();
             //   Debug.Log(hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "Player" ||
                     hit.collider.gameObject.tag == "SubPlayer")
                {
                    _battleManeger.PlayerInput();
                  //  Debug.Log("できたよー");
                }
                /*                if (hit.collider.gameObject.tag == "Enemy" ||
                                     hit.collider.gameObject.tag == "SubEnemy")
                                {
                                    _battleManeger.EnemyInput();
                                }
                */
                PlayerBattle();

            }

        

        }

		if ( _turnManeger._phaseNum == 5 ) {
			Debug.Log( "非アクティブ");
			a = false;
			b = false;
		}
        if (_turnManeger._phaseNum == 2)
        {
            Debug.Log("非アクティブ");
            a = false;
            b = false;
        }

        //AttackCircleChara();
		//EnemyAttackCircleChara();

        StatusUI_PLayer.SetActive(a);
        StatusUI_Enemy.SetActive(b);


    }

    public void Diedmotion()
    {
        
            a = false;
            b = false;
       


    }

    public float AttackRadius(int arrayNumber)
    {
        return _radius[arrayNumber];
    }

    //攻撃される側のキャラクターの配列番号を取得する関数(ゲッター)
    public int GetTargetCharaNum()
    {
        return _turnManeger._targetCharaNum;
    }

    //攻撃される側のキャラクターの配列番号を変更する関数(セッター)
    public void SetTargetCharaNum(int arrayNum)
    {
        _turnManeger._targetCharaNum = arrayNum;
    }


    public void StatusOutput()
    {
        //ヒットしたコライダーの名前が○○だったら

        //player---------------------------------------------------------------
        //Taem1----------------------------------------------------------------
        if (hit.collider.gameObject.name == ("Froide") &&
            hit.collider.gameObject.tag == ("Player"))
        {
            Status.Name = "フロイデ";
            Status.Icon = FIcon_Player;
            Status.HP = _fstatus[0].FroideHP(0);
            Status.Attack = _fstatus[0].FroideAttack();
            Status.MagicAttack = _fstatus[0].FroideMAttck();
            Status.Impact = _fstatus[0].FroideImpact();
            Status.Defance = _fstatus[0].FroideDefance();
            Status.MagicDefance = _fstatus[0].FroideMDefance();
            Status.Weight = _fstatus[0].FroideWeight();
            Status.Technology = _fstatus[0].FroideTechnology();
            Status.Avoidance = _fstatus[0].FroideAvoidance();
            a = true;
            b = false;
        }
        if ((hit.collider.gameObject.name == ("Penguin") &&
            hit.collider.gameObject.tag == ("SubPlayer"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 1)*/)
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん1";
                Status.Icon = PIcon_Player;
            }
            else if( _skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん1";
                Status.Icon = PSIcon_Player;
            }
            Status.HP = _pstatus[0].PenguinHP(0);
            Status.Attack = _pstatus[0].PenguinAttack(0);
            Status.MagicAttack = _pstatus[0].PenguinMAttck(0);
            Status.Impact = _pstatus[0].PenguinImpact(0);
            Status.Defance = _pstatus[0].PenguinDefance(0);
            Status.MagicDefance = _pstatus[0].PenguinMDefance(0);
            Status.Weight = _pstatus[0].PenguinWeight(0);
            Status.Technology = _pstatus[0].PenguinTechnology();
            Status.Avoidance = _pstatus[0].PenguinAvoidance();
            a = true;
            b = false;
        }
        if (hit.collider.gameObject.name == ("Penguin1") &&
            hit.collider.gameObject.tag == ("SubPlayer"))
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん2";
                Status.Icon = PIcon_Player;
            }
            else if  (_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん2";
                Status.Icon = PSIcon_Player;
            }
            Status.HP = _pstatus[1].PenguinHP(0);
            Status.Attack = _pstatus[1].PenguinAttack(0);
            Status.MagicAttack = _pstatus[1].PenguinMAttck(0);
            Status.Impact = _pstatus[1].PenguinImpact(0);
            Status.Defance = _pstatus[1].PenguinDefance(0);
            Status.MagicDefance = _pstatus[1].PenguinMDefance(0);
            Status.Weight = _pstatus[1].PenguinWeight(0);
            Status.Technology = _pstatus[1].PenguinTechnology();
            Status.Avoidance = _pstatus[1].PenguinAvoidance();
            a = true;
            b = false;
        }
        if ((hit.collider.gameObject.name == ("Penguin2") &&
            hit.collider.gameObject.tag == ("SubPlayer")))
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん3";
                Status.Icon = PIcon_Player;
            }
            else if (_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん3";
                Status.Icon = PSIcon_Player;
            }
            Status.HP = _pstatus[2].PenguinHP(0);
            Status.Attack = _pstatus[2].PenguinAttack(0);
            Status.MagicAttack = _pstatus[2].PenguinMAttck(0);
            Status.Impact = _pstatus[2].PenguinImpact(0);
            Status.Defance = _pstatus[2].PenguinDefance(0);
            Status.MagicDefance = _pstatus[2].PenguinMDefance(0);
            Status.Weight = _pstatus[2].PenguinWeight(0);
            Status.Technology = _pstatus[2].PenguinTechnology();
            Status.Avoidance = _pstatus[2].PenguinAvoidance();
            a = true;
            b = false;
        }
        if ((hit.collider.gameObject.name == ("Penguin3") &&
            hit.collider.gameObject.tag == ("SubPlayer"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 4)*/)
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん4";
                Status.Icon = PIcon_Player;
            }
            else if (_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん4";
                Status.Icon = PSIcon_Player;
            }
            Status.HP = _pstatus[3].PenguinHP(0);
            Status.Attack = _pstatus[3].PenguinAttack(0);
            Status.MagicAttack = _pstatus[3].PenguinMAttck(0);
            Status.Impact = _pstatus[3].PenguinImpact(0);
            Status.Defance = _pstatus[3].PenguinDefance(0);
            Status.MagicDefance = _pstatus[3].PenguinMDefance(0);
            Status.Weight = _pstatus[3].PenguinWeight(0);
            Status.Technology = _pstatus[3].PenguinTechnology();
            Status.Avoidance = _pstatus[3].PenguinAvoidance();
            a = true;
            b = false;
        }

        //Team2-------------------------------------------------------------------			

        if ((hit.collider.gameObject.name == ("Swift") &&
            hit.collider.gameObject.tag == ("Player"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 5)*/ )
        {
            Status.Name = "迅獅子";
            Status.Icon = SIcon_Player;
            Status.HP = _sstatus[0].SwiftHP(0);
            Status.Attack = _sstatus[0].SwiftAttack(0);
            Status.MagicAttack = _sstatus[0].SwiftMAttck(0);
            Status.Impact = _sstatus[0].SwiftImpact(0);
            Status.Defance = _sstatus[0].SwiftDefance(0);
            Status.MagicDefance = _sstatus[0].SwiftMDefance(0);
            Status.Weight = _sstatus[0].SwiftWeight(0);
            Status.Technology = _sstatus[0].SwiftTechnology(0);
            Status.Avoidance = _sstatus[0].SwiftAvoidance(0);
            a = true;
            b = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand") &&
            hit.collider.gameObject.tag == ("SubPlayer"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 6)*/ )
        {
            Status.Name = "式神1";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[0].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[0].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[0].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[0].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[0].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[0].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[0].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[0].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[0].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand1") &&
            hit.collider.gameObject.tag == ("SubPlayer"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 7)*/)
        {
            Status.Name = "式神2";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[1].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[1].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[1].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[1].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[1].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[1].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[1].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[1].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[1].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand2") &&
            hit.collider.gameObject.tag == ("SubPlayer"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 8)*/)
        {
            Status.Name = "式神3";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[2].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[2].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[2].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[2].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[2].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[2].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[2].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[2].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[2].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand3") &&
            hit.collider.gameObject.tag == ("SubPlayer"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 9)*/)
        {
            Status.Name = "式神4";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[3].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[3].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[3].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[3].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[3].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[3].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[3].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[3].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[3].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }

        //enemy-------------------------------------------------------------------
        //Team1-------------------------------------------------------------------
        if ((hit.collider.gameObject.name == ("Froide") &&
            hit.collider.gameObject.tag == ("Enemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 10)*/)
        {
            Status.Name = "フロイデ";
            Status.Icon = FIcon_Enemy;
            Status.HP = _fstatus[1].FroideHP(0);
            Status.Attack = _fstatus[1].FroideAttack();
            Status.MagicAttack = _fstatus[1].FroideMAttck();
            Status.Impact = _fstatus[1].FroideImpact();
            Status.Defance = _fstatus[1].FroideDefance();
            Status.MagicDefance = _fstatus[1].FroideMDefance();
            Status.Weight = _fstatus[1].FroideWeight();
            Status.Technology = _fstatus[1].FroideTechnology();
            Status.Avoidance = _fstatus[1].FroideAvoidance();
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("Penguin") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 11)*/)
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん1";
                Status.Icon = PIcon_Enemy;
            }
            else if (_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん1";
                Status.Icon = PSIcon_Enemy;
            }
            Status.HP = _pstatus[4].PenguinHP(0);
            Status.Attack = _pstatus[4].PenguinAttack(0);
            Status.MagicAttack = _pstatus[4].PenguinMAttck(0);
            Status.Impact = _pstatus[4].PenguinImpact(0);
            Status.Defance = _pstatus[4].PenguinDefance(0);
            Status.MagicDefance = _pstatus[4].PenguinMDefance(0);
            Status.Weight = _pstatus[4].PenguinWeight(0);
            Status.Technology = _pstatus[4].PenguinTechnology();
            Status.Avoidance = _pstatus[4].PenguinAvoidance();
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("Penguin1") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 12)*/)
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん2";
                Status.Icon = PIcon_Enemy;
            }
            else if (_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん2";
                Status.Icon = PSIcon_Enemy;
            }
            Status.HP = _pstatus[5].PenguinHP(0);
            Status.Attack = _pstatus[5].PenguinAttack(0);
            Status.MagicAttack = _pstatus[5].PenguinMAttck(0);
            Status.Impact = _pstatus[5].PenguinImpact(0);
            Status.Defance = _pstatus[5].PenguinDefance(0);
            Status.MagicDefance = _pstatus[5].PenguinMDefance(0);
            Status.Weight = _pstatus[5].PenguinWeight(0);
            Status.Technology = _pstatus[5].PenguinTechnology();
            Status.Avoidance = _pstatus[5].PenguinAvoidance();
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("Penguin2") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 13)*/)
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん3";
                Status.Icon = PIcon_Enemy;
            }
            else if (_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん3";
                Status.Icon = PSIcon_Enemy;
            }
            Status.HP = _pstatus[6].PenguinHP(0);
            Status.Attack = _pstatus[6].PenguinAttack(0);
            Status.MagicAttack = _pstatus[6].PenguinMAttck(0);
            Status.Impact = _pstatus[6].PenguinImpact(0);
            Status.Defance = _pstatus[6].PenguinDefance(0);
            Status.MagicDefance = _pstatus[6].PenguinMDefance(0);
            Status.Weight = _pstatus[6].PenguinWeight(0);
            Status.Technology = _pstatus[6].PenguinTechnology();
            Status.Avoidance = _pstatus[6].PenguinAvoidance();
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("Penguin3") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 14)*/)
        {
            if (!_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンちゃん4";
                Status.Icon = PIcon_Enemy;
            }
            else if (_skillManeger.PSkillSet())
            {
                Status.Name = "ペンギンさん4";
                Status.Icon = PSIcon_Enemy;
            }
            Status.HP = _pstatus[7].PenguinHP(0);
            Status.Attack = _pstatus[7].PenguinAttack(0);
            Status.MagicAttack = _pstatus[7].PenguinMAttck(0);
            Status.Impact = _pstatus[7].PenguinImpact(0);
            Status.Defance = _pstatus[7].PenguinDefance(0);
            Status.MagicDefance = _pstatus[7].PenguinMDefance(0);
            Status.Weight = _pstatus[7].PenguinWeight(0);
            Status.Technology = _pstatus[7].PenguinTechnology();
            Status.Avoidance = _pstatus[7].PenguinAvoidance();
            b = true;
            a = false;
        }
        //Team2-------------------------------------------------------------------

        if ((hit.collider.gameObject.name == ("Swift") &&
            hit.collider.gameObject.tag == ("Enemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 15)*/)
        {
            Status.Name = "迅獅子";
            Status.Icon = SIcon_Enemy;
            Status.HP = _sstatus[1].SwiftHP(0);
            Status.Attack = _sstatus[1].SwiftAttack(0);
            Status.MagicAttack = _sstatus[1].SwiftMAttck(0);
            Status.Impact = _sstatus[1].SwiftImpact(0);
            Status.Defance = _sstatus[1].SwiftDefance(0);
            Status.MagicDefance = _sstatus[1].SwiftMDefance(0);
            Status.Weight = _sstatus[1].SwiftWeight(0);
            Status.Technology = _sstatus[1].SwiftTechnology(0);
            Status.Avoidance = _sstatus[1].SwiftAvoidance(0);
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 16)*/ )
        {
            Status.Name = "式神1";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[4].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[4].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[4].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[4].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[4].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[4].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[4].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[4].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[4].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand1") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 17)*/ )
        {
            Status.Name = "式神2";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[5].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[5].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[5].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[5].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[5].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[5].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[5].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[5].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[5].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand2") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 18)*/)
        {
            Status.Name = "式神3";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[6].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[6].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[6].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[6].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[6].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[6].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[6].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[6].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[6].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }
        if ((hit.collider.gameObject.name == ("SwiftShikigamiStand3") &&
            hit.collider.gameObject.tag == ("SubEnemy"))/*||
			(_turnManeger._phaseNum == 4 && _targetCharaNum == 19)*/)
        {
            Status.Name = "式神4";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[7].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[7].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[7].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[7].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[7].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[7].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[7].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[7].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[7].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }
    }

    public void TargetStatusOutput()
    {
        //ヒットしたコライダーの名前が○○だったら

        //player---------------------------------------------------------------
        //Taem1----------------------------------------------------------------
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 0)
        {
            Status.Name = "フロイデ";
            Status.Icon = FIcon_Player;
            Status.HP = _fstatus[0].FroideHP(0);
            Status.Attack = _fstatus[0].FroideAttack();
            Status.MagicAttack = _fstatus[0].FroideMAttck();
            Status.Impact = _fstatus[0].FroideImpact();
            Status.Defance = _fstatus[0].FroideDefance();
            Status.MagicDefance = _fstatus[0].FroideMDefance();
            Status.Weight = _fstatus[0].FroideWeight();
            Status.Technology = _fstatus[0].FroideTechnology();
            Status.Avoidance = _fstatus[0].FroideAvoidance();
                a = true;
                b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 1)
        {
            Status.Name = "ペンギン1";
            Status.Icon = PIcon_Player;
            Status.HP = _pstatus[0].PenguinHP(0);
            Status.Attack = _pstatus[0].PenguinAttack(0);
            Status.MagicAttack = _pstatus[0].PenguinMAttck(0);
            Status.Impact = _pstatus[0].PenguinImpact(0);
            Status.Defance = _pstatus[0].PenguinDefance(0);
            Status.MagicDefance = _pstatus[0].PenguinMDefance(0);
            Status.Weight = _pstatus[0].PenguinWeight(0);
            Status.Technology = _pstatus[0].PenguinTechnology();
            Status.Avoidance = _pstatus[0].PenguinAvoidance();
            a = true;
            b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 2)
        {
            Status.Name = "ペンギン2";
            Status.Icon = PIcon_Player;
            Status.HP = _pstatus[1].PenguinHP(0);
            Status.Attack = _pstatus[1].PenguinAttack(0);
            Status.MagicAttack = _pstatus[1].PenguinMAttck(0);
            Status.Impact = _pstatus[1].PenguinImpact(0);
            Status.Defance = _pstatus[1].PenguinDefance(0);
            Status.MagicDefance = _pstatus[1].PenguinMDefance(0);
            Status.Weight = _pstatus[1].PenguinWeight(0);
            Status.Technology = _pstatus[1].PenguinTechnology();
            Status.Avoidance = _pstatus[1].PenguinAvoidance();
            a = true;
            b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 3)
        {
            Status.Name = "ペンギン3";
            Status.Icon = PIcon_Player;
            Status.HP = _pstatus[2].PenguinHP(0);
            Status.Attack = _pstatus[2].PenguinAttack(0);
            Status.MagicAttack = _pstatus[2].PenguinMAttck(0);
            Status.Impact = _pstatus[2].PenguinImpact(0);
            Status.Defance = _pstatus[2].PenguinDefance(0);
            Status.MagicDefance = _pstatus[2].PenguinMDefance(0);
            Status.Weight = _pstatus[2].PenguinWeight(0);
            Status.Technology = _pstatus[2].PenguinTechnology();
            Status.Avoidance = _pstatus[2].PenguinAvoidance();
            a = true;
            b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 4)
        {
            Status.Name = "ペンギン4";
            Status.Icon = PIcon_Player;
            Status.HP = _pstatus[3].PenguinHP(0);
            Status.Attack = _pstatus[3].PenguinAttack(0);
            Status.MagicAttack = _pstatus[3].PenguinMAttck(0);
            Status.Impact = _pstatus[3].PenguinImpact(0);
            Status.Defance = _pstatus[3].PenguinDefance(0);
            Status.MagicDefance = _pstatus[3].PenguinMDefance(0);
            Status.Weight = _pstatus[3].PenguinWeight(0);
            Status.Technology = _pstatus[3].PenguinTechnology();
            Status.Avoidance = _pstatus[3].PenguinAvoidance();
            a = true;
            b = false;
        }

        //Team2-------------------------------------------------------------------			

        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 5)
        {
            Status.Name = "迅獅子";
            Status.Icon = SIcon_Player;
            Status.HP = _sstatus[0].SwiftHP(0);
            Status.Attack = _sstatus[0].SwiftAttack(0);
            Status.MagicAttack = _sstatus[0].SwiftMAttck(0);
            Status.Impact = _sstatus[0].SwiftImpact(0);
            Status.Defance = _sstatus[0].SwiftDefance(0);
            Status.MagicDefance = _sstatus[0].SwiftMDefance(0);
            Status.Weight = _sstatus[0].SwiftWeight(0);
            Status.Technology = _sstatus[0].SwiftTechnology(0);
            Status.Avoidance = _sstatus[0].SwiftAvoidance(0);
            a = true;
            b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 6)
        {
            Status.Name = "式神1";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[0].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[0].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[0].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[0].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[0].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[0].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[0].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[0].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[0].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 7)
        {
            Status.Name = "式神2";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[1].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[1].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[1].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[1].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[1].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[1].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[1].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[1].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[1].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 8)
        {
            Status.Name = "式神3";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[2].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[2].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[2].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[2].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[2].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[2].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[2].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[2].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[2].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 9)
        {
            Status.Name = "式神4";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[3].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[3].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[3].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[3].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[3].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[3].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[3].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[3].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[3].SwiftShikigamiAvoidance();
            a = true;
            b = false;
        }

        //enemy-------------------------------------------------------------------
        //Team1-------------------------------------------------------------------
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 10)
        {
            Status.Name = "フロイデ";
            Status.Icon = FIcon_Enemy;
            Status.HP = _fstatus[1].FroideHP(0);
            Status.Attack = _fstatus[1].FroideAttack();
            Status.MagicAttack = _fstatus[1].FroideMAttck();
            Status.Impact = _fstatus[1].FroideImpact();
            Status.Defance = _fstatus[1].FroideDefance();
            Status.MagicDefance = _fstatus[1].FroideMDefance();
            Status.Weight = _fstatus[1].FroideWeight();
            Status.Technology = _fstatus[1].FroideTechnology();
            Status.Avoidance = _fstatus[1].FroideAvoidance();
            b = true;
            a = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 11)
        {
            Status.Name = "ペンギン1";
            Status.Icon = PIcon_Enemy;
            Status.HP = _pstatus[4].PenguinHP(0);
            Status.Attack = _pstatus[4].PenguinAttack(0);
            Status.MagicAttack = _pstatus[4].PenguinMAttck(0);
            Status.Impact = _pstatus[4].PenguinImpact(0);
            Status.Defance = _pstatus[4].PenguinDefance(0);
            Status.MagicDefance = _pstatus[4].PenguinMDefance(0);
            Status.Weight = _pstatus[4].PenguinWeight(0);
            Status.Technology = _pstatus[4].PenguinTechnology();
            Status.Avoidance = _pstatus[4].PenguinAvoidance();
            b = true;
            a = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 12)
        {
            Status.Name = "ペンギン2";
            Status.Icon = PIcon_Enemy;
            Status.HP = _pstatus[5].PenguinHP(0);
            Status.Attack = _pstatus[5].PenguinAttack(0);
            Status.MagicAttack = _pstatus[5].PenguinMAttck(0);
            Status.Impact = _pstatus[5].PenguinImpact(0);
            Status.Defance = _pstatus[5].PenguinDefance(0);
            Status.MagicDefance = _pstatus[5].PenguinMDefance(0);
            Status.Weight = _pstatus[5].PenguinWeight(0);
            Status.Technology = _pstatus[5].PenguinTechnology();
            Status.Avoidance = _pstatus[5].PenguinAvoidance();
            b = true;
            a = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 13)
        {
            Status.Name = "ペンギン3";
            Status.Icon = PIcon_Enemy;
            Status.HP = _pstatus[6].PenguinHP(0);
            Status.Attack = _pstatus[6].PenguinAttack(0);
            Status.MagicAttack = _pstatus[6].PenguinMAttck(0);
            Status.Impact = _pstatus[6].PenguinImpact(0);
            Status.Defance = _pstatus[6].PenguinDefance(0);
            Status.MagicDefance = _pstatus[6].PenguinMDefance(0);
            Status.Weight = _pstatus[6].PenguinWeight(0);
            Status.Technology = _pstatus[6].PenguinTechnology();
            Status.Avoidance = _pstatus[6].PenguinAvoidance();
            b = true;
            a = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 14)
        {
            Status.Name = "ペンギン4";
            Status.Icon = PIcon_Enemy;
            Status.HP = _pstatus[7].PenguinHP(0);
            Status.Attack = _pstatus[7].PenguinAttack(0);
            Status.MagicAttack = _pstatus[7].PenguinMAttck(0);
            Status.Impact = _pstatus[7].PenguinImpact(0);
            Status.Defance = _pstatus[7].PenguinDefance(0);
            Status.MagicDefance = _pstatus[7].PenguinMDefance(0);
            Status.Weight = _pstatus[7].PenguinWeight(0);
            Status.Technology = _pstatus[7].PenguinTechnology();
            Status.Avoidance = _pstatus[7].PenguinAvoidance();
            b = true;
            a = false;
        }
        //Team2-------------------------------------------------------------------

        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 15)
        {
            Status.Name = "迅獅子";
            Status.Icon = SIcon_Enemy;
            Status.HP = _sstatus[1].SwiftHP(0);
            Status.Attack = _sstatus[1].SwiftAttack(0);
            Status.MagicAttack = _sstatus[1].SwiftMAttck(0);
            Status.Impact = _sstatus[1].SwiftImpact(0);
            Status.Defance = _sstatus[1].SwiftDefance(0);
            Status.MagicDefance = _sstatus[1].SwiftMDefance(0);
            Status.Weight = _sstatus[1].SwiftWeight(0);
            Status.Technology = _sstatus[1].SwiftTechnology(0);
            Status.Avoidance = _sstatus[1].SwiftAvoidance(0);
            b = true;
            a = false;
        }

        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 16)
        {
            Status.Name = "式神1";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[4].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[4].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[4].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[4].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[4].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[4].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[4].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[4].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[4].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 17)
        {
            Status.Name = "式神2";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[5].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[5].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[5].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[5].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[5].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[5].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[5].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[5].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[5].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }
        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 18)
        {
            Status.Name = "式神3";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[6].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[6].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[6].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[6].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[6].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[6].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[6].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[6].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[6].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }

        if (_turnManeger._phaseNum == 4 && _turnManeger._targetCharaNum == 19)
        {
            Status.Name = "式神4";
            Status.Icon = SSIcon_Player;
            Status.HP = _ssstatus[7].SwiftShikigamiHP(0);
            Status.Attack = _ssstatus[7].SwiftShikigamiAttack();
            Status.MagicAttack = _ssstatus[7].SwiftShikigamiMAttck();
            Status.Impact = _ssstatus[7].SwiftShikigamiImpact();
            Status.Defance = _ssstatus[7].SwiftShikigamiDefance();
            Status.MagicDefance = _ssstatus[7].SwiftShikigamiMDefance();
            Status.Weight = _ssstatus[7].SwiftShikigamiWeight();
            Status.Technology = _ssstatus[7].SwiftShikigamiTechnology();
            Status.Avoidance = _ssstatus[7].SwiftShikigamiAvoidance();
            b = true;
            a = false;
        }
    }

    //プレイヤー側が攻撃をする関数-----------------------------------------------------------------------------------------------
    void PlayerBattle() {
        bool Run = false;
        for (int i = 0; i < 10; i++) {
            if (_characterAttackCircle[i].CircleCheck()) {
                if (_circleAttack[i].activeInHierarchy) {
				_turnManeger._targetCharaNum = hit.collider.gameObject.GetComponent<CharacterWalk>().ARRAYNUMBER;
				    if(_radius[i] > (_characterManeger.CharacterPos(i) - _characterManeger.CharacterPos(_turnManeger._targetCharaNum)).magnitude){
                         _circleChecker = true;
                        if (hit.collider.gameObject.tag == ("Enemy") ||
                            hit.collider.gameObject.tag == ("SubEnemy")) {
                            _attackCheck = true;
                            _circleChecker = false;
                            _battleManeger.EnemyInput();
                            _characterManeger.PlayerBattle(i);
                            _characterManeger.GetPosThree(true);
                            _uiManeger.PosUiResponse(false);
                            Run = true;
                        }
					}
                }
            }
        }
        if ( Run == true)
        {
            Invoke("PlayerRun", RunTIme);
        }
    }
    //----------------------------------------------------------------------------------------------------------------------------

    public bool GetCharaAttackCircle(int arrayNumber) {
        return _characterAttackCircle[arrayNumber].CircleCheck();
    }

    public bool GetAttackCheck() {
        return _attackCheck;
    }

    public void SetAttackCheck(bool value) {
        _attackCheck = value;
    }

    void AttackCircleChara() {
        for (int i = 0; i < 10; i++) {
            if (_characterAttackCircle[i].CircleCheck()) {
                if (_radius[i] > (_characterManeger.CharacterPos(i) - _characterManeger.CharacterPos(_turnManeger._targetCharaNum)).magnitude) {
                    Debug.Log(_characterAttackCircle[i].GetCircleChara());
                    _characterManeger.TargetIndividualDisplay(true, _characterAttackCircle[i].GetCircleChara());
                }
            }
        }
    }

   

	void EnemyAttackCircleChara() {
        for (int i = 0; i < 10; i++) {
			if (!_characterAttackCircle[i].CircleCheck()) {
				if (_radius[i] < (_characterManeger.CharacterPos(i) - _characterManeger.CharacterPos(_turnManeger._targetCharaNum)).magnitude) {
					for ( int j = 10; j < 20; j++  ){
						if ( _characterManeger.TargetDisplaySet() == j ){
//							 Debug.Log(_characterAttackCircle[i].GetExitCircleChara());
								_characterManeger.TargetIndividualDisplay(false, _characterAttackCircle[i].GetExitCircleChara());

						}
					}
				}
			}
		}
	}

    void PlayerRun()
    {
        _battleManeger.PlayerRun();
    }

	public int numnum(){
		
		return _turnManeger.numnum();
	}
}