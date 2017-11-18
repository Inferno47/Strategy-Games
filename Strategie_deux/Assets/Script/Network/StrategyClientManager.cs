using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StrategyClientManager : ANetworkManager {

	private NetworkClient client;

    // Use this for initialization
    void Awake () {
		client = new NetworkClient();
		client.RegisterHandler(MsgType.Connect, OnConnected);
		client.RegisterHandler(MsgType.Disconnect, OnDisconnected);
        client.RegisterHandler(msgServer, ReceiveMsgFromServer);
    }

	// Update is called once per frame
	void Update () {
	}

	override public void Connect() {
        client.Connect(address, port);
	}

	public void ConnectToNewHost() {
		client.ReconnectToNewHost(address, port);
	}

    public bool IsConnected()
    {
        return client.isConnected;
    }

    override public void Disconnect() {
		client.Disconnect();
	}

    public NetworkConnection GetConnection() {
        return client.connection;
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

	public string GetPing() {
		return client.GetRTT() + " ms";
	}

    public void SendMsgToServer(MessageBase msg) {
        client.Send(msgServer, msg);
    }

    private void ReceiveMsgFromServer(NetworkMessage netMsg) {
        listMessage.Add(netMsg);
    }

    public NetworkMessage GetReceiveMsgFromServer() {
        NetworkMessage netMsg = listMessage[0];
        listMessage.RemoveAt(0);
        return netMsg;
    }

}
