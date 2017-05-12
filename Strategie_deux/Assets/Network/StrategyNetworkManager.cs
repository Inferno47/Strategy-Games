using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyNetworkManager : MonoBehaviour {
    StrategyServerManager server = null;
    StrategyClientManager client = null;
    bool isServer = false;
        
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

    public void setUpNetworkManager()
    {
        if (isServer)
        {
            server = new StrategyServerManager();
            server.connect();
        }
        else
        {
            Debug.Log("Starting up as a client");
            client = new StrategyClientManager();
            client.Ip = "127.0.0.1";
            client.Port = 4444;
            client.connection();
        }
    }	
	// Update is called once per frame
	void Update () {
		
	}
}
