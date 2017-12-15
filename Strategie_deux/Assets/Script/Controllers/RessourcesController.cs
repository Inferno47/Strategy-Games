using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class RessourcesController : MonoBehaviour {

    private int Energy;
    private int Metal;
    private int Cristal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddRessources(int TypeRessources, int Quantity) {
        
    }

    public void RemoveRessources(int TypeRessources, int Quantity) {

    }

    public bool CheckOrder(Order Action) {
        return false;
    }
}
