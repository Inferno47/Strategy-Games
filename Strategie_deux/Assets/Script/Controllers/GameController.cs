using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameController : MonoBehaviour {

	private ANetworkManager networkManager;
	private List<PlayerController> playerCtrls;
	private ManagerScene managerScene;
	private bool Solo = false;

	public ANetworkManager NetworkManager
	{
		get
		{
			return networkManager;
		}

		set
		{
			networkManager = value;
		}
	}

	public List<PlayerController> PlayerCtrls
	{
		get
		{
			return playerCtrls;
		}

		set
		{
			playerCtrls = value;
		}
	}

	// Use this for initialization
	void Start () {
        playerCtrls = new List<PlayerController>();
		managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
		LoadNetwork();

        if (Solo == false)
        {
            LoadSpawner();
            if (!networkManager.IsServer) {
                NetworkConnection connection = ((StrategyClientManager)networkManager).GetConnection();
                Debug.Log("Ready : " + ClientScene.Ready(connection));
                Debug.Log("Add Player : " + ClientScene.AddPlayer(0));
            }
        }

        managerScene.LoadScene("PauseMenu", LoadSceneMode.Additive);
	}

	// Update is called once per frame
	void Update() {
	}

	private void LoadNetwork() {
		if (GameObject.Find("MultiplayerObject") != null)
			networkManager = managerScene.NetworkManager;
		else
			Solo = true;
	}

    private void LoadSpawner() {
        if (networkManager.IsServer) {
            SpawnServer server = gameObject.AddComponent<SpawnServer>();
        }
        else {
            SpawnClient client = gameObject.AddComponent<SpawnClient>();
            GameObject go = new GameObject();
            go.AddComponent<NetworkIdentity>();
            ClientScene.RegisterPrefab(go);
        }

    }

	public void UnloadNetwork() {
        if (Solo == false)
        {
            Debug.Log("Remove Player : " + ClientScene.RemovePlayer(0));
            networkManager.Disconnect();
        }
    }
}
