using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibraly : MonoBehaviour {
	AudioSource _audioSource;
	public float fadeOutSpeed = 1.1f;

	// Use this for initialization
	void Start () {
		_audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator StopSoundWithFadeOutCoroutine() {
		while (_audioSource.volume > 0) {
			_audioSource.volume -= fadeOutSpeed * Time.deltaTime;
			yield return new WaitForSeconds (Time.deltaTime);
		}
		_audioSource.Stop ();
		_audioSource.volume = 1f;
	}

	//--音をフェードアウトし止める関数
	public void StopSoundWithFadeOut() {
		StartCoroutine (StopSoundWithFadeOutCoroutine());
	}

	public void StopSound(){
		if (_audioSource.volume == 0) {
			_audioSource.Stop ();
		}
	}
}
