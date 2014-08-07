using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float MaxSpeed = 5.0f;
	public float LessSpeed = 1f;

	Vector2 Speed = Vector2.zero;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}


	void Move(){
		for (int i = 0; i < 2; i++) {
			if (Speed [i] > 0) {
				Speed [i] = Mathf.Max (0, Speed [i] - LessSpeed * Time.deltaTime);
			} else {
				Speed [i] = Mathf.Min (0, Speed [i] + LessSpeed * Time.deltaTime);
			}
		}
		Speed.x = Input.GetAxis ("Horizontal") * MaxSpeed;
		Speed.y = Input.GetAxis ("Vertical") * MaxSpeed;

		Vector3 AddSpeed = Vector3.zero;
		AddSpeed.x += Speed.x * Time.deltaTime;
		AddSpeed.z += Speed.y * Time.deltaTime;
		transform.position += AddSpeed;
	}

	void OnTriggerEnter(Collider c){
		transform.position = new Vector3 (3.5f,transform.position.y,3.5f);
	}
}
