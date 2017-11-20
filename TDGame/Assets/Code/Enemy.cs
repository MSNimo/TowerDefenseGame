using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private int health;
    private int value;
    private int REGULAR_ENEMY_DAMAGE;

	void Start () {

        REGULAR_ENEMY_DAMAGE = 10;
    }

    public void Initialize (int enemyHealth, int enemyValue) {

        health = enemyHealth;
        value = enemyValue;
    }

    void FixedUpdate() {

        if (health < 0.05) {
            Game gameData = FindObjectOfType<Game>();
            gameData.UpdateCash(value);
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Base")) {

            Base home = collision.gameObject.GetComponent<Base>();
            home.DamageBase(REGULAR_ENEMY_DAMAGE);
            Die();
        }
    }

    private void Die() {

        Destroy(gameObject);
    }

    public void TakeDamage(int damage) {

        health -= damage;
    }
}
