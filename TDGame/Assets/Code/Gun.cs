using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    private Vector3 _pos;
    private float COOL_DOWN;
    private float currentTime;
    private Object _bullet;

    void Start () {

        _pos = transform.position;
        COOL_DOWN = 2f;
        currentTime = 0f;
        _bullet = Resources.Load("Bullet");
    }

    private void ForceSpawn(Vector3 direction) {

        Vector3 origin = _pos;
        GameObject bullet = (GameObject)Object.Instantiate(_bullet, _pos, transform.rotation);
        bullet.GetComponent<Bullet>().Initialize(origin, direction);
    }

    public void Fire(Vector3 target) {

        Vector3 direction = target;

        if (currentTime > COOL_DOWN) {

            ForceSpawn(direction);
            currentTime = 0f;
        }     

    }

    void Update() {

        currentTime += Time.deltaTime;
    } 
}
