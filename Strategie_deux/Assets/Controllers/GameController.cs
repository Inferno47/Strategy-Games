using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private NetworkMenuController networkManager;
	private List<PlayerController> playerCtrls;
	private bool Solo;

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
		LoadNetwork();
	}

	// Update is called once per frame
	void Update() {
	}

	private void LoadNetwork() {
		Solo = true;
		if (GameObject.Find("MultiplayerObject"))
			networkManager = GameObject.Find("MultiplayerObject").GetComponent<NetworkMenuController>();
		else
			Solo = false;
	}

	public void MenuOption () {
		SceneManager.LoadScene("OptionMenu", LoadSceneMode.Additive);
	}

	public void Exit() {
		networkManager.Disconect();
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
}
