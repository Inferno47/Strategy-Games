using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {
	}

	public void Solo () {
		SceneManager.LoadScene("StrategyGame", LoadSceneMode.Single);
	}

	public void MultiJoueur () {
		SceneManager.LoadScene("MultiplayerMenu", LoadSceneMode.Single);

	}

	public void Option () {
		SceneManager.LoadScene("OptionMenu", LoadSceneMode.Single);
	}

	public void Quiter() {
		Application.Quit();
	}
}