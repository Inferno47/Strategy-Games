using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
	private ManagerScene managerScene;

	// Use this for initialization
	void Start () {
		managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
	}

	// Update is called once per frame
	void Update() {
	}

	public void Single () {
		managerScene.LoadScene("StrategyGame", LoadSceneMode.Additive);
	}

	public void MultiPlayer () {
		managerScene.LoadScene("MultiplayerMenu", LoadSceneMode.Additive);
	}

	public void Settings () {
		managerScene.LoadScene("SettingsMenu", LoadSceneMode.Additive);
	}

	public void Quit() {
		Application.Quit();
	}
}