﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {

	private ManagerScene managerScene;

	// Use this for initialization
	void Start () {
		managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Play() {
	}

	public void Save() {
	}

	public void Settings() {
		managerScene.LoadScene("SettingsMenu", LoadSceneMode.Additive);
	}

	public void Quit() {
		managerScene.LoadScene("MainMenu", LoadSceneMode.Additive);
	}
}