using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	GameController Game = null;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}

	public void Solo () {
		Game = gameObject.AddComponent<GameController>();

	}

	public void MultiJoueur ()
	{
		Game = gameObject.AddComponent<GameController>();
	}

	public void Option ()
	{
		SceneManager.LoadScene("OptionMenu", LoadSceneMode.Single);
	}

	public void Quiter()
	{
		Application.Quit();
	}
	// Update is called once per frame
	void Update () {
	}
}