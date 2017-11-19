using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    private Vector3 position;
    private int row;
    private int column;
    private int diagonal;
    private bool built;
    private Tower tower;

    void Start () {

        position = transform.position;
        row = (int) position[2] / 8 + 3;
        column = (int) position[0] / 8 + 3;
        diagonal = (int) -1 * (row - column) + 4;
        built = false;
        tower = null;
    }

    public Vector3 ReturnPosition () {

        return position;
    }

    public int ReturnRow () {

        return row;
    }

    public int ReturnColumn () {

        return column;
    }

    public int ReturnDiagonal()
    {

        return diagonal;
    }

    public bool IsBuilt () {

        return built;
    }

    public void togglebuild() {

        if (built) built = false;
        else built = true;
    }

    public void SetAssociatedTower(Tower _tower) {

        tower = _tower;
    }

    public Tower GetTower() {

        return tower;
   }
    void Update () {
       
    }
}