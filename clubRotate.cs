﻿using UnityEngine;
using System.Collections;

public class clubRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("a")) {
			transform.Rotate (0, 1, 0);
		}

		if (Input.GetKey ("d")) {
			transform.Rotate (0, -1, 0);
		}
	
	}
}
