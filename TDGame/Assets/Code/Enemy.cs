using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private int health;
    private Vector3 velocity;
    private Vector3 position;
    private int REGULAR_ENEMY_DAMAGE;

	// Use this for initialization
	void Start () {

        health = 20;
        velocity = new Vector3 (5, 0, -5);
        position = transform.position;
        REGULAR_ENEMY_DAMAGE = 10;
	}

    public void Initialize () {
        health = 20;
        velocity = new Vector3 (5, 0, -5);
        position = new Vector3 (-16, 1.5f, 16);
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 0) {
            Die();
        }

        Vector3 deltaPos = velocity * Time.deltaTime;
        position += deltaPos;
        transform.position = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Base")) {
            Base home = collision.gameObject.GetComponent<Base>();
            home.DamageBase(REGULAR_ENEMY_DAMAGE);
            Die();
        }

        if (collision.gameObject.tag.Equals("Bullet")) {
                health -= 10;
            }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
