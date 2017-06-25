using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private NetworkMenuController networkManager;
	private List<PlayerController> playerCtrls;

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
		networkManager = GameObject.Find("MultiplayerObject").GetComponent<NetworkMenuController>();
		playerCtrls = new List<PlayerController>();
	}

	// Update is called once per frame
	void Update() {
	}

	public void beginExecution() {
		networkManager.Disconect();
	}
}
