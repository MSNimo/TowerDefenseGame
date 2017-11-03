using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider healthBar;
    
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

    void Update () {
		
	}
}
