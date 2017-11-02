using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    // Use this for initialization

    private Cell active;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(ray);
            
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Cell") {
                    GameObject go = hit.collider.gameObject;
                    active = go.GetComponent<Cell>();
                    Debug.Log(active.ReturnRow() + ", " + active.ReturnColumn());

                }
            }
        }
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Pressed left click, casting ray.");
        //    CastRay();
        //}

    }
}
