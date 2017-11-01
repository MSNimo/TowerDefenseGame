using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {

    private Vector3 position;
    private int row;
    private int column;
    private bool built = false;

	// Use this for initialization
	void Start () {
        position = transform.position;
        row = (int) position[2] / 8 + 2;
        column = (int) position[0] / 8 + 2;
        Debug.Log(row + " "+ column);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
