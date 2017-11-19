using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    float WAIT_TIME;
    float currentTime;
    private Object _enemy;

    void Start () {

        WAIT_TIME = 1f;
        currentTime = 0f;
        _enemy = Resources.Load("Enemy");

    }

    private void ForceSpawn() {

        GameObject enemy = (GameObject) Object.Instantiate(_enemy);
        enemy.GetComponent<Enemy>().Initialize();
    }

	void Update () {

        if (currentTime < WAIT_TIME) {
            currentTime += Time.deltaTime;
        }

        else {
            currentTime = 0f;
            ForceSpawn();
        }
	}
}
