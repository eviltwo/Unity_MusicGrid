using UnityEngine;
using System.Collections;

public class FieldLineCreator : MonoBehaviour {

	public GameObject LinePrefab;
	public int LineValue = 8;
	public Vector2 FieldScale = new Vector2 (7,7);
	public float LineY = 0.1f;

	// Use this for initialization
	void Start () {
		setLine ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// 線を設置
	void setLine(){
		for (int iy = 0; iy <= LineValue; iy++) {
			Vector3 pos = new Vector3 ();
			pos.x = 0;
			pos.y = LineY;
			pos.z = (FieldScale.y / (float)(LineValue - 1)) * iy;
			Vector3 scl = new Vector3 ();
			scl.x = FieldScale.x;
			scl.y = 1;
			scl.z = 1;

			GameObject line = (GameObject)Instantiate (LinePrefab);
			line.transform.position = pos;
			line.transform.localScale = scl;
		}

		for (int ix = 0; ix <= LineValue; ix++) {
			Vector3 pos = new Vector3 ();
			pos.x = (FieldScale.y / (float)(LineValue - 1)) * ix;
			pos.y = LineY;
			pos.z = 0;
			Vector3 scl = new Vector3 ();
			scl.x = FieldScale.x;
			scl.y = 1;
			scl.z = 1;

			GameObject line = (GameObject)Instantiate (LinePrefab);
			line.transform.position = pos;
			line.transform.localScale = scl;
			line.transform.Rotate(0,-90,0);
		}
	}
}
