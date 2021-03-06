﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float MoveMultiple = 1.0f;
	public float RotMultiple = 0.1f;

	GameObject Player;
	GameObject Camera;
	FieldStatus fStatus;
	// Use this for initialization
	void Start () {
		fStatus = GameObject.Find("System").GetComponent<FieldStatus> ();
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		moveCamera ();
	}

	void moveCamera(){
		Vector2 center = fStatus.FieldScale / 2;
		Vector2 pp = Vector2.zero;
		pp.x = Player.transform.position.x;
		pp.y = Player.transform.position.y;
		Vector3 pos = transform.position;
		pos.x = center.x+(pp.x-center.x)*MoveMultiple;
		pos.y = center.y+(pp.y-center.y)*MoveMultiple;
		transform.position = pos;

		Vector3 rot = Vector3.zero;
		rot.x = (pp.y - center.y) * RotMultiple;
		rot.y = -(pp.x - center.x) * RotMultiple;
		transform.localEulerAngles = rot;
	}
}
