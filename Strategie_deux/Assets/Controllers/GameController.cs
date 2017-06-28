using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private NetworkMenuController networkManager;
	private List<PlayerController> playerCtrls;
    private ManagerScene managerScene;
    private bool Solo = false;

	public NetworkMenuController NetworkManager
	{
		get
		{
			return networkManager;
		}

		set
		{
			networkManager = value;
		}
	}

	public List<PlayerController> PlayerCtrls
	{
		get
		{
			return playerCtrls;
		}

		set
		{
			playerCtrls = value;
		}
	}

	// Use this for initialization
	void Start () {
		playerCtrls = new List<PlayerController>();
	    managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
	    LoadNetwork();
	    MenuOption();
	}

	// Update is called once per frame
	void Update() {
	    Exit();
    }

	private void LoadNetwork() {
		Solo = true;
		if (GameObject.Find("MultiplayerObject") != null)
			networkManager = GameObject.Find("MultiplayerObject").GetComponent<NetworkMenuController>();
		else
			Solo = false;
	}

	public void MenuOption () {
	    managerScene.LoadScene("OptionMenu", LoadSceneMode.Additive);
    }

	public void Exit() {
        if (Solo == true)
		    networkManager.Disconect();
        managerScene.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}
