using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StrategyServerManager : ANetworkManager {

	List<NetworkPlayer> players = null;

	// Use this for initialization
	void Start () {
		players = new List<NetworkPlayer>();
	}

	// Update is called once per frame
	void Update() {
	}

	override public void Connect() {
		NetworkServer.Listen(Port);
		NetworkServer.RegisterHandler(MsgType.Connect, OnClientConnected);
		NetworkServer.RegisterHandler(MsgType.Disconnect, OnClientDisconnected);
		Debug.Log("Server Started !");
	}

	override public void Disconnect() {
		NetworkServer.Shutdown();
		Debug.Log("Server Shutdown !");
	}

	private void OnClientConnected(NetworkMessage netMsg) {
		Debug.Log("Client Connected !");
	}

	private void OnClientDisconnected(NetworkMessage netMsg) {
		Debug.Log("Client Disconnected !");
	}

	private void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log("Players " + players.Count + " connected from " + player.ipAddress + ":" + player.port);
		players.Add(player);
	}

	private void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log("Players " + players.Count + " disconnected from " + player.ipAddress + ":" + player.port);
		RemovePlayer(player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}

	public void RemovePlayer(NetworkPlayer find) {
		for (int i = 0; i < players.Count - 1; i++)
			if (players[i].Equals(find))
				players.RemoveAt(i);
	}
}
