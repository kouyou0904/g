using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour {

	//SoundOptionキャンパスを設定
	[SerializeField]
	private GameObject SoundOptionCanvas;
	//GameSoundShot
	[SerializeField]
	private AudioMixerSnapshot gameSoundShot;
	//OptionSoundshot
	[SerializeField]
	private AudioMixerSnapshot optionSoundShot;

	[SerializeField]
	private AudioMixer audioMixer;



	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetMaster(float volume){
		audioMixer.SetFloat ("MasterVol", volume);
	}

	public void SetBGM(float volume){
		audioMixer.SetFloat ("BGMVol", volume);
	}

	public void SetSE(float volume){
		audioMixer.SetFloat ("SEVol", volume);
	}
	public void SetVoice(float volume){
		audioMixer.SetFloat ("VoiceVol", volume);
	}
}
