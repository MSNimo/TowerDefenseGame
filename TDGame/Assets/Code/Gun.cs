using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    private Vector3 _pos;
    private float COOL_DOWN;
    private float currentTime;
    private static bool hasTarget;
    private Object _bullet;

    void Start () {

        _pos = transform.position;
        COOL_DOWN = 2f;
        currentTime = 0f;
        _bullet = Resources.Load("Bullet");
    }

    public static void HasTarget(bool isThereOne) {

       hasTarget = isThereOne;
    }
    private void ForceSpawn(Vector3 direction) {

        GameObject bullet = (GameObject)Object.Instantiate(_bullet, _pos, transform.rotation);
        bullet.GetComponent<Bullet>().Initialize();
        //
    }

    public void Fire(Vector3 target) {

        Vector3 direction = target - _pos;

        if (currentTime > COOL_DOWN && hasTarget) {
            ForceSpawn(direction);
            currentTime = 0f;
        }
        

    }
    // Update is called once per frame
    void Update() {

        currentTime += Time.deltaTime;
    } 
}
