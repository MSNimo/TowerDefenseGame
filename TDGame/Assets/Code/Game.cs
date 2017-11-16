using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private int playerCash;
    private Cell active;
    // Use this for initialization
    void Start () {
        int STARTING_CASH = 100;
        playerCash = STARTING_CASH;
        active = null;
	}

    public void AssessCell(Cell cell) {

        active = cell;

        if (active == null)
        {
            //Destroy Current Menu Instance
        }

        else {

            if (active.IsBuilt())
            {
                //Call Upgrade Menu
            }

            else
            {
                //Call Build Menu
            }
        }
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
