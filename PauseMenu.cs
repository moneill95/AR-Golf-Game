﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	public GameObject pauseMenuCanvas;
	public string settings;
	public string exit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isPaused) {

			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f; // stops game being played when pause menu canvas is activated

		} else {

			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}


	}

	public void Resume() //resumes game
	{
		Debug.Log ("Resume Pressed");
		isPaused = false;

	}


	public void Settings() // goes to help screen
	{
		Debug.Log ("Settings Pressed");
		SceneManager.LoadScene (settings);

	}

	public void Exit() // exits to main menu
	{
		Debug.Log ("Exit Pressed");
		SceneManager.LoadScene (exit);


	}

	public void Pause() // pauses game
	{

		isPaused = true;
		Debug.Log ("Paused Pressed");

	}
}
