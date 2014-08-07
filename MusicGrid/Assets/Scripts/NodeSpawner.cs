using UnityEngine;
using System.Collections;

public class NodeSpawner : MonoBehaviour {

	public GameObject NodePrefab;
	public GameObject EffectPrefab;
	public float NodeZ = 0.05f;

	GameObject NodeBase;
	int stime = -1;
	FieldStatus fStatus;
	MusicController mController;
	void Start () {
		fStatus = GetComponent<FieldStatus> ();
		mController = GameObject.Find ("MusicPlayer").gameObject.GetComponent<MusicController> ();

		NodeBase = new GameObject ();
	}

	void Update () {
		int t = Mathf.FloorToInt(mController.getTmpTime ());
		if (t > stime) {
			stime = t;
			spawnNode ();
		}
	}

	void spawnNode(){
		SpawnData data = fStatus.getSpawnData ();
		Vector3 pos = Vector3.zero;
		pos.x = data.Position.x;
		pos.y = data.Position.y;
		pos.z = NodeZ;
		GameObject node = (GameObject)Instantiate (NodePrefab);
		node.transform.position = pos;
		node.transform.parent = NodeBase.transform;
		NodeController nc = node.GetComponent<NodeController> ();
		nc.setNodeStatus ((float)stime, (float)stime + 4, data.Position, data.Position + data.FwdVec * fStatus.FieldScale.x);
		
		GameObject effect = (GameObject)Instantiate (EffectPrefab);
		effect.transform.position = pos;
		effect.transform.parent = NodeBase.transform;
	}
}
