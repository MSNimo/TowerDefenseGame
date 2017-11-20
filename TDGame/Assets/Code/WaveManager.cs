using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    // Use this for initialization

    private float timer;
    private Spawner spawner;
    private WaveUI waveUI;
    private Game game;
    private int level;

    private int LEVEL_ONE_START;
    private int LEVEL_TWO_START;
    private int LEVEL_THREE_START;
    private int LEVEL_FOUR_START;
    private int LEVEL_FIVE_START;

    void Start () {

        timer = 0;
        spawner = FindObjectOfType<Spawner>();
        game = FindObjectOfType<Game>();
        level = 0;

        LEVEL_ONE_START = 20;
        LEVEL_TWO_START = 60;
        LEVEL_THREE_START = 100;
        LEVEL_FOUR_START = 150;
        LEVEL_FIVE_START = 200;

        waveUI = FindObjectOfType<WaveUI>();
    }

    public void IncrementLevel() {
        level++;
    }

    public void StartLevelOne() {

        spawner.StartWave(2f, 21, 5, 5);
        waveUI.SetWaveInfo(1, 5, 0, 0);
    }

    public void StartLevelTwo() {

        spawner.StartWave(2f, 31, 5, 10);
        waveUI.SetWaveInfo(2, 10, 0, 0);
    }

    public void StartLevelThree() {

        spawner.StartWave(2f, 31, 5, 20);
        waveUI.SetWaveInfo(3, 20, 0, 0);
    }

    public void StartLevelFour() {

        spawner.StartWave(1.5f, 41, 10, 25);
        waveUI.SetWaveInfo(4, 25, 0, 0);
    }

    public void StartLevelFive() {

        spawner.StartWave(1.5f, 41, 10, 30);
        waveUI.SetWaveInfo(5, 30, 0, 0);
    }

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if (timer > LEVEL_ONE_START && level == 0) {

            IncrementLevel();
            StartLevelOne();
        }

        if (timer > LEVEL_TWO_START && level == 1) {

            IncrementLevel();
            StartLevelTwo();
        }

        if (timer > LEVEL_THREE_START && level == 2) {

            IncrementLevel();
            StartLevelThree();
        }

        if (timer > LEVEL_FOUR_START && level == 3) {

            IncrementLevel();
            StartLevelFour();
        }

        if (timer > LEVEL_FIVE_START && level == 4) {

            IncrementLevel();
            StartLevelFive();
        }

        if (level == 5) {
            
            if (spawner.IsActive() == false) {
  
                Enemy [] enemies = FindObjectsOfType<Enemy>();
                if (enemies.Length == 0) {
               
                    game.Win();
                }
            }
        }
    }
}
