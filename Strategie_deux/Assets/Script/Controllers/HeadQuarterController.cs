using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadQuarterController : MonoBehaviour {

    private ArmyController Army;
    private BaseController Base;
    private RessourcesController Ressources;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CheckOrder(Order Action) {
        return false;
    }
}
