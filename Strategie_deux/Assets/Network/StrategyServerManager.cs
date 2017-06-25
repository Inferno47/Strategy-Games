using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StrategyServerManager : ANetworkManager {

	// Use this for initialization
	void Start () {
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

	/*public void OnPlayerConnected(NetworkPlayer player) {
		Debug.Log("Client Connected !");
		Debug.Log("Player " + playerCount + " connected from " + player.ipAddress + ":" + player.port);
	}*/

	/*public void OnPlayerDisconnected(NetworkPlayer player) {
		Debug.Log("OnPlayerDisconnected() was called here on " + player);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}*/
}
