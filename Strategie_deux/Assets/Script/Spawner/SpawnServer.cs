using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SpawnServer : NetworkBehaviour {

    List<NetworkHash128> typeIdList;
    SpawnManager spawnManager;
    StrategyServerManager serverManager;

	// Use this for initialization
	void Start () {
        typeIdList = new List<NetworkHash128>();
        spawnManager = new SpawnManager();
        ManagerScene managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
        serverManager = (StrategyServerManager)managerScene.NetworkManager;
        List<NetworkObject> objectPool = spawnManager.ObjectPool;
        NetworkHash128 typeId;
        foreach(NetworkObject obj in objectPool) {
            typeId = NetworkHash128.Parse(obj._object.name);
            typeIdList.Add(typeId);
        }
        spawnManager.SetTypeIdToObjectPool(typeIdList);
        SendIdListToClient();
    }

    // Update is called once per frame
    void Update() {
    }

    private void SendIdListToClient() {
        foreach (NetworkHash128 typeId in typeIdList) {
            MessageIdObject msg = new MessageIdObject();
            msg.Command = typeId;
            msg.info = "typeId";
            serverManager.SendMsgToClient(connectionToClient.connectionId, msg);
            Debug.Log("sent " + typeId.ToString() + " typeId");
        }
    }

    [Command]
    public void CmdObject(string objectName) {
        GameObject go = spawnManager.SpawnObject(new Vector3(0, 0, 0), objectName);
        NetworkServer.SpawnWithClientAuthority(go, spawnManager.GetTypeId(go), connectionToClient); // chopper la conn<
    }
}
