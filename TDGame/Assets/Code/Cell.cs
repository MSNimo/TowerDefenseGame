using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    private Vector3 position;
    private int row;
    private int column;
    private bool built;

    void Start () {

        position = transform.position;
        row = (int) position[2] / 8 + 3;
        column = (int) position[0] / 8 + 3;
        built = false;
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

    public bool IsBuilt () {

        return built;
    }

    void Update () {
       
    }
}