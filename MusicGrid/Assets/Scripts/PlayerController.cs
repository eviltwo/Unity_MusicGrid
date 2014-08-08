using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	 
	public float MaxSpeed = 5.0f;
	public float LessSpeed = 1f;
	public GameObject DamageEffectPrefab;

	Vector2 Speed = Vector2.zero;
	FieldStatus fStatus;
	Joystick jStick;
	void Start () {
		fStatus = GameObject.Find ("System").gameObject.GetComponent<FieldStatus> ();
		jStick = GameObject.Find ("Joystick").gameObject.GetComponent<Joystick> ();
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
		if (Application.platform == RuntimePlatform.Android) {
			Speed.x = jStick.position.x * MaxSpeed;
			Speed.y = jStick.position.y * MaxSpeed;
		} else {
			Speed.x = Input.GetAxis ("Horizontal") * MaxSpeed;
			Speed.y = Input.GetAxis ("Vertical") * MaxSpeed;
		}

		Vector3 AddSpeed = Vector3.zero;
		AddSpeed.x += Speed.x * Time.deltaTime;
		AddSpeed.y += Speed.y * Time.deltaTime;
		transform.localPosition += AddSpeed;

		Vector3 pos = transform.localPosition;
		for (int i = 0; i < 2; i++) {
			pos[i] = Mathf.Max (0, pos[i]);
			pos[i] = Mathf.Min (fStatus.FieldScale[i], pos[i]);
		}
		transform.localPosition = pos;
	}

	void OnTriggerEnter(Collider c){
		GameObject effect = (GameObject)Instantiate(DamageEffectPrefab);
		effect.transform.localPosition = transform.localPosition;
		transform.position = new Vector3 (3.5f,3.5f,transform.localPosition.z);
	}
}
