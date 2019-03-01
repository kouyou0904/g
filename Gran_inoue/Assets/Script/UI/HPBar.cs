using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

	[SerializeField] FroideStatus _froidestatus;
	[SerializeField] SwiftStatus _swiftstatus;
	[SerializeField] PenguinStatus _penguinstatus;
	[SerializeField] SwftShikigamiStandStatus _shikigamistatus;



	GameObject _gameobj;

	public Slider hpSlider; 

	// Use this for initialization
	void Start () {
		GameObject _gameobj = gameObject.transform.parent.gameObject;


		if (_gameobj.name == "Froide") {
			hpSlider.value = 1;//(float)_froidestatus.FroideMAXHP () / (float)_froidestatus.FroideMAXHP ();
		} 

		else if (_gameobj.name == "Swift") {
			hpSlider.value = 1;//(float)_swiftstatus.SwiftMAXHP () / (float)_swiftstatus.SwiftMAXHP ();
		} 

		else if (_gameobj.name == "Penguin"  ||
			_gameobj.name == "Penguin1" ||
			_gameobj.name == "Penguin2" ||
			_gameobj.name == "Penguin3" ||
			_gameobj.name == "Penguin4"    ) {
			hpSlider.value = 1;//(float)_penguinstatus.PenguinMAXHP (0) / (float)_penguinstatus.PenguinMAXHP (0);
		}

		else if (_gameobj.name == "SwiftShikigamiStand" ||
			     _gameobj.name == "SwiftShikigamiStand1"||
			     _gameobj.name == "SwiftShikigamiStand2"||
			     _gameobj.name == "SwiftShikigamiStand3"||
			     _gameobj.name == "SwiftShikigamiStand4"  ) {
			hpSlider.value = 1;//(float)_shikigamistatus.SwiftShikigamiMAXHP () / (float)_shikigamistatus.SwiftShikigamiMAXHP();
		}



	}
	
	// Update is called once per frame
	void Update () {
		GameObject _gameobj = gameObject.transform.parent.gameObject;
		if (_gameobj.name == "Froide") {
			hpSlider.value = (float)_froidestatus.FroideHP (0) / (float)_froidestatus.FroideMAXHP ();
		} 

		 else if (_gameobj.name == "Swift") {
			hpSlider.value = (float)_swiftstatus.SwiftHP (0) / (float)_swiftstatus.SwiftMAXHP ();
		} 

		else if (_gameobj.name == "Penguin"  ||
			_gameobj.name == "Penguin1" ||
			_gameobj.name == "Penguin2" ||
			_gameobj.name == "Penguin3" ||
			_gameobj.name == "Penguin4"    ) {
			hpSlider.value = (float)_penguinstatus.PenguinHP (0) / (float)_penguinstatus.PenguinMAXHP (0);
		}

		else if (_gameobj.name == "SwiftShikigamiStand" ||
			_gameobj.name == "SwiftShikigamiStand1"||
			_gameobj.name == "SwiftShikigamiStand2"||
			_gameobj.name == "SwiftShikigamiStand3"||
			_gameobj.name == "SwiftShikigamiStand4"  ) {
			hpSlider.value = (float)_shikigamistatus.SwiftShikigamiHP (0) / (float)_shikigamistatus.SwiftShikigamiMAXHP();
		}


	}
		

}
