using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyNetworkManager : MonoBehaviour {

	private StrategyServerManager server = null;
	private StrategyClientManager client = null;
	private bool isServer = true;
		
	public bool IsServer
	{
		get
		{
			return isServer;
		}

		set
		{
			isServer = value;
		}
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {
	}

	public void setUpNetworkManager() {
		if (isServer)
		{
			Debug.Log("Starting up as a Server !");
			server = gameObject.AddComponent<StrategyServerManager>();
			server.Port = 4444;
			server.Connect();
		}
		else
		{
			Debug.Log("Starting up as a client !");
			client = new StrategyClientManager();
			client.Address = "127.0.0.1";
			client.Port = 4444;
			client.Connect();
		}
	}

	public void Disconect() {
		if (isServer)
			server.Disconnect();
		else
			client.Disconnect();
	}
}
