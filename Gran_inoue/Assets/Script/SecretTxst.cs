using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretTxst : MonoBehaviour {

    int Set = -1;

    int BottonSet = 0;
    public int MAX = 0;

    [SerializeField]Text _text = null;
    [SerializeField]GameObject _gmtext = null;
    [SerializeField]GameObject[] _bottonview = new GameObject[0];

	// Use this for initialization
	void Start () {
        MAX -= 1;
    }
	
	// Update is called once per frame
	void Update () {
		switch (Set)
        {
            case 0://秘密１
                _text.text = "実はこのゲームにはボツになったシステムが\nいくつもあるんです！\n知りたいですか？\n知りたかったら開発者を探して聞いてみよう！";
                break;
            case 1://想い１
                _text.text = "はぁ～(*´Д｀)\nしんどいわ～(*´Д｀)";
                break;
            case 2://秘密２
                _text.text = "実はプログラマーがグラフィッカーに\nフォトショップという\nグラフィックソフトを教えたんだってさ！\nグラフィッカーとは…(;'∀')";
                break;
            case 3://想い２
                _text.text = "これをみたら就職させろ！！！";
                break;
            case 4://秘密３
                _text.text = "実は、タッチエフェクトや操作説明を作ったの\nつい最近なんです笑\nこの部屋もそうなんですが\n最後の最後にやりたいこととか出てくるんですよね(;´･ω･)";
                break;
            case 5://あいさつ１
                _text.text = "最初でも記載しましたが\nこの度は「グランバトルロワイヤル」\nを遊んでいただきありがとうございます！\n";
                break;
            case 6://あいさつ２
                _text.text = "このゲームには企画段階では\nあと4チームあるんですが\nどうしても開発が間に合わなく\nなんとか2チームは実装できました";
                break;
            case 7://あいさつ３
                _text.text = "今後、またこのゲームを作っていくとしたら！\n残りの4チームも開発して、\nもっと面白いものにしたいと思います！！\nこの後にアンケートをご用意してますので\nよければご回答おねがいします！！";
                break;
        }
	}

    public void nunmset(int a)
    {
        _gmtext.SetActive(false);
        Set = a;
    }

    public void Bottonview()
    {
        Debug.Log(BottonSet);
        _bottonview[BottonSet].SetActive(true);
        if (BottonSet != 0) {
            _bottonview[BottonSet - 1].SetActive(false);
        }
        if (BottonSet != MAX) {
            _bottonview[BottonSet + 1].SetActive(false);
        }

    }

    public void Next()
    {
        if (BottonSet < MAX)
        {
            BottonSet += 1;
            Bottonview();

        }
    }
    public void Back()
    {
        if (BottonSet > 0) {
            BottonSet -= 1;
            Bottonview();

        }
    }
}
