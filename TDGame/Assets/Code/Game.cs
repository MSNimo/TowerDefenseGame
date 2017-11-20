using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    private float playerCash;
    private Cell active;
    private Object _bmenu;
    private Object _umenu;
    private Canvas canvas;

    private int COST_OF_BASIC_TOWER;

    // Use this for initialization

    void Start () {
        int STARTING_CASH = 10000;
        playerCash = STARTING_CASH;
        active = null;
        _bmenu = Resources.Load("BuildMenu");
        _umenu = Resources.Load("UpgradeMenu");
        canvas = FindObjectOfType<Canvas>();

        COST_OF_BASIC_TOWER = 50;
    }

    public void AssessCell(Cell cell) {

        active = cell;

        BuildMenuUI tempbUI = FindObjectOfType<BuildMenuUI>();
        UpgradeMenuUI tempuUI = FindObjectOfType<UpgradeMenuUI>();

        if (tempbUI != null) tempbUI.Hide();
        if (tempuUI != null) tempuUI.Hide();

        if (active == null) {
            //Destroy Current Menu Instance
            Debug.Log("null");
        }

        else {

            Debug.Log(active.ReturnRow() + ", " + active.ReturnColumn() + ", " + active.ReturnDiagonal());

            if (active.IsBuilt()) {
                //Call Upgrade Menu
                GameObject upgradeMenu = (GameObject)Object.Instantiate(_umenu);
                upgradeMenu.transform.SetParent(canvas.transform, false);
                upgradeMenu.GetComponent<UpgradeMenuUI>().Initialize(active);

            }

            else {
                //Call Build Menu
                GameObject buildMenu = (GameObject)Object.Instantiate(_bmenu);
                buildMenu.transform.SetParent(canvas.transform, false);
                buildMenu.GetComponent<BuildMenuUI>().Initialize(active);
                active = null;
            }
        }
    }

    public void UpdateCash(float change) {
        playerCash += change;
        CashUI cashText = FindObjectOfType<CashUI>();
        cashText.UpdateCashText(change);
    }

    public float GetCash() {
        return playerCash;
    }

    public int GetCostBasicTower() {
        return COST_OF_BASIC_TOWER;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
