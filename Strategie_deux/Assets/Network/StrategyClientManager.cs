using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StrategyClientManager : ANetworkManager {

	private NetworkClient client;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	override public void Connect() {
		client = new NetworkClient();
		client.RegisterHandler(MsgType.Connect, OnConnected);
		client.RegisterHandler(MsgType.Disconnect, OnDisconnected);
		client.Connect(address, port);
	}

	override public void Disconnect() {
		client.Disconnect();
	}

	private void OnConnected(NetworkMessage netMsg) {
		Debug.Log("Connected Successful !");
	}

	private void OnDisconnected(NetworkMessage netMsg) {
		Debug.Log("Disconnected Successful !");
	}

	public void OnConnectedToServer() {
		Debug.Log("Connected to server");
	}

	public void OnDisconnectedFromServer(NetworkDisconnection info) {
		Debug.Log("Disconnected from server: " + info);
	}
}
