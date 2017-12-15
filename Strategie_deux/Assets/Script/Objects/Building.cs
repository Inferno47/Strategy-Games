using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    private bool Power;
    private int Bouclier;
    private List<Order> Action;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CheckOrder(Order Action) {
        return false;
    }

    public void TakeDamage(Troop unit) {
        
    }
}
