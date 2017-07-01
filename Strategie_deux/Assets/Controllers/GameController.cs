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
		managerScene.LoadScene("GameMenu", LoadSceneMode.Additive);
	}

	// Update is called once per frame
	void Update() {
	}

	private void LoadNetwork() {
		if (GameObject.Find("MultiplayerObject") != null)
			networkManager = GameObject.Find("MultiplayerObject").GetComponent<NetworkMenuController>();
		else
			Solo = true;
	}

	public void UnloadNetwork() {
		if (Solo == false)
			networkManager.Disconect();
	}
}
