using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    private bool active; 
    private float WAIT_TIME;
    private float currentTime;
    private Object _enemy;
    private int _enemyHealth;
    private int _enemyValue;
    private int _numberEnemy;
    private int enemiesSpawned;

    void Start () {

        active = false;
        currentTime = 0f;
        enemiesSpawned = 0;
        _enemy = Resources.Load("Enemy");

    }

    private void ForceSpawn() {

        GameObject enemy = (GameObject) Object.Instantiate(_enemy);
        enemy.GetComponent<Enemy>().Initialize(_enemyHealth, _enemyValue);
    }

    public void StartWave(float waitTime, int enemyHealth, int enemyValue, int numberEnemy) {

        active = true;
        WAIT_TIME = waitTime;
        _enemyHealth = enemyHealth;
        _enemyValue = enemyValue;
        _numberEnemy = numberEnemy;
    }

    public bool IsActive() {
        return active;
    }

	void Update () {

        if (active) {

            if (currentTime < WAIT_TIME) {

                currentTime += Time.deltaTime;
            }

            else {

                currentTime = 0f;
                ForceSpawn();
                enemiesSpawned ++;

                if(enemiesSpawned == _numberEnemy) {

                    enemiesSpawned = 0;
                    active = false;
                }
            }
        }
	}
}
