using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour {

    // Use this for initialization

    private Text waveText;

    void Start () {

        waveText = GetComponent<Text>();
        waveText.text = "\nCurrent Wave: 0\nNumber Regular Enemies: 0\nNumber Speedy Enemies: 0\nNumber Strong Enemies: 0";
    }

    public void SetWaveInfo(int wave, int regenem, int speedenem, int strongenem) {

        waveText.text = "\nCurrent Wave: " + wave + "\nNumber Regular Enemies: " + regenem + "\nNumber Speedy Enemies: " + speedenem + "\nNumber Strong Enemies: " + strongenem;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
