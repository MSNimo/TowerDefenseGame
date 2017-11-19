using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeMenuUI : MonoBehaviour {

    private Button sellBasicTower;
    private Cell active;
    private Game game;

    private float SELL_BASIC_TOWER;

    // Use this for initialization
    void Start () {

        game = FindObjectOfType<Game>();
        SELL_BASIC_TOWER = game.GetCostBasicTower() * 0.9f;
	}

    public void Initialize(Cell cell) {

        active = cell;
        Button[] buttons = gameObject.GetComponentsInChildren<Button>();

        foreach (Button button in buttons)
        {

            if (button.tag == "SellBasicTowerButton") sellBasicTower = button;
        }
        sellBasicTower.onClick.AddListener(sellBasicTowerHere);
    }

    public void Hide() {

        Destroy(gameObject);
    }

    void sellBasicTowerHere () {

        game.UpdateCash(SELL_BASIC_TOWER);
        active.GetTower().Sell();
        active.SetAssociatedTower(null);
        active.togglebuild();

        GridManager gridManager = FindObjectOfType<GridManager>();
        gridManager.Deactive(active.gameObject);

        Hide();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
