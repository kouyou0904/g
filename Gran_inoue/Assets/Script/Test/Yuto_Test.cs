using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Yuto_Test : MonoBehaviour {

	[SerializeField]GameObject TEST = null;


	// Use this for initialization
	void Start () {
		
	}
   

    // Update is called once per frame
    void Update () {
		gameObject.transform.localScale += new Vector3(-0.005f, 0,0);

		gameObject.transform.localScale += new Vector3(0, -0.005f,0);

	if (TEST.transform.localScale == new Vector3 (0, 0, 1)) {
			Destroy (TEST);
		}
	}
 
}
