using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioClip Clip;
	public float BPM = 120.0f;
	public float Delay = 0.0f;

	float PlatformDelay = 0;
	float nowtime = 0;
	float oldtime = -1;
	// Use this for initialization
	void Start () {
		setMusic ();
		playMusic ();

		if (Application.platform == RuntimePlatform.Android) {
			PlatformDelay = 0.18f;
		}
		Delay += PlatformDelay;
	}
	
	// Update is called once per frame
	void Update () {
		nowtime = audio.time;
		if (nowtime == oldtime) {
			nowtime += Time.deltaTime;
		}
		oldtime = nowtime;
	}

	// 曲をセット
	void setMusic(){
		audio.clip = Clip;
	}

	// 曲を再生
	void playMusic(){
		audio.Play ();
	}

	// 再生時間を取得
	public float getSecTime(){
		return nowtime;
	}

	// 再生拍子を取得
	public float getTmpTime(){
		float t = (getSecTime ()-Delay)/(60/BPM);
		return t;
	}
}
