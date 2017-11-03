using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    private Vector3 _pos;
    private Quaternion _rot;
    private float TOWER_RANGE;
    private Gun _gun;

	// Use this for initialization
	void Start () {

        _pos = transform.position;
        _rot = transform.rotation;
        TOWER_RANGE = 40;
        _gun = gameObject.GetComponent<Gun>();
    }
	
	// Update is called once per frame
	void Update () {
        Collider[] hitColliders = Physics.OverlapSphere(_pos, TOWER_RANGE);
        var dist = float.MaxValue;
        Vector3 direction = new Vector3(0,0,0);
        bool changedirection = false;

        int i = 0;
        while (i < hitColliders.Length) {
            if (hitColliders[i].gameObject.tag.Equals("Enemy")) {
                Vector3 targetpos = hitColliders[i].transform.position;
                var tempdist = Vector3.Distance(_pos, targetpos);

                if (tempdist < dist) {
                    dist = tempdist;
                    direction = targetpos - _pos;
                    changedirection = true;
                }
            }
            i++;
        }

        if (changedirection) {
            _rot = Quaternion.LookRotation(direction);
            _rot *= Quaternion.Euler(0, -90, 0);
            Debug.Log(direction);
            _gun.Fire(direction);
        }

        transform.rotation = _rot;
        
    }
}
