using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class StrategyClientManager : MonoBehaviour {
    NetworkClient client;
    int port = 4444;
    string ip;

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

    public string Ip
    {
        get
        {
            return ip;
        }

        set
        {
            ip = value;
        }
    }


    // Use this for initialization
    void Start () {
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void connection()
    {
        client = new NetworkClient();
        client.RegisterHandler(MsgType.Connect, OnConnected);
        Debug.Log("Initialization");
        client.Connect(ip, port);
    }
    public void disconnect()
    {
        client.Disconnect();
    }
    private void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("connection successful");
    }
}
