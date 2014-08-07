using UnityEngine;
using System.Collections;

public class NodeController : MonoBehaviour {

	Vector2 MyVector;
	float Speed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveNode ();
	}

	public void setVector(Vector2 vec){
		MyVector = vec;
	}

	void moveNode(){
		Vector3 vec = Vector3.zero;
		vec.x = MyVector.x;
		vec.z = MyVector.y;
		transform.position += vec * Time.deltaTime * Speed;
	}
}
