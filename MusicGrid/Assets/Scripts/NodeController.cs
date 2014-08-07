using UnityEngine;
using System.Collections;

public class NodeController : MonoBehaviour {

	Vector2 SPos = Vector2.zero;
	Vector2 GPos = Vector2.zero;
	float STmp = 0;
	float GTmp = 0;
	float Speed = 2;
	MusicController mController;
	// Use this for initialization
	void Start () {
		mController = GameObject.Find ("MusicPlayer").gameObject.GetComponent<MusicController> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveNode ();
	}

	void moveNode(){
		float mlt = (mController.getTmpTime()-STmp)/(GTmp - STmp);

		if (mlt >= 1) {
			Destroy (this.gameObject);
		}
		Vector2 pos = Vector2.zero;
		pos.x = SPos.x + (GPos.x - SPos.x) * mlt;
		pos.y = SPos.y + (GPos.y - SPos.y) * mlt;
		Vector3 npos = Vector3.zero;
		npos.x = pos.x;
		npos.y = transform.position.y;
		npos.z = pos.y;
		transform.localPosition = npos;
	}

	public void setNodeStatus(float StartTmp, float EndTmp, Vector2 StartPos, Vector2 EndPos){
		STmp = StartTmp;
		GTmp = EndTmp;
		SPos = StartPos;
		GPos = EndPos;
	}
}
