using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpawnManager : MonoBehaviour {

	private List<GameObject> objectPool;

	public NetworkHash128 objectId;

	public delegate GameObject SpawnDelegate(Vector3 position, NetworkHash128 objectId);
	public delegate void UnSpawnDelegate(GameObject objectSpawned);

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public GameObject SpawnObject(Vector3 position, NetworkHash128 assetId)
	{
		return gameObject;
	}

	public void UnSpawnObject(GameObject spawned)
	{
		Debug.Log("Re-pooling object " + spawned.name);
		spawned.SetActive(false);
	}
}
