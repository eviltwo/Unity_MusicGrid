using UnityEngine;
using System.Collections;

public class FieldLineCreator : MonoBehaviour {

	public GameObject LinePrefab;
	public int LineValue = 8;
	public float LineZ = 0.1f;

	FieldStatus fStatus;

	void Start () {
		fStatus = GetComponent<FieldStatus> ();
		setLine ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// 線を設置
	void setLine(){
		Vector2 FieldScale = fStatus.FieldScale;
		GameObject LineBase = new GameObject ();
		LineBase.name = "LineBase";
		for (int iy = 0; iy < LineValue; iy++) {
			Vector3 pos = new Vector3 ();
			pos.x = 0;
			pos.y = (FieldScale.y / (float)(LineValue - 1)) * iy;
			pos.z = LineZ;
			Vector3 scl = new Vector3 ();
			scl.x = FieldScale.x;
			scl.y = 1;
			scl.z = 1;

			GameObject line = (GameObject)Instantiate (LinePrefab);
			line.transform.position = pos;
			line.transform.localScale = scl;
			line.transform.parent = LineBase.transform;
		}

		for (int ix = 0; ix < LineValue; ix++) {
			Vector3 pos = new Vector3 ();
			pos.x = (FieldScale.y / (float)(LineValue - 1)) * ix;
			pos.y = 0;
			pos.z = LineZ;
			Vector3 scl = new Vector3 ();
			scl.x = FieldScale.x;
			scl.y = 1;
			scl.z = 1;

			GameObject line = (GameObject)Instantiate (LinePrefab);
			line.transform.position = pos;
			line.transform.localScale = scl;
			line.transform.Rotate(0,0,90);
			line.transform.parent = LineBase.transform;
		}
	}
}
