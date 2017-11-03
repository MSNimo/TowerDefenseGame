using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Vector3 _pos;
    private Vector3 _velocity;
    private Quaternion _rot;

    // Use this for initialization

    public void Initialize(Vector3 origin, Vector3 direction)
    {
        _pos = origin;
        _rot = transform.rotation;
        _velocity = direction * 8f;
        Debug.Log("Position");
        Debug.Log(_pos);
        Debug.Log("Velocity");
        Debug.Log(_velocity);
    }

    void Start () {
		//_pos
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
