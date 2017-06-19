using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class StrategyServerManager : MonoBehaviour {
	int port = 4444;
	
	public int Port
	{
		get
		{
			return port;
		}

		set
		{
			port = value;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	public void connect()
	{
		NetworkServer.Listen(Port);
		NetworkServer.RegisterHandler(MsgType.Connect, OnClientConnected);
		Debug.Log("Server started");
	}
	public void disconnect()
	{
		NetworkServer.DisconnectAll();
	}
	void OnClientConnected(NetworkMessage netMsg)
	{
		Debug.Log("Client connected");
		Debug.Log("...");
	}
	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Debug.Log("OnPlayerDisconnected() was called here on " + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}
	void Update () {
		
	}
}
