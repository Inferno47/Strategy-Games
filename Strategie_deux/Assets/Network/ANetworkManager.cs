using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MessageServer : MessageBase
{
    public string Command;
    public string info;
}


abstract public class ANetworkManager : MonoBehaviour
{
    protected int port = 4444;
    protected bool isServer = true;
    protected string address = "127.0.0.1";
    protected short msgServer = MsgType.Highest + 1;

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

    public string Address
    {
        get
        {
            return address;
        }

        set
        {
            address = value;
        }
    }

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

    abstract public void Connect();

    abstract public void Disconnect();

    public void DebugLog()
    {
        Debug.Log("Port : " + port);
        Debug.Log("Address : " + address);
        Debug.Log("Server ? " + port);
        Debug.Log("TypeMessage : " + msgServer);
    }
}