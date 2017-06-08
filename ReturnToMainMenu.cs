using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour {

	public string MainMenu;
	public string shop;
	public string settings;


	public void Exit() // exits to maim menu
	{
		Debug.Log ("Exit Pressed");
		SceneManager.LoadScene (MainMenu);


	}

	public void Shop() // enters shop
	{ 

		Debug.Log ("Settings Pressed");
		SceneManager.LoadScene (shop);


	}

	public void Settings() // enters help screen
	{
		Debug.Log ("Settings Pressed");
		SceneManager.LoadScene (settings);

	}
}
