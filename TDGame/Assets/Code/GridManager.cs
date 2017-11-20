using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    private Cell active;

    private Color green;
    private Color mint;

    private bool [][] towers;
    private bool [][] visited;
    int leftwall;
    int rightwall;
    int upwall;
    int downwall;

    void Start() {

        green = new Color(3f/255, 135f/255, 15f/255, 1f);
        mint = new Color(137f/255, 246f/255, 147f/255, 1f);

        towers = new bool[5][];
        towers[0] = new bool[5];
        towers[1] = new bool[5];
        towers[2] = new bool[5];
        towers[3] = new bool[5];
        towers[4] = new bool[5];

        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                towers[i][j] = false;
            }
        }

        visited = new bool[5][];
        visited[0] = new bool[5];
        visited[1] = new bool[5];
        visited[2] = new bool[5];
        visited[3] = new bool[5];
        visited[4] = new bool[5];

        leftwall = rightwall = upwall = downwall = 0;
    }

    private void SetActiveCell(GameObject go) {

        if (active != go.GetComponent<Cell>()) {

            if (active != null) {

                GameObject ogGo = active.gameObject;
               
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

        if (Input.GetMouseButtonDown(0)) {
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit [] hits = Physics.RaycastAll(ray);

            foreach (RaycastHit hit in hits) {

                if (hit.collider.tag == "Cell") {
                  
                    GameObject go = hit.collider.gameObject;
                    SetActiveCell(go);
                    break;
                }
            }
        }
    }

    public void RecordTowerPlacement (int row, int col) {

        towers[row-1][col-1] = true;
    }

    public void RecordTowerRomoval (int row, int col) {

        towers[row-1][col-1] = false;
    }

    public void RecursiveMap(int row, int col) {

        if (row == 0) leftwall = 1;
        if (row == 4) rightwall = 1;
        if (col == 0) upwall = 1;
        if (col == 4) downwall = 1;

        Debug.Log("Row: " + row);
        Debug.Log("Col: " + col);

        if (visited[row][col] == false) {
            visited[row][col] = true;

            if (row == 0 && col == 0)
            {
                if (towers[row+1][col]) RecursiveMap(row+1, col);
                if (towers[row][col+1]) RecursiveMap(row, col+1);
                if (towers[row+1][col+1]) RecursiveMap(row+1, col+1);
            }

            else if (row == 4 && col == 4)
            {
                if (towers[row-1][col]) RecursiveMap(row-1, col);
                if (towers[row][col-1]) RecursiveMap(row, col-1);
                if (towers[row-1][col-1]) RecursiveMap(row-1, col-1);
            }

            else if (row == 4)
            {
                if (towers[row-1][col]) RecursiveMap(row-1, col);
                if (towers[row][col-1]) RecursiveMap(row, col-1);
                if (towers[row-1][col-1]) RecursiveMap(row-1, col-1);
                if (towers[row][col+1]) RecursiveMap(row, col+1);
                if (towers[row-1][col+1]) RecursiveMap(row-1, col+1);
            }

            else if (row == 0)
            {
                if (towers[row+1][col]) RecursiveMap(row+1, col);
                if (towers[row][col-1]) RecursiveMap(row, col-1);
                if (towers[row+1][col-1]) RecursiveMap(row+1, col-1);
                if (towers[row][col+1]) RecursiveMap(row, col+1);
                if (towers[row+1][col+1]) RecursiveMap(row+1, col+1);
            }

            else if (col == 4)
            {
                if (towers[row+1][col]) RecursiveMap(row+1, col);
                if (towers[row][col-1]) RecursiveMap(row, col-1);
                if (towers[row+1][col-1]) RecursiveMap(row+1, col-1);
                if (towers[row-1][col-1]) RecursiveMap(row-1, col-1);
                if (towers[row-1][col]) RecursiveMap(row-1, col);
            }

            else if (col == 0)
            {
                if (towers[row+1][col]) RecursiveMap(row+1, col);
                if (towers[row][col+1]) RecursiveMap(row, col+1);
                if (towers[row+1][col+1]) RecursiveMap(row+1, col+1);
                if (towers[row-1][col+1]) RecursiveMap(row-1, col+1);
                if (towers[row-1][col]) RecursiveMap(row-1, col);
            }

            else
            {
                if (towers[row+1][col]) RecursiveMap(row+1, col);
                if (towers[row][col+1]) RecursiveMap(row, col+1);
                if (towers[row+1][col+1]) RecursiveMap(row+1, col+1);
                if (towers[row-1][col+1]) RecursiveMap(row-1, col+1);
                if (towers[row-1][col]) RecursiveMap(row-1, col);
                if (towers[row][col-1]) RecursiveMap(row, col-1);
                if (towers[row+1][col-1]) RecursiveMap(row+1, col-1);
                if (towers[row - 1][col - 1]) RecursiveMap(row - 1, col - 1);
            }
        }
    }

    public bool WillBlockPaths (int row, int col) {

        leftwall = rightwall = upwall = downwall = 0;

        visited[0] = new bool[5];
        visited[1] = new bool[5];
        visited[2] = new bool[5];
        visited[3] = new bool[5];
        visited[4] = new bool[5];

        RecursiveMap(row, col);

        if ((leftwall + downwall) >= 2) return true;
        else if ((rightwall + upwall) >= 2) return true;
        else if ((leftwall + rightwall) >= 2) return true;
        else if ((downwall + upwall) >= 2) return true;
        else return false;
    }

    public void Deactive(GameObject go) {

        SetActiveCell(go);
    }
}
