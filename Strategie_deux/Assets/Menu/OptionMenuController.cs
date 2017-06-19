using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void Load() {
	}

	public void Save () {

	}

	public void Annuler () {
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}

	public void Valider()
	{
		//Save Config
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
