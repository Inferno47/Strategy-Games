using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkMenuController : MonoBehaviour {

    private int Port = 4444;
    private bool IsServer = true;
    private string Address = "127.0.0.1";

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}

    public void SetPort (InputField port) {
        this.Port = int.Parse(port.text);
    }

    public void SetIp(InputField address) {
        this.Address = address.text;
    }

    public void SetIsServer(bool isServer) {
		this.IsServer = isServer;
	}

	public void Valider() {
        SceneManager.LoadScene("StrategyGame", LoadSceneMode.Single);
    }

	// Update is called once per frame
	void Update () {
		
	}
}