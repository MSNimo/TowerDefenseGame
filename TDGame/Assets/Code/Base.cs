using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    private int health;

	void Start () {

        health = 100;
	}

    public void DamageBase (int damage) {

        health -= damage;
        HealthBar healthBar = FindObjectOfType<HealthBar>();
        healthBar.UpdateHealth(health);
    }

	void Update () {

        if (health < 0.5) {

            Destroy(gameObject);
            Game game = FindObjectOfType<Game>();
            game.Lose();
        }
	}
}
