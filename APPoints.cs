using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class APPoints : MonoBehaviour {

	public static int APPoint; // no. of points player has to set obstacles
	Text text;


	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();

		APPoint = 7;

	}

	// Update is called once per frame
	void Update () {

		if (APPoint < 0)
			APPoint = 0;

		text.text = " " + APPoint;

	}

	public static void DeductAPPoints(int NoAPPoints) // called in ChangeObject script to deducts points when ar card is recogise
	{
		APPoint -= NoAPPoints;
	}
}
