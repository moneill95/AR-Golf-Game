using UnityEngine;
using System.Collections;

public class Putter : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<ConstantForce> ().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space")) {
			Debug.Log ("HIT");
			GetComponent<ConstantForce> ().enabled = true;
		}
	
	}

/*	void OnCollisionEnter(Collision other)
	{

		Destroy (gameObject);
	}*/
}
