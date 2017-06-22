using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	StrategyNetworkManager networkManager;
	List<PlayerController> playerCtrls;

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

	// Use this for initialization
	void Start () {
		networkManager = gameObject.AddComponent<StrategyNetworkManager>();
		playerCtrls = new List<PlayerController>();
	}
	public void beginExecution()
	{
		networkManager.setUpNetworkManager();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
