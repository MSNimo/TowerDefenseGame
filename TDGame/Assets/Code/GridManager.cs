using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Cell active;

    private Color green;
    private Color mint;

    void Start() {

        green = new Color(3f/255, 135f/255, 15f/255, 1f);
        mint = new Color(137f/255, 246f/255, 147f/255, 1f);
    }

    private void SetActiveCell(GameObject go) {

        if (active != go.GetComponent<Cell>()) {

            if (active != null) {

                GameObject ogGo = active.gameObject;
                //Debug.Log(active.ReturnRow() + ", " + active.ReturnColumn() + ", " + active.ReturnDiagonal());
                SpriteRenderer ogSpriteRenderer = ogGo.GetComponentInChildren<SpriteRenderer>();

                if (active.ReturnDiagonal() % 2 == 1) {

                    ogSpriteRenderer.color = mint;
                }
                else ogSpriteRenderer.color = green;
            }

            active = go.GetComponent<Cell>();
            SpriteRenderer spriteRenderer = go.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.color = Color.yellow;
        }

        else {

            SpriteRenderer spriteRenderer = go.GetComponentInChildren<SpriteRenderer>();

            if (active.ReturnDiagonal() % 2 == 1) spriteRenderer.color = mint;
            else spriteRenderer.color = green;

            active = null;
        }

        Game game = FindObjectOfType<Game>();
        game.AssessCell(active);
    }

    void Update() {

        if (Input.GetMouseButtonDown(0)){
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100)) {  
                
                if (hit.collider.tag == "Cell") {

                    GameObject go = hit.collider.gameObject;
                    SetActiveCell(go);
                }
            }  
        }
    }
}
