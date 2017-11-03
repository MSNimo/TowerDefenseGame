using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Vector3 _pos;
    private Vector3 _velocity;
    private Quaternion _rot;

    // Use this for initialization

    public void Initialize()
    {
        _pos = transform.position;
        _rot = transform.rotation;
    }

    public void SetVelocity (Vector3 direction) {

        _velocity = direction * 8f;
    } 
    void Start () {
		//_pos
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
