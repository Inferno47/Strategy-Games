using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {
	}

	public void Load() {
		//Load Configuration
	}

	public void Save () {
		//Save Configuration
	}

	public void Retour () {
		SceneManager.LoadScene("MainMenu");
	}

	public void Appliquer() {
		//Application of options
		Save();
		Retour();
	}
}
