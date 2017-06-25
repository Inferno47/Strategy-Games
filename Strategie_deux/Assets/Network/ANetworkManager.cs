using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ANetworkManager : MonoBehaviour
{
    protected int port = 4444;
    protected bool isServer = true;
    protected string address = "127.0.0.1";

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
}