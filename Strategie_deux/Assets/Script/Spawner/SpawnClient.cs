using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnClient : MonoBehaviour {

    SpawnManager spawnManager;
    ManagerScene managerScene;
    List<NetworkHash128> typeIdList;
    StrategyClientManager clientManager;

    void Awake() {
        typeIdList = new List<NetworkHash128>();
        spawnManager = new SpawnManager();
        managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
        clientManager = (StrategyClientManager)managerScene.NetworkManager;
    }

    // Use this for initialization
    void Start () {
        int nb = spawnManager.ObjectPool.Count;
        ReceiveIdListFromServer(nb);
        spawnManager.SetTypeIdToObjectPool(typeIdList);
    }

    // Update is called once per frames
    void Update() {
    }

    private void ReceiveIdListFromServer(int nb) {
        for (int i = 0; i < nb; ++i) {
            typeIdList.Add(clientManager.GetReceiveMsgFromServer().ReadMessage<MessageIdObject>().TypeId);
        }
    }
}
