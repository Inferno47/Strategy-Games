using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkMenuController : MonoBehaviour {

	private ANetworkManager Manager = null;
	private ManagerScene managerScene = null;

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
	void Update () {
	}

	public void SetPort (InputField port) {
		if (port.text != "")
			Port = int.Parse(port.text);
	}

	public void SetIp (InputField address) {
		if (address.text != "")
			Address = address.text;
	}

	public void Valider () {
		Debug.Log("Starting up !");
        StartCoroutine(SetUpNetworkManager());
	}
	
	public void Return () {
		managerScene.LoadScene("MainMenu", LoadSceneMode.Additive);
		Destroy(this.gameObject);
	}

	public IEnumerator SetUpNetworkManager () {
		if (isServer)
			Manager = gameObject.AddComponent<StrategyServerManager>();
		else
			Manager = gameObject.AddComponent<StrategyClientManager>();
		Manager.Address = Address;
		Manager.Port = Port;
		Manager.Connect();
        managerScene.NetworkManager = Manager;
        Manager.IsServer = isServer;
        if (!isServer)
            yield return new WaitForConnected((StrategyClientManager)Manager);
        managerScene.LoadScene("StrategyGame", LoadSceneMode.Additive);
    }

	public void Disconect () {
		Manager.Disconnect();
		Destroy(this.gameObject);
	}
}

public class WaitForConnected : CustomYieldInstruction
{
    private StrategyClientManager Manager;

    public override bool keepWaiting
    {
        get
        {
            return !Manager.IsConnected();
        }
    }

    public WaitForConnected(StrategyClientManager manager)
    {
        Manager = manager;
        Debug.Log("Waiting Connection!");
    }
}