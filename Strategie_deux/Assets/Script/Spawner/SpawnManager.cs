using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class NetworkObject
{
    public NetworkHash128 Id { get; set; }

    public GameObject _object;
}

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private List<NetworkObject> objectPool = new List<NetworkObject>(1);

    public List<NetworkObject> ObjectPool { get { return objectPool; } }

    public delegate GameObject SpawnDelegate(Vector3 position, NetworkHash128 objectId);
	public delegate void UnSpawnDelegate(GameObject objectSpawned);

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update() {
    }

    public void SetTypeIdToObjectPool(List<NetworkHash128> listId) {
        for (int i = 0; i < listId.Count && i < objectPool.Count; ++i)
            objectPool[i].Id = listId[i];
    }

    public void SetSpawnHandler() {
        foreach (NetworkObject element in objectPool)
            ClientScene.RegisterSpawnHandler(element.Id, SpawnObject, UnSpawnObject);
    }

    public GameObject GetPrefab(string name) {
        return objectPool.ToArray().FirstOrDefault(tmp => tmp._object.name == name)._object;
    }

    public NetworkHash128 GetTypeId(GameObject go) {
        return objectPool.ToArray().FirstOrDefault(tmp => tmp._object == go).Id;
    }
	
	private GameObject GetFromPool (NetworkHash128 id) {
        return objectPool.ToArray().FirstOrDefault(tmp => tmp._object.GetComponent<NetworkIdentity>().Equals(id))._object;
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
