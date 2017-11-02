using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    private int health;
	// Use this for initialization
	void Start () {

        health = 100;
	}

    public void DamageBase (int damage) {
        health -= damage;
        HealthBar healthBar = FindObjectOfType<HealthBar>();
        //Debug.Log(healthBar);
        healthBar.UpdateHealth(health);
    }
	// Update is called once per frame
	void Update () {
        if (health < 0.5) {
            Destroy(gameObject);
        }
	}
}
