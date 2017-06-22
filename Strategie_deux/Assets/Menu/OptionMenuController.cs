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
        //Save Config
    }

    public void Annuler () {
		SceneManager.LoadScene("MainMenu");
	}

	public void Valider()
	{
        Save();
		SceneManager.LoadScene("MainMenu");
	}
	// Update is called once per frame
	void Update () {
		
	}
}
