﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTextRestart : MonoBehaviour {
	public string nameOfSceneToLoad;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown("joystick button 7") ){
			SceneManager.LoadScene(nameOfSceneToLoad);
		}
	}
}
