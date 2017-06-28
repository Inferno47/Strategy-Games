using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkMenuController : MonoBehaviour {

	private ANetworkManager Manager = null;
    private ManagerScene managerScene;

    private int Port = 4444;
	private bool isServer = true;
	private string Address = "127.0.0.1";

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
		DontDestroyOnLoad(this);
	    managerScene = (ManagerScene)GameObject.FindObjectOfType(typeof(ManagerScene));
    }

	// Update is called once per frame
	void Update() {
	}

	public void SetPort (InputField port) {
		Port = int.Parse(port.text);
	}

	public void SetIp(InputField address) {
		Address = address.text;
	}

	public void Valider() {
		Debug.Log("Starting up !");
		SetUpNetworkManager();
	    managerScene.LoadScene("StrategyGame", LoadSceneMode.Additive);
    }

	public void SetUpNetworkManager() {
		if (isServer)
			Manager = gameObject.AddComponent<StrategyServerManager>();
		else
			Manager = gameObject.AddComponent<StrategyClientManager>();
		Manager.Address = Address;
		Manager.Port = Port;
		Manager.Connect();
	}

	public void Disconect() {
		Manager.Disconnect();
	}
}