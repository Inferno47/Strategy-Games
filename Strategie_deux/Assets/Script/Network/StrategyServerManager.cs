using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class StrategyServerManager : ANetworkManager
{
    private GameObject player;

    // Use this for initialization
    void Awake () {
    }

    // Update is called once per frame
    void Update() {
    }

    override public void Connect() {
        NetworkServer.Listen(Port);
        NetworkServer.RegisterHandler(MsgType.Connect, OnClientConnected);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnClientDisconnected);
        NetworkServer.RegisterHandler(MsgType.AddPlayer, AddPlayer);
        NetworkServer.RegisterHandler(MsgType.RemovePlayer, RemovePlayer);
        NetworkServer.RegisterHandler(MsgType.Ready, OnClientReady);
        NetworkServer.RegisterHandler(MsgType.NotReady, OnClientNotReady);
        NetworkServer.RegisterHandler(msgServer, ReceiveMsgFromClient);

        player = Resources.Load("PlayerControlleur") as GameObject;
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

    private void OnClientReady(NetworkMessage netMsg) {
        Debug.Log("Client Ready !");
        NetworkServer.SetClientReady(netMsg.conn);
    }

    private void OnClientNotReady(NetworkMessage netMsg) {
        Debug.Log("Client Not Ready !");
        NetworkServer.SetClientNotReady(netMsg.conn);
    }

    private void AddPlayer(NetworkMessage netMsg) {
        Debug.Log("New Player !");
        NetworkServer.AddPlayerForConnection(netMsg.conn, player, 1);
    }

    private void RemovePlayer(NetworkMessage netMsg) {
        Debug.Log("Remove Player !");
        NetworkServer.DestroyPlayersForConnection(netMsg.conn);
    }

    public void SendMsgToClient(int client, MessageBase msg) {
        NetworkServer.SendToClient(client, msgServer, msg);
    }

    public void SendMsgToAllClient(MessageBase msg) {
        NetworkServer.SendToAll(msgServer, msg);
    }

    public void ReceiveMsgFromClient(NetworkMessage netMsg) {
        listMessage.Add(netMsg);
    }

    public NetworkMessage GetReceiveMsgFromClient()
    {
        NetworkMessage netMsg = listMessage[0];
        listMessage.RemoveAt(0);
        return netMsg;
    }
}
