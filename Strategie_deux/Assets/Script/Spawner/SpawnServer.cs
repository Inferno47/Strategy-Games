using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SpawnServer : NetworkBehaviour {

    SpawnManager spawnManager;
    ManagerScene managerScene;
    List<NetworkHash128> typeIdList;
    StrategyServerManager serverManager;

    void Awake() {
        typeIdList = new List<NetworkHash128>();
        spawnManager = new SpawnManager();
        managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
        serverManager = (StrategyServerManager)managerScene.NetworkManager;
    }

    // Use this for initialization
    void Start () {
        List<NetworkObject> objectPool = spawnManager.ObjectPool;

        foreach(NetworkObject obj in objectPool) {
            NetworkHash128 typeId = NetworkHash128.Parse(obj._object.name);
            typeIdList.Add(typeId);
        }

        spawnManager.SetTypeIdToObjectPool(typeIdList);
    }

    // Update is called once per frame
    void Update() {
    }

    private void SendIdListToClient() {
        foreach (NetworkHash128 typeId in typeIdList) {
            MessageIdObject msg = new MessageIdObject();
            msg.TypeId = typeId;
            msg.info = "typeId";
            serverManager.SendMsgToClient(connectionToClient.connectionId, msg); // chopper la connection client
            Debug.Log("sent " + typeId.ToString() + " typeId");
        } 
    }

    [Command]
    public void CmdObject(string objectName) {
        GameObject go = spawnManager.SpawnObject(new Vector3(0, 0, 0), objectName);
        NetworkServer.SpawnWithClientAuthority(go, spawnManager.GetTypeId(go), connectionToClient); // chopper la connection client
    }
}
