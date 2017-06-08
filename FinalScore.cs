using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public static int StrokeCount;
	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();



	}

	// Update is called once per frame
	void Update () { // displays final stroke count after nine holes are completed

		if (StrokeCount < 0)
			StrokeCount = 0;

		text.text = "Final Score = " + StrokeCount;

	}


}
