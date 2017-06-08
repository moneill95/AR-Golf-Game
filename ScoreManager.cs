using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int Stroke;
	Text text;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

		Stroke = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Stroke < 0)
			Stroke = 0;

		text.text = " " + Stroke;
	
	}

	public static void AddStroke(int StrokeNo)// adds a stroke every time shoot button is pressed
	{
		Stroke += StrokeNo; 
	}
}
