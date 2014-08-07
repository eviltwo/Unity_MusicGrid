using UnityEngine;
using System.Collections;

public class TimeGetTest : MonoBehaviour {

	MusicController mController;

	// Use this for initialization
	void Start () {
		mController = GameObject.Find ("MusicPlayer").gameObject.GetComponent<MusicController> ();
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = ""+Mathf.FloorToInt(mController.getTmpTime ()+1);
	}
}
