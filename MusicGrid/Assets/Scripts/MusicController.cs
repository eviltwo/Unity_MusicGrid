using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public AudioClip Clip;
	public float BPM = 120.0f;
	public float Delay = 0.0f;

	// Use this for initialization
	void Start () {
		setMusic ();
		playMusic ();
	}
	
	// Update is called once per frame
	void Update () {
		float t = getSecTime ();
		Debug.Log (t);
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
		float t = audio.time;
		return t;
	}

	// 再生拍子を取得
	public float getTmpTime(){
		float t = (getSecTime ()-Delay)/(60/BPM);
		return t;
	}
}
