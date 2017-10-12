using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
	private List<Pair<GameObject, NetworkHash128>> objectPool;

    public delegate GameObject SpawnDelegate(Vector3 position, NetworkHash128 objectId);
	public delegate void UnSpawnDelegate(GameObject objectSpawned);

    public List<Pair<GameObject, NetworkHash128>> ObjectPool { get { return objectPool; } }

    // Use this for initialization
    void Start () {
    }

    public void SetTypeIdToObjectPool(List<NetworkHash128> listId) {
        for (int i = 0; i < listId.Count && i < ObjectPool.Count; ++i)
            ObjectPool[i].Second = listId[i];
    }

    public void SetSpawnHandler() {
        foreach (Pair<GameObject, NetworkHash128> element in ObjectPool)
            ClientScene.RegisterSpawnHandler(element.Second, SpawnObject, UnSpawnObject);
    }

    public GameObject GetPrefab(string name) {
        return ObjectPool.ToArray().FirstOrDefault(tmp => tmp.First.name == name).First;
    }

    public NetworkHash128 GetTypeId(GameObject go) {
        return ObjectPool.ToArray().FirstOrDefault(tmp => tmp.First == go).Second;
    }
	
	private GameObject GetFromPool (NetworkHash128 id) {
        return ObjectPool.ToArray().FirstOrDefault(tmp => tmp.First.GetComponent<NetworkIdentity>().Equals(id)).First;
	}

	public GameObject SpawnObject(Vector3 position, NetworkHash128 typeId) {
        return Instantiate(GetFromPool(typeId), position, Quaternion.identity);
	}

    public GameObject SpawnObject(Vector3 position, string name) {
        return SpawnObject(position, GetTypeId(GetPrefab(name)));
    }

    public void UnSpawnObject(GameObject spawned) {
		Debug.Log("Re-pooling object " + spawned.name);
		spawned.SetActive(false);
	}
}
