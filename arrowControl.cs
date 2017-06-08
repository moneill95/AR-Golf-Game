using UnityEngine;
using System.Collections;

public class arrowControl : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a")) {
			transform.Rotate (0, 0, 1);
		}

		if (Input.GetKey ("d")) {
			transform.Rotate (0, 0, -1);
		}

		if (Input.GetKeyDown ("r")) {
			Debug.Log ("Respawn Putter");
			GetComponent<Transform>().eulerAngles  = new Vector3 (270,0,0);
			//GetComponent<Transform>().eulerAngles  = new Vector3 (270,0,0);

		}
	
	}
}
