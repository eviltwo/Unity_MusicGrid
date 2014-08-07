using UnityEngine;
using System.Collections;

public class NodeSpawner : MonoBehaviour {

	public GameObject NodePrefab;
	public float NodeY = 0.05f;

	int stime = 0;
	int stimemax = 15;
	FieldStatus fStatus;
	void Start () {
		fStatus = GetComponent<FieldStatus> ();
	}

	void Update () {
		stime++;
		if (stime >= stimemax) {
			stime = 0;
			spawnNode ();
		}
	}

	void spawnNode(){
		SpawnData data = fStatus.getSpawnData ();
		Vector3 pos = Vector3.zero;
		pos.x = data.Position.x;
		pos.y = NodeY;
		pos.z = data.Position.y;
		GameObject node = (GameObject)Instantiate (NodePrefab);
		node.transform.position = pos;
		node.GetComponent<NodeController> ().setVector (data.FwdVec);
	}
}
