﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildMenuUI : MonoBehaviour {

    // Use this for initialization
    private Button buildBasicTower;
    private Cell active;
    private Game game;
    private GridManager gridManager;
    private int row;
    private int col;
    private bool CANT_PLACE_HERE_CAUSE_PATH_BLOCKED;

    private int COST_BASIC_TOWER;

	void Start () {

        game = FindObjectOfType<Game>();
        COST_BASIC_TOWER = game.GetCostBasicTower();
        gridManager = FindObjectOfType<GridManager>();
        row = active.ReturnRow();
        col = active.ReturnColumn();
        if (gridManager.WillBlockPaths(row - 1, col - 1)) CANT_PLACE_HERE_CAUSE_PATH_BLOCKED = true;
        else CANT_PLACE_HERE_CAUSE_PATH_BLOCKED = false;
    }

    public void Initialize(Cell cell) {

        active = cell;
        Button [] buttons = gameObject.GetComponentsInChildren<Button>();

        foreach (Button button in buttons) {

            if (button.tag == "BuildBasicTowerButton") buildBasicTower = button;
        }
        buildBasicTower.onClick.AddListener(buildBasicTowerHere);
    }

    public void Hide() {

        Destroy(gameObject);
    }

    void buildBasicTowerHere() {

        Object _basicTower = Resources.Load("Tower");
        GameObject _bTower = (GameObject) Object.Instantiate(_basicTower);
        _bTower.GetComponent<Tower>().Initialize(active);
        game.UpdateCash(-1 * COST_BASIC_TOWER);

        gridManager.Deactive(active.gameObject);
        gridManager.RecordTowerPlacement(row, col);
        active.SetAssociatedTower(_bTower.GetComponent<Tower>());
        active.togglebuild();

        Hide();
    }

    // Update is called once per frame
    void Update () {

        float cash = game.GetCash();

        if (cash - COST_BASIC_TOWER < -0.05) {
            buildBasicTower.interactable = false;
        }

        else if (CANT_PLACE_HERE_CAUSE_PATH_BLOCKED) buildBasicTower.interactable = false; 

        else if (active.EnemyAbove()) buildBasicTower.interactable = false; 

        else buildBasicTower.interactable = true;

    }
}
