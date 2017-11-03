using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Vector3 _pos;
    private Vector3 _velocity;
    //private Quaternion _rot;

    // Use this for initialization

    public void Initialize(Vector3 origin, Vector3 direction)
    {
        _pos = origin;
        _velocity = direction.normalized * 100f;
    }

    void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        RaycastHit hit;

        if (Physics.SphereCast(_pos, 1, _velocity, out hit, 2))
        {
            if (hit.collider.tag == "Enemy")
            {
                GameObject go = hit.collider.gameObject;
                Enemy _enemy = go.GetComponent<Enemy>();
                _enemy.TakeDamage(10);
                Debug.Log("Hit");
                Die();

            }
        }

        _pos = _pos + _velocity * Time.deltaTime;
        transform.position = _pos;

    }

    //private void OnCollisionEnter(Collision collision)
    //{
        //Die();
    //}

    private void Die() {
        Destroy(gameObject);
    }
}
