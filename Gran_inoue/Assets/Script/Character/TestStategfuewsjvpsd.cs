using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStategfuewsjvpsd : MonoBehaviour {


	//Status _status;
	//[SerializeField] LayerMask layerMask;

 //   int PlayerHP;
 //   int PlayersabuHP;
 //   int EnemyHP;
 //   int EnemysabuHP;


	//public GameObject StatusUI;
	//public Status PlayerStatus;

 //   //テキストファイルで読み込むための準備☆
 //   [SerializeField]
 //   private TextAsset textAsset;
 //   //テキストファイルから読み込んだデータ
 //   private string loadtext;
 //   //改行で分割して配列に入れる
 //   private string[] splitText;
 //   //

 //   bool a = false;
	//float maxDistance = 10;

 //   // Use this for initialization
 //   void Start() {
 //       //☆
 //       if ( Froide == Player ){
 //           loadtext(Plyer) = (Resources.Load("Froide_Status", typeof(TextAsset)) as TextAsset).text;
 //           splitText(Player) = loadtext.Split(char.Parse("\n"));
 //           loadtext(Plyersabu) = (Resources.Load("pengin_Status", typeof(TextAsset)) as TextAsset).text;
 //           splitText = loadtext.Split(char.Parse("\n"));
 //           loadtext(Enemy) = (Resources.Load("kami_Status", typeof(TextAsset)) as TextAsset).text;
 //           splitText = loadtext.Split(char.Parse("\n"));
 //           loadtext(Enemysabu) = (Resources.Load("kamisabu_Status", typeof(TextAsset)) as TextAsset).text;
 //           splitText = loadtext.Split(char.Parse("\n"));
 //       }

 //       {
 //           loadtext = (Resources.Load("kami_Status", typeof(TextAsset)) as TextAsset).text;
 //           splitText = loadtext.Split(char.Parse("\n"));
 //       }

 //       {
 //           loadtext = (Resources.Load("kasu_Status", typeof(TextAsset)) as TextAsset).text;
 //           splitText = loadtext.Split(char.Parse("\n"));
 //       }

 //       {
 //           loadtext = (Resources.Load("ore_Status", typeof(TextAsset)) as TextAsset).text;
 //           splitText = loadtext.Split(char.Parse("\n"));
 //       }

 //       PlayerHP = int.Parse(splitText(Player)[0]);


 //       //
 //       _status = GetComponent<Status> ();
	//}
	
	//// Update is called once per frame
	//void Update () {
	//	//マウスのボタンの取得
	//	if (Input.GetMouseButtonDown(0)) {
	//		//RayCastの発動
	//		Ray ray = new Ray( );
	//		ray = Camera.main.ScreenPointToRay( Input.mousePosition );
	//		RaycastHit2D hit = Physics2D.Raycast( (Vector2)ray.origin, (Vector2)ray.direction,maxDistance,layerMask );

	//		//もし、コライダーにぶつかったとき
	//		if ( hit.collider ) {
	//			//ヒットしたコライダーの名前が○○だったら
	//			if ( hit.collider.gameObject.name == ("Froide") ) {
	//				Status.Name = "フロイデ";
 //                   Status.HP = PlayerHP;
 //                   Status.Attack = int.Parse(splitText[1]);
               
	//				a = true;
	//			}
	//			if ( hit.collider.gameObject.name == ("Swift") ) {
	//				Status.Name = "迅獅子";
	//				Status.HP = 50;
	//				a = true;
	//			}
	//			//ステータスUIをアクティブにする
	//			StatusUI.SetActive( a );
	//		}


	//	}
	//}


 //   public void AttackMotion()
 //   {
       


 //   }
 

}
