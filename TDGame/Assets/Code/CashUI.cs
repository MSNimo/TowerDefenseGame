using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashUI : MonoBehaviour {

    private Text cashText;
    private float cash;
	
	void Start () {
        
        int STARTING_CASH = 10000;
        cash = STARTING_CASH;
        cashText = GetComponent<Text>();
        cashText.text = "Cash: $" + cash; 

	}

    public void UpdateCashText(float change) {
        cash += change;
        cashText.text = "Cash: $" + cash;
    }
	
	void Update () {
		
	}
}
