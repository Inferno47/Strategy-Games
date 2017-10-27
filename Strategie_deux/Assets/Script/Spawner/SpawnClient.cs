using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnClient : MonoBehaviour {

    List<NetworkHash128> typeIdList;
    SpawnManager spawnManager;
    StrategyClientManager clientManager;

    // Use this for initialization
    void Start () {
        typeIdList = new List<NetworkHash128>();
        ManagerScene managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
        clientManager = (StrategyClientManager)managerScene.NetworkManager;
        spawnManager = new SpawnManager();
        int nb = spawnManager.ObjectPool.Count;
        ReceiveIdListFromServer(nb);
        spawnManager.SetTypeIdToObjectPool(typeIdList);
    }

    // Update is called once per frames
    void Update() {
    }

    private void ReceiveIdListFromServer(int nb) {
        for (int i = 0; i < nb; ++i) {
            typeIdList.Add(clientManager.GetReceiveMsgFromServer().ReadMessage<MessageIdObject>().Command);
        }
    }
}
