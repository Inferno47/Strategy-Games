using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	StrategyNetworkManager networkManager;
	List<PlayerController> playerCtrls;
	public bool isServer = true;

	public StrategyNetworkManager NetworkManager
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
	public void setIsServer(bool isServer)
	{
		this.isServer = isServer;
	}

	// Use this for initialization
	void Start () {
		networkManager = gameObject.AddComponent<StrategyNetworkManager>();
		playerCtrls = new List<PlayerController>();
	}
	public void beginExecution()
	{
		networkManager.IsServer = isServer;
		networkManager.setUpNetworkManager();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
