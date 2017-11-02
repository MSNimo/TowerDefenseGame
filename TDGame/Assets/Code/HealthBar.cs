using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider healthBar;
    private Vector3 pos;
    private int score;
    // Use this for initialization
    void Start () {
        healthBar = FindObjectOfType<Slider>();
        healthBar.SetDirection(Slider.Direction.LeftToRight, false);
        healthBar.maxValue = 100;
        healthBar.minValue = 0;
        UpdateHealth(healthBar.maxValue);
    }

    public void UpdateHealth (float value) {
        healthBar.value = value;
        if (value < 0.05f) {
            healthBar.fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
