using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private int playerCash;
	// Use this for initialization
	void Start () {
        int STARTING_CASH = 100;
        playerCash = STARTING_CASH;
	}

    public void UpdateCash(int change) {
        playerCash += change;
        CashUI cashText = FindObjectOfType<CashUI>();
        cashText.UpdateCashText(change);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
