using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Cell active;

    void Start()
    {

    }

    void Update() {

        if (Input.GetMouseButtonDown(0)){
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log(ray);

            if (Physics.Raycast(ray, out hit, 100)) {  
                
                if (hit.collider.tag == "Cell") {

                    GameObject go = hit.collider.gameObject;
                    active = go.GetComponent<Cell>();
                    Debug.Log(active.ReturnRow() + ", " + active.ReturnColumn());
                }
            }  
        }
    }
}
