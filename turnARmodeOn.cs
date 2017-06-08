using UnityEngine;
using System.Collections;
using Vuforia;

public class turnARmodeOn : MonoBehaviour {

	public GameObject ARCamera;
	public GameObject mainCamera;
	public static int isARon;

	// Use this for initialization
	void Start () {

		ARCamera.SetActive (false);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void turnARModeOn()
	{
		
		ARCamera.SetActive (true);
		mainCamera.SetActive (true);
		Debug.Log ("TurnARON");
		isARon = 1;

	}
}
